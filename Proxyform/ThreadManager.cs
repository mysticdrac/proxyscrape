using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
namespace proxyform
{

    class ThreadManager
    {
        internal QueueItem Item;
        int _workingThreads;
        int _doneThreads;
        internal List<string> listproxy;
        static int maxThread;
        internal MainForm Parent;
        bool aborted;
        ManualResetEvent _doneEvent = new ManualResetEvent(false);
        ManualResetEvent _allEvent = new ManualResetEvent(false);
        object syncWrkThrd = new object();
        object syncDoneThrd = new object();
        object syncRoot = new object();
        object syncadd = new object();
        object syncprogress = new object();
        object syncprocess = new object();
        object synclistview = new object();
        object syncgoodproxy = new object();
        object syncbadproxy = new object();
        object syncbadlist = new object();
        object syncgoodlist = new object();
        object synclabel = new object();
        object synclockdone = new object();
        object synclockBar = new object();
        int proxycount;
        int goodList;
        int badList;
        int goodProxy;
        int badProxy;
        internal int TimeOut;
        internal volatile bool finished = false;
        
        internal ThreadManager(MainForm parent) {
            Item = new QueueItem();
            _workingThreads=0;
            _doneThreads=0;
            listproxy = new List<string>();      
            Parent = parent;
            aborted = false;
            TimeOut = 10000;

        }
        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        void MinimizeFootprint()
        {
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }

        internal void SetBar(bool value) {
            lock (synclockBar) {
                if(!finished)
                    Parent.SetBar(value);
                
            }
            
        }

        internal void SetDone() {
           
            lock (synclockdone)
            {

                if (WorkingThreads == MaxThread)
                {
                    if (!_doneEvent.WaitOne(0))
                        _doneEvent.Set();
                }
                
            }
        }

        internal int WorkingThreads {
            get {
                lock (syncWrkThrd) {
                    return _workingThreads;
                }
            
            }
            set
            {
                lock (syncWrkThrd)
                {
                    if (value > 0)
                    {
                        _workingThreads++;
                    }
                    else {
                        _workingThreads--;
                    }
                }
            }
        
        }
        
        internal int DoneThreads
        {
            get
            {
                lock (syncDoneThrd)
                {
                    return _doneThreads;
                }

            }
            set
            {
                lock (syncDoneThrd)
                {
                    _doneThreads++;
                    if (_doneThreads == listproxy.Count)                    
                        if (!_allEvent.WaitOne(0))
                            _allEvent.Set();
                    
                }
            }

        }

        #region counter(badproxy,goodproxy etc) value
        internal void SetBadProxy()
        {
            lock(syncbadproxy)
            {
                   
                        badProxy++;

                       Parent.set_labeltext(new object[]{4,badProxy});

             };
                
           // set_labeltext(label14);
        }
        internal void SetGoodProxy()
        {
            lock(syncgoodproxy)
            {
               
                        goodProxy++;
                        Parent.set_labeltext(new object[] { 3, goodProxy });

             }

           // set_labeltext(label13);
        }
        internal void SetBadList()
        {
            lock(syncbadlist)
            {
                        badList++;
                        Parent.set_labeltext(new object[] { 2, badList });
                   
            }
             
            //set_labeltext(label12);
        }
        internal void SetGoodList()
        {
            lock(syncgoodlist)
            {
                
                        goodList++;
                        Parent.set_labeltext(new object[] { 1, goodList });
                   

            }

            //set_labeltext(label7);

        }
        internal void ProxyCount(int value)
        {

          lock(syncRoot)
                {

                   
                        proxycount = proxycount + value;
                        Parent.set_labeltext(new object[] { 0, proxycount });
                   

                }
               

            //set_labeltext(label2);

        }
        #endregion

        internal void addrangetolistview(System.Windows.Forms.ListViewItem[] obj) {
            lock (synclistview) {
                Parent.addrangetolistview(obj);
            }
        }

