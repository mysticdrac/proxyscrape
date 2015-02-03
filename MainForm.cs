/*
 * Created by SharpDevelop.
 * User: maranisha
 * Date: 12/16/2014
 * Time: 7:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
namespace proxyform
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
    partial class MainForm : Form
    {

        #region Variables

        ThreadManager Manager;
        Thread t;
        int proxylength;
        int timer;
        bool start;
        internal string[] TabelName = new string[5] { 
        "UrlList",
        "ProxyList",
        "UrlListTmp",
        "ProxyListTmp",
        "ProxyListFilter"
        };

        #endregion

        #region Constructor,variable declare default value
        internal MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        #endregion
        
        #region Listview,setLabelText,setButtonText

        internal void changeListViewTexts(object[] obj)
        {

            if (this.InvokeRequired)
            {
                deg_ChangeListViewTexts t = new deg_ChangeListViewTexts(changeListViewTexts);
                this.Invoke(t, new object[] { obj });

            }
            else
            {
                int Index = (int)obj[0];
                if (obj[1] != null)
                {

                    //Dictionary<int, string> subIndex = (Dictionary<int, string>)obj[1];
                    Hashtable subIndex = obj[1] as Hashtable;
                    listView1.BeginInvoke((MethodInvoker)delegate { listView1.Items[Index].ImageIndex = 1; }, Index);
                    //foreach (KeyValuePair<int, string> entry in subIndex)
                    foreach (DictionaryEntry entry in subIndex)
                    {

                        listView1.BeginInvoke((MethodInvoker)delegate { listView1.Items[Index].SubItems[(int)entry.Key].Text = (string)entry.Value; }, new object[] { Index, entry });
                    }

                    subIndex.Clear();
                }
                else
                {

                    listView1.BeginInvoke((MethodInvoker)delegate { listView1.Items[Index].ImageIndex = 0; }, Index);
                }
                //obj = null;  


            }
        }
        internal void addrangetolistview(ListViewItem[] obj)
        {

            if (this.InvokeRequired)
            {
                deg_addrangetolistview t = new deg_addrangetolistview(addrangetolistview);
                this.Invoke(t, new object[] { obj });

            }
            else
            {
                try
                {


                    listView1.BeginInvoke((MethodInvoker)delegate
                    {

                        listView1.Items.AddRange(obj);

                    }, obj);


                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                }

                //obj = null;

            }



        }
        internal void addtolistview(ListViewItem obj)
        {

            if (this.InvokeRequired)
            {
                deg_addtolistview t = new deg_addtolistview(addtolistview);
                this.Invoke(t, new object[] { obj });
            }
            else
            {
                try
                {
                    listView1.BeginInvoke((MethodInvoker)delegate
                    {
                        listView1.Items.Add(obj);
                    }, obj);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
        internal void SetButton1Text(object[] obj)
        {
            this.Invoke((MethodInvoker)delegate
            {
                CustomBtn b = obj[0] as CustomBtn;
                var str = obj[1] as string;
                if (str.ToLower().Equals("start"))
                {
                    b.ImageIndex = b.ImageIndex -3;//.Text = str;
                    b.StartImgNumb = b.ImageIndex;
                    if (!b.Enabled)
                        b.Enabled = true;
                }
            });
        }
        internal void ResetTime()
        {
            this.Invoke((MethodInvoker)delegate
            {
                timer1.Stop();
                timer1.Enabled = false;
            });
        }
        internal void set_labeltext(object obj)
        {

            if (this.InvokeRequired)
            {
                deg_set_labeltext t = new deg_set_labeltext(set_labeltext);
                this.Invoke(t, new object[] { obj });

            }
            else
            {
                object[] objlbl = obj as object[];
                switch ((int)objlbl[0])
                {
                    case 0://proxy count
                        label2.Text = objlbl[1].ToString();
                        break;
                    case 1://goodlist
                        label7.Text = objlbl[1].ToString();
                        break;
                    case 2://badlist
                        label12.Text = objlbl[1].ToString();
                        break;
                    case 3://goodproxy
                        label13.Text = objlbl[1].ToString();
                        break;
                    case 4://badproxy
                        label14.Text = objlbl[1].ToString();
                        break;

                }


            }


        }
        internal void SetBar(bool full)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (!full)
                    toolStripProgressBar1.Value++;
                else
                    toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            });

        }
        internal int SetProgressMax
        {
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    toolStripProgressBar1.Maximum = value;
                });
            }


        }
        #endregion
        
        #region Eventhandler(buttonclick,formload etc)

        void Button1Click(object sender, EventArgs e)
        {
            process(sender);
        }
        void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog fldg = new SaveFileDialog();
            fldg.DefaultExt = "txt";
            fldg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fldg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fldg.OverwritePrompt = true;
            toolStripProgressBar1.Value = 0;
            if (fldg.ShowDialog() == DialogResult.OK)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {

                    writefile(fldg.FileName,button4);
                }, fldg.FileName);

            }
        }
        void button6_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                var result = MessageBox.Show("Do you want to clear all ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)//perform new test
                {
                    listView1.Items.Clear();

                }
            }

        }
        void button11_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate { process(sender); }));
        }
        void Button2Click(object sender, EventArgs e)
        {
            cancel();
        }
        void MainForm_Load(object sender, EventArgs e)
        {
            //regFrm = new Form1(this);
            //regFrm.CheckLicense();

            this.comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            ListViewExt.SetDoubleBuffered(listView1);
            listView1.ListViewItemSorter = null;
            List<Dictionary<string, object>> list;
            view(null, out list, TabelName[0]);
            Print(list, richTextBox2);
            deg_loadipfromdb prt = new deg_loadipfromdb(loadipfromdb);
            this.BeginInvoke(prt, new object[] { TabelName[1], null });
            //loadipfromdb(TabelName[3],null);
        }
        #endregion
        
        #region Delegates
        internal delegate void deg_addtotextbox(string proxy, bool goog);
        internal delegate void deg_addrangetolistview(ListViewItem[] obj);
        internal delegate void deg_ChangeListViewText(object[] lists);
        internal delegate void deg_set_labeltext(object obj);
        internal delegate void deg_ChangeListViewTexts(object[] lists);
        internal delegate void deg_addtolistview(ListViewItem obj);
        delegate void deg_ProcessStart(object[] objs);
        delegate void deg_loadipfromdb(string tablename, Hashtable hash);
        delegate void deg_addlistview();
        #endregion

        void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (Manager != null)
            {
                if (Manager.finished)
                {
                    int value = 0;
                    this.Invoke((MethodInvoker)delegate
                    {
                        value = Int32.Parse(label18.Text);

                    });
                    if (value == 0)
                    {
                        GC.Collect();
                        ResetTime();
                    }

                }
                label18.BeginInvoke((MethodInvoker)delegate { label18.Text = Manager.WorkingThreads.ToString(); }, Manager);
                label17.BeginInvoke((MethodInvoker)delegate { label17.Text = Manager.DoneThreads.ToString(); }, Manager);
                label19.BeginInvoke((MethodInvoker)delegate { label19.Text = TimeSpan.FromSeconds(timer).ToString(); }, timer);
            }
        }

        void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void timer2_Tick(object sender, EventArgs e)
        {

        }

        void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();

        }
        
        void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        void BtnHover(object b, EventArgs e)
        {
            CustomBtn btn = (CustomBtn)b;
            if (btn.StartImgNumb+3 >= btn.ImageIndex + 1)
            {
                btn.ImageIndex = btn.ImageIndex + 1;
            }

        }

        void BtnLeave(object b, EventArgs e)
        {
            CustomBtn btn = (CustomBtn)b;
            if (btn.ImageIndex - 1>=btn.StartImgNumb)
            {
                btn.ImageIndex = btn.ImageIndex - 1;
            }

        }

        void BtnDown(object b, MouseEventArgs e)
        {
            CustomBtn btn = (CustomBtn)b;
            if (btn.StartImgNumb + 3 >= btn.ImageIndex + 1)
            {
                btn.ImageIndex = btn.ImageIndex + 1;
            }

        }

        void BtnUp(object b, MouseEventArgs e)
        {
            CustomBtn btn = (CustomBtn)b;
            if (btn.ImageIndex - 1 >= btn.StartImgNumb)
            {
                btn.ImageIndex = btn.ImageIndex - 1;
            }
        }

        void button8_Click(object sender, EventArgs e)
        {

            if (!richTextBox2.Text.Trim().Equals(string.Empty))
            {
                var result = MessageBox.Show("Do you want to clear all ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)//perform new test
                {
                    richTextBox2.Text = "";

                }

            }
            
            OpenFileDialog fldg = new OpenFileDialog();
            fldg.DefaultExt = "txt";
            fldg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fldg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            toolStripProgressBar1.Value = 0;

            if (fldg.ShowDialog() == DialogResult.OK)
            {


                Thread t = new Thread(new ParameterizedThreadStart(readlinksfile))
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Lowest

                };
                t.SetApartmentState(ApartmentState.MTA);
                t.Start(fldg.FileName);

            }
           
        }

        void button5_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                var result = MessageBox.Show("Do you want to clear all ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)//perform new test
                {
                    listView1.Items.Clear();

                }
                else if (result == DialogResult.Cancel) {

                    return;
                
                }
            }
            OpenFileDialog fldg = new OpenFileDialog();
            fldg.DefaultExt = "txt";
            fldg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fldg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            toolStripProgressBar1.Value = 0;

            if (fldg.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(new ParameterizedThreadStart(readfile))
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Lowest

                };
                t.SetApartmentState(ApartmentState.MTA);
                t.Start(fldg.FileName);
                
            }

        }

        void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog fldg = new SaveFileDialog();
            fldg.DefaultExt = "txt";
            fldg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fldg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fldg.OverwritePrompt = true;
            toolStripProgressBar1.Value = 0;

            if (fldg.ShowDialog() == DialogResult.OK)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {

                    writefile(fldg.FileName, button9);
                }, fldg.FileName);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!richTextBox2.Text.Trim().Equals(string.Empty))
            {
                if (MessageBox.Show("Are you sure want to clear all links ? ", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.richTextBox2.Text = "";

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                filterlistview();

            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deletefromdb(null, TabelName[0]);
            deletefromdb(null, TabelName[1]);

            //save all to history close the form
            if (richTextBox2.Text.Trim() != string.Empty)
            {
                Hashtable[] hash;
                readalltextbox(out hash);
                insertbulk(hash, TabelName[0]);
            }
            else
            {

            }
            this.BeginInvoke((MethodInvoker)delegate { savelistviewiptodb(TabelName[1]); });
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            /*
            // Start the task
            var thread = new Thread(DoTask)
            {
                IsBackground = false,
                Name = "Closing thread.",
            };
            thread.Start();
            */
            

            this.BeginInvoke((MethodInvoker)delegate { savelistviewiptodb(TabelName[3]); });

            base.OnFormClosed(e);
        }

     }
}
