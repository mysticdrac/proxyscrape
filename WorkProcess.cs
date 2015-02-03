using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Transactions;
using System.Globalization;
namespace proxyform
{
    class WorkProcess
    {

        #region Variables
        ThreadManager Parent;
        ManualResetEvent allDone = new ManualResetEvent(false);
        const int BUFFER_SIZE = 8192;
        int Identifier;
        bool check=false;
        int Index;
        bool aborted=false;
        string urlproxy;
        private static Regex regIp = new Regex(@"(?:(?:1[0-9]{2}|2[0-4][0-9]|25[0-5]|[1-9][0-9]|[0-9])\.){3}(?:1[0-9]{2}|2[0-4][0-9]|25[0-5]|[1-9][0-9]|[0-9]):[0-9]{1,5}",
        RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        int DefaultTimeout = 10000;
        WebAsyncReq.WebAsyncReq req;
        #endregion
        
        #region CONSTRUCTORDESTRUCTOR
        internal WorkProcess(ThreadManager parent)
        {
            Parent = parent;
        }
        #endregion     

        string SslRequest(string url, WebProxy proxy)
        {
            AppDomain _domain = AppDomain.CreateDomain(Guid.NewGuid().ToString());

            WebAsyncReq.WebAsyncReq boundary = (WebAsyncReq.WebAsyncReq)
                          _domain.CreateInstanceAndUnwrap(
                             typeof(WebAsyncReq.WebAsyncReq).Assembly.FullName,
                             typeof(WebAsyncReq.WebAsyncReq).FullName);
            boundary.SetSSL = true;
            boundary.SetTimeOut = DefaultTimeout;
            object obj = boundary.Request(url, proxy);
            string str = null;
            if(obj != null)
            {
                str = obj.ToString();
            }
            AppDomain.Unload(_domain);
            return str;
        }

        internal void AsyncScrape(object obj) {
            try
            {
                try
                {
                    if (aborted)
                        throw new Exception();

                    object[] context = obj as object[];
                    string url = context[0] as string;
                    Identifier = (int)context[1];
                    check = (bool)context[2];
                    Index = (int)context[3];
                    WebProxy proxy = null;                

                    if (check)
                    {
                        try
                        {
                            string ip = Regex.Split(context[0].ToString(), ":")[0];
                            string port = Regex.Split(context[0].ToString(), ":")[1];
                            urlproxy = ip;
                            proxy = new WebProxy(ip, Int32.Parse(port));
                            url = "http://mysticgirl.tk/checkip.php";
                                                    
                        }
                        catch (Exception)
                        {
                           // proxy = null;
                            Parent.SetDone();
                            Parent.WorkingThreads=0;                       
                            Parent.DoneThreads = 1;
                            Parent.SetBar(false);
                            return;

                        }

                    }
                    else
                    {
                        urlproxy = url;
                    }

                    if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute)) {
                        Parent.SetDone();
                        Parent.WorkingThreads = 0;
                        Parent.DoneThreads = 1;
                        Parent.SetBar(false);
                        return;
                    
                    }
                    string result = null;
                    Stopwatch speed = new Stopwatch();
                    speed.Start();
                    req = new WebAsyncReq.WebAsyncReq();
                    req.SetSSL = false;
                    req.SetTimeOut = DefaultTimeout;
                    object objc = req.Request(url,proxy);
                    if (objc != null) {
                        result = objc.ToString();
                    }
                    speed.Stop();
                    if (result != null && !result.Trim().Equals(string.Empty))
                    {


                        if (!check)
                        {
                            Parent.SetGoodList();
                            
                            HashSet<string> list = new HashSet<string>();
                            Helper.ExtractIpPort(result,ref list);
                            if (list != null)
                            {
                                if (list.Count > 0)
                                {
                                    System.Windows.Forms.ListViewItem[] _item = new System.Windows.Forms.ListViewItem[list.Count];
                                    
                                    var i = 0;
                                    foreach (var str in list)                                   
                                    {
                                        _item[i]  = new System.Windows.Forms.ListViewItem(str.ToString());
                                        _item[i].SubItems.Add("");
                                        _item[i].SubItems.Add("");
                                        _item[i].SubItems.Add("");
                                        _item[i].SubItems.Add("");
                                        _item[i].SubItems.Add("");
                                        i++;
                            

                                    }
                                    Parent.addrangetolistview(_item);//lists);
                                    Parent.ProxyCount(_item.Length);


                                    //Thread.Sleep(100);

                                }

                                //list = null;
                            }

                        } //if test proxy and result !=null
                        else
                        {
                            int type = 0;
                            if (result.StartsWith("ok"))
                            {
                                try
                                {
                                    type = int.Parse(Regex.Split(result, ":")[1]);

                                }
                                catch (Exception)
                                {
                                    result = null;
                                    Parent.changeListViewTexts(new object[] { Index, null });
                                    Parent.SetBadProxy();
                                }
                            }
                            else {
                                result = null;
                                Parent.changeListViewTexts(new object[] { Index, null });
                                Parent.SetBadProxy();
                            
                            }
                            if (result != null)
                            {

                                Hashtable lvobj = new Hashtable();
                                lvobj.Add(3, speed.ElapsedMilliseconds.ToString());
                                lvobj.Add(4, type.ToString());
                                

                                result = SslRequest("https://www.google.com", proxy);
                                if (result != null && !result.Trim().Equals(string.Empty))
                                {
                                    if (Regex.IsMatch(result, "googlecaptcha_files/image.jpg"))
                                    {
                                        lvobj.Add(2, "False");
                                        lvobj.Add(1, "True");
                                    }
                                    else
                                    {
                                        lvobj.Add(2, "True");
                                        lvobj.Add(1, "True");
                                    }
                                }
                                else
                                {

                                    lvobj.Add(2, "False");
                                    lvobj.Add(1, "False");

                                }


                                Parent.changeListViewTexts(new object[] { Index, lvobj });
                                Parent.SetGoodProxy();
                            }
                            else {
                                Parent.changeListViewTexts(new object[] { Index, null });
                                Parent.SetBadProxy();   
                            
                            
                            }

                        }
                    }
                    else
                    {
                        if (aborted)
                            throw new Exception();
                        if (check)
                        {

                            Parent.changeListViewTexts(new object[] { Index, null });
                            Parent.SetBadProxy();
                        }
                        else
                        {

                            Parent.SetBadList();
                        }

                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine("Thread Aborted");
                }
                Parent.SetDone();
                Parent.WorkingThreads=0;//.Remove(Identifier);
                Parent.DoneThreads = 1;
                Parent.SetBar(false);

            }
            catch (System.Threading.ThreadInterruptedException) { }

        }
          
        internal void Abort()
        {
            aborted = true;
            if (req != null) {
                req.Abort();
            }


        }

    }
}