        internal void changeListViewTexts(object[] obj) {
            lock (synclistview) {
                Parent.changeListViewTexts(obj);
            }
        
        }

        internal void Abort() {

            aborted = true;
         
        }
               
        internal int MaxThread {
            get {
                return maxThread;
            
            }

            set {
                maxThread = value;
            
            }
        }
                
        internal void Run(object ar) {
            object[] args = (object[])ar;
            bool check = (bool)args[0];
            if (!check) {
                proxycount = 0;
                goodList = 0;
                badList = 0;
            
            }

            bool newcheck = (bool)args[1];
            if (newcheck) {
                goodProxy = 0;
                badProxy = 0;
            
            }
            int Index = 0;
            int lstproxy = listproxy.Count;
            //find progress step
            
            
            
            WorkProcess[] ProcessArr = new WorkProcess[lstproxy];
            Thread[] t = new Thread[lstproxy];
            
            try
            {
                int i = 0;
                bool Errorparsing = false;
              
                var tmp ="";
              
                while (DoneThreads < lstproxy)
                {
                    Debug.WriteLine("Threading ");
                    if (aborted)
                        throw new Exception();
                    while (WorkingThreads < MaxThread && i < lstproxy)
                    {
                        if (aborted)
                            throw new Exception();


                        Errorparsing = false;
                        tmp = listproxy[i];
                        if (check)
                        {
                            try
                            {
                                Index = int.Parse(Regex.Split(tmp, ":@@:")[1]);
                                tmp = Regex.Split(tmp, ":@@:")[0];

                            }
                            catch
                            {

                                Debug.WriteLine("Error parsing");
                                DoneThreads = 1;
                                Errorparsing = true;



                            }
                        }
                        if (!Errorparsing)
                        {
                            
                            ProcessArr[i] = new WorkProcess(this);
                           

                            t[i] = new Thread(new ParameterizedThreadStart(ProcessArr[i].AsyncScrape))
                            {
                                IsBackground = true,
                                 Priority = ThreadPriority.Lowest

                            };
                            t[i].SetApartmentState(ApartmentState.MTA);
                            
                            WorkingThreads = 1;
                           t[i].Start(new object[] { tmp, t[i].ManagedThreadId, check, Index });

                            Thread.Sleep(100);

                        }
                        i++;
                        if (WorkingThreads == MaxThread)
                        {
                            
                            break;
                        }
                        
                    }//end while workingcount <=maxthread
                    if (WorkingThreads == MaxThread)
                    {

                        _doneEvent.WaitOne();
                        _doneEvent.Reset();
                        Thread.Sleep(1000);
                    }
                    if (i == listproxy.Count) {

                        _allEvent.WaitOne();
                    }
                
                }//end while donethread < listproxy.length

            }
            catch (ThreadAbortException)
            {

                Thread.ResetAbort();
                Debug.WriteLine("Abort not done");

            }
            catch (ObjectDisposedException e) {
                Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);


            }
            if (aborted) {
               for (int i = 0; i < ProcessArr.Length;i++ )
               {
                        if(ProcessArr[i] != null)
                                ProcessArr[i].Abort();

                   
                }
            }
            Debug.WriteLine("Thread fINISHED");

            if (check)
            {
                Parent.savelistviewiptodb(Parent.TabelName[4]);
            }
                foreach (Thread ta in t)
                {
                    if(ta !=null)
                        if(ta.IsAlive)
                            ta.Interrupt();
                }

                MinimizeFootprint();
                finished = true;
                Parent.SetBar(true);

                Thread.Sleep(1000);
                if (check)
                {
                    Parent.SetButton1Text(new object[] { Parent.button11, "Start" });
                }
                else
                {
                    Parent.SetButton1Text(new object[] { Parent.button1, "Start" });
                }

               // Parent.ResetTime();

        }
        
    }
}
