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
using System.Transactions;
namespace proxyform
{
    partial class MainForm
    {
        
       #region Custom Operation(process,cancel,filter,writefile)

       void process(object sender)
        {

            GC.Collect();
            CustomBtn b = (CustomBtn)sender;
           if(b.ImageIndex == 5 || b.ImageIndex==20) 
           {           
                cancel();
                b.Enabled = false;
                return;
            }
            bool check = false; // indicate if testproxy or scrape proxy
            bool newcheck = false;
            if (b.Name.Equals(button1.Name))//if button is scrape proxy from url
            {
                if (richTextBox2.Text.Trim().Equals(string.Empty))
                {
                    return;

                }
                if (button11.ImageIndex == 18)
                {
                    MessageBox.Show("Please stop proxy test first");
                    return;
                }
                //reset labels and variable counter to 0 
                listView1.Items.Clear();
                label6.Text = "0";
                label7.Text = "0";
                label12.Text = "0";
                label13.Text = "0";
                label14.Text = "0";

                //fill listproxy with url from textbox
                new deg_ProcessStart(ProcessStart).BeginInvoke(new object[] { check, newcheck }, null, null);
            }
            else
            { //button is testproxy's button
                if (button1.ImageIndex == 3)
                {
                    MessageBox.Show("Please stop proxy gathering");
                    return;
                }
                if (listView1.Items.Count > 0)
                {
                    var result = MessageBox.Show("New Test ? (otherwise will continue)", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)//perform new test
                    {
                        newcheck = true;

                    }
                    check = true;
                    new deg_ProcessStart(ProcessStart).BeginInvoke(new object[] { check, newcheck }, null, null);

                }
                else
                {//listview is empty , return

                    MessageBox.Show("There is no Proxy to check,please get it first !");
                    return;
                }
            }
            b.ImageIndex = b.ImageIndex + 1;
        }

       void ProcessStart(object[] objs) {
           bool check = (bool)objs[0];
           bool newcheck = (bool)objs[1];
           string[] listproxy = null;
           if (!check)
           {
               richTextBox2.Invoke(new MethodInvoker(delegate { listproxy = Regex.Split(richTextBox2.Text.Trim(), "\n"); }));

           }
           else {
               int listviewcount = listView1.Items.Count;
       
                ListViewItem[] item = new ListViewItem[listviewcount];
                listproxy = new string[listviewcount];
               for (int x = 0; x < listviewcount;x++ )
               {
                   var x1 = x;
                   listView1.Invoke((MethodInvoker)delegate { item[x1] = (ListViewItem)listView1.Items[x1].Clone(); });
                   if (newcheck)//newtest,reset all subitem
                   {
                       try
                       {
                           listproxy[x1] = item[x1].SubItems[0].Text + ":@@:"+x1; 
                       }
                       catch (System.Exception ex) {

                           Debug.WriteLine(ex.Message);
                       }
                      
                       listView1.BeginInvoke((MethodInvoker)delegate
                       {
                           listView1.Items[x1].ImageIndex = -1;
                           listView1.Items[x1].SubItems[1].Text = "";
                           listView1.Items[x1].SubItems[2].Text = "";
                           listView1.Items[x1].SubItems[3].Text = "";
                           listView1.Items[x1].SubItems[4].Text = "";
                       });
                   }
                   else
                   {
                       if (item[x1].ImageIndex < 0)
                       {
                           listproxy[x1] = item[x1].SubItems[0].Text + ":@@:" + x1; 
                       }

                   }
        
               }

           }
           Debug.WriteLine("Listview finished");
           int count = GetCountdb(null, TabelName[4]);
           if (count > 0)
           {
               deletefromdb(null, TabelName[4]);
           }
           proxylength = listproxy.Length;
           if (!check)
           {
               this.Invoke(new MethodInvoker(delegate { this.label6.Text = proxylength.ToString(); }));

           }
           Manager = null;
           Manager = new ThreadManager(this);
           Manager.listproxy.AddRange(listproxy);
           comboBox1.Invoke((MethodInvoker)delegate { Manager.MaxThread = int.Parse(comboBox1.Text); }, new object[] { Manager }); //get max threads from combobox
           comboBox2.Invoke((MethodInvoker)delegate { Manager.TimeOut = int.Parse(comboBox2.Text)*1000;}, new object[] { Manager });
           SetProgressMax = proxylength;
           this.Invoke((MethodInvoker)delegate
           {
               toolStripProgressBar1.Value = 0;
           });
           t = new Thread(new ParameterizedThreadStart(Manager.Run))
           {
               IsBackground = true,
               Priority = ThreadPriority.Lowest

           };
           t.SetApartmentState(ApartmentState.MTA);
           
           timer = 0;
           this.Invoke((MethodInvoker)delegate {
               timer1.Enabled = true;
               timer1.Start(); 
           });

           if (!check)
           {
               button1.ImageIndex = button1.ImageIndex + 2;
               button1.StartImgNumb=button1.ImageIndex-1;
               t.Start(new object[] { false, true }); //start scrape proxy from url
           }
           else
           {
               button11.ImageIndex = button11.ImageIndex + 2;
               button11.StartImgNumb = button11.ImageIndex-1;
               t.Start(new object[] { true, newcheck }); //start scrape proxy from url
           }
         
       }    
     
       void cancel()
        {
            if (Manager != null)
            {
                Manager.Abort();
            }
        }

       void writefile(string filepath, CustomBtn b)
        {
            StringBuilder builder = new StringBuilder();
            if (b == button4)
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    builder.AppendLine(item.SubItems[0].Text);
                }
            }
            else if(b==button9){

                builder.Append(richTextBox2.Text);
            
            }
            File.WriteAllText(filepath, builder.ToString());
        }

       void readlinksfile(object obj) {
           string filename = obj as string;
           string links = File.ReadAllText(filename);
           this.Invoke((MethodInvoker)delegate {
               richTextBox2.Text = links;
           
           });
       
       }

       void readfile(object obj) {
            string filename = obj as string;
            string list = File.ReadAllText(filename);
            HashSet<string> liststr = new HashSet<string>();
            Helper.ExtractIpPort(list,ref liststr);
            if (liststr != null)
            {
                ListViewItem _item = null;
                List<ListViewItem> _itemlist = new List<ListViewItem>();          
                this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Maximum = liststr.Count; });
                int i = 0;
                foreach(string str in liststr)
                {
                    try
                    {
                        _item = new ListViewItem(str);

                        for (int x = 1; x < 6; x++)
                        {
                            _item.SubItems.Add("");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                    i++;
                   
                    if (_item !=null)
                    {
                        _itemlist.Add(_item);
                    }
                    SetBar(false);
                }
                addrangetolistview(_itemlist.ToArray());
            }        
        }

       


        #endregion
       #region Embeded
       void readalltextbox(out Hashtable[] hash)
       {
           string[] urls = Regex.Split(richTextBox2.Text, "\n");
           hash = new Hashtable[urls.Length];
           int i = 0;
           foreach (string url in urls)
           {
               hash[i] = new Hashtable();
               hash[i].Add("Url", url);
               i++;
           }

       }

       internal void savelistviewiptodb(string tablename)
       {
           if (this.InvokeRequired)
           {
               deg_savelistviewiptodb addlist = new deg_savelistviewiptodb(savelistviewiptodb);
               this.Invoke(addlist,new object[]{tablename});


           }
           else
           {


               //READ FROM LISTVIEW
               Hashtable[] hash = new Hashtable[listView1.Items.Count];
               int y = 0;
               string _itemtext = "";
               bool _boolconv = false;
               try
               {
                   this.Invoke((MethodInvoker)delegate
                   {
                       foreach (ListViewItem _itemcc in listView1.Items)
                       {
                           var i = y;
                           ListViewItem _item = _itemcc;
                           hash[i] = new Hashtable();
                           hash[i].Add("Valid", _item.ImageIndex);

                           for (int x2 = 0; x2 < listView1.Columns.Count; x2++)
                           {

                               _itemtext = _item.SubItems[x2].Text;
                               ColumnHeader col = listView1.Columns[x2];
                               if (!_itemtext.Trim().Equals(String.Empty))
                               {
                                   if (_itemtext.ToLower().Equals("true") || _itemtext.ToLower().Equals("false"))
                                   {
                                       _boolconv = bool.Parse(_itemtext);
                                       if (_boolconv)
                                       {
                                           hash[i].Add(col.Text, 1);
                                       }
                                       else
                                       {
                                           hash[i].Add(col.Text, 0);
                                       }
                                   }
                                   else
                                   {
                                       if (col.Text.Equals("Speed") || col.Text.Equals("Typeprox")) //col.Text.Equals("Speed") || col.Text.Equals("Typeprox"))
                                       {
                                           try
                                           {
                                               int res = int.Parse(_itemtext);
                                               hash[i].Add(col.Text, res);//col.Text, int.Parse(_itemtext));
                                           }
                                           catch (Exception ex)
                                           {
                                               Debug.WriteLine(ex.Message);
                                           }
                                       }
                                       else
                                       {
                                           hash[i].Add(col.Text, _itemtext);//col.Text, _item.SubItems[x1].Text);
                                       }
                                   }
                               }
                           }

                           y++;
                       }
                   });
                   insertbulk(hash, tablename);
               }
               catch (System.NullReferenceException ex)
               {
                   Debug.WriteLine(ex.Message);
               }
               catch (Exception ex)
               {
                   Debug.WriteLine(ex.Message);
               }
           }
       }

       internal delegate void deg_savelistviewiptodb(string tablename);
       void loadipfromdb(string tablename, Hashtable hash = null)
       {
           List<Dictionary<string, object>> list = null;
           view(hash, out list, tablename);
           Print(list, listView1);
       }

       void Print(List<Dictionary<string, object>> list, Control ctrl)
       {
           if (list != null)
           {

               Dictionary<string, object> objhash;
             //  ListViewItem _item = null;
               ListViewItem[] _itemlist = null;
               StringBuilder strbldr = new StringBuilder();
               // Label lbl;
               if (ctrl.GetType() == typeof(ListView))
               {
                   this.Invoke((MethodInvoker)delegate
                   {
                       label2.Text = list.Count.ToString();
                   });
                   _itemlist = new ListViewItem[list.Count];

               }
               else if (ctrl.GetType() == typeof(RichTextBox))
               {
                   this.Invoke((MethodInvoker)delegate
                   {
                       label6.Text = list.Count.ToString();
                   });
               }
               int good = 0;
               int bad = 0;
               for (int i = 0; i < list.Count; i++)
               {
                   if (ctrl.GetType() == typeof(ListView))
                   {
                       _itemlist[i] = new ListViewItem();
                   }

                   objhash = list[i] as Dictionary<string, object>;
                   foreach (KeyValuePair<string, object> obj in objhash)
                   {
                       if (obj.Value != null)
                       {
                           if (ctrl.GetType() == typeof(RichTextBox))
                           {
                               switch (obj.Key)
                               {
                                   case "id":
                                       break;
                                   case "Url":
                                       strbldr.AppendLine(obj.Value.ToString());
                                       break;
                                   case "Valid":
                                       if ((int)obj.Value == 1)
                                       {
                                           good++;
                                       }
                                       else
                                       {
                                           bad++;

                                       }
                                       break;
                               }
                               //if (obj.Key == "Url")
                               //{
                               //    strbldr.AppendLine(obj.Value.ToString());
                              // }
                           }
                           else if (ctrl.GetType() == typeof(ListView))
                           {
                               switch (obj.Key)
                               {
                                   case "id":
                                       break;
                                   case "Valid":
                                       if ((int)obj.Value == 1)
                                       {
                                           good++;
                                           _itemlist[i].ImageIndex = 1;
                                       }
                                       else
                                       {
                                           bad++;
                                           _itemlist[i].ImageIndex = 0;
                                       }
                                       break;
                                   case "Ipport":
                                       _itemlist[i].SubItems[0].Text = obj.Value.ToString();
                                       break;
                                   case "Speed":
                                   case "Typeprox":
                                       _itemlist[i].SubItems.Add(obj.Value.ToString());
                                       break;
                                   case "Https":
                                   case "Google":
                                       if ((int)obj.Value == 1)
                                       {
                                           _itemlist[i].SubItems.Add("True");
                                       }
                                       else
                                       {
                                           _itemlist[i].SubItems.Add("False");
                                       }
                                       break;
                               }
                           }
                       }
                   }
                   
               }//end for
               if (ctrl.GetType() == typeof(ListView))
               {
                   this.Invoke((MethodInvoker)delegate { listView1.Items.AddRange(_itemlist); });
                   this.Invoke((MethodInvoker)delegate { label13.Text = good.ToString(); });
                   this.Invoke((MethodInvoker)delegate { label14.Text = bad.ToString(); });
               }else if (ctrl.GetType() == typeof(RichTextBox))
               {
                   this.Invoke((MethodInvoker)delegate { richTextBox2.Text = strbldr.ToString(); });
                   this.Invoke((MethodInvoker)delegate { label7.Text = good.ToString(); });
                   this.Invoke((MethodInvoker)delegate { label12.Text = bad.ToString(); });
               }
           }
       }

       void filter()
       {
           bool allspeed = false;
           bool alllvl = false;
           if ((fast_chk.Checked && slow_chk.Checked) || (!fast_chk.Checked && !slow_chk.Checked))
           {

               allspeed = true;
           }
           if ((elite_chk.Checked && anon_chk.Checked && transparant_chk.Checked) || (!elite_chk.Checked && !anon_chk.Checked && !transparant_chk.Checked))
           {

               alllvl = true;


           }

           //Hashtable hash = new Hashtable();
           List<object[]> objs = new List<object[]>();
           object[] obj = null;
           foreach (Control ctrl in groupBox1.Controls)
           {
               if (ctrl.GetType() == typeof(CheckBox))
               {
                   CheckBox chkbx = ctrl as CheckBox;
                   if (chkbx.Checked)
                   {
                       obj = new object[2];
                       if (chkbx.Text.Equals(fast_chk.Text) || chkbx.Text.Equals(slow_chk.Text))
                       {
                           if (!allspeed)
                           {
                               if (chkbx.Text.Equals(fast_chk.Text))
                               {
                                   obj[0] = "Speed";
                                   obj[1] = 3000;

                               }
                               else
                               {
                                   obj[0] = "Speed";
                                   obj[1] = -3000;

                               }
                           }

                       }
                       else if (chkbx.Text.StartsWith("Lvl"))
                       {
                           if (!alllvl)
                           {
                               obj[0] = "Typeprox";
                               obj[1] = int.Parse(Regex.Split(chkbx.Text, "Lvl")[1]);
                           }
                       }
                       else
                       {
                           obj[0] = chkbx.Text;
                           obj[1] = 1;
                           //hash.Add(chkbx.Text, 1);
                       }
                       if (obj != null)
                       {
                           if (obj[0] != null)
                               objs.Add(obj);
                       }
                   }

               }

           }//end for
           List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
           view2(objs, out list, TabelName[4]);
           listView1.Items.Clear();
           Print(list, listView1);


       }

       void filterlistview()
       {
           

         
           filter();
       }
       #endregion



       #region Db Operation
       internal void insertbulk(Hashtable[] hash, string tablename)
       {
           if (this.InvokeRequired)
           {

               deg_insertbulk bulk = new deg_insertbulk(insertbulk);
               this.Invoke(bulk,new object[]{hash,tablename});
           }
           else
           {

               sqlconnect.sqlconnect conn;
               using (TransactionScope ts = new TransactionScope())
               {
                   conn = new sqlconnect.sqlconnect("data.sqlite", "Ie3Cdks0388Csed");
                   conn.insertBulk(tablename, hash);
                   conn.close_dbConnection();
                   ts.Complete();

               }
           }

       }

       internal delegate void deg_insertbulk(Hashtable[] hash,string tablename);

       internal void deletefromdb(Hashtable hash, string tablename)
       {
           sqlconnect.sqlconnect conn;
           using (TransactionScope ts = new TransactionScope())
           {
               conn = new sqlconnect.sqlconnect("data.sqlite", "Ie3Cdks0388Csed");
               conn.delete(tablename, hash);
               conn.close_dbConnection();
               ts.Complete();

           }
       }

       internal int GetCountdb(Hashtable hash, string tablename)
       {
           sqlconnect.sqlconnect conn;
           int count = 0;
           using (TransactionScope ts = new TransactionScope())
           {
               conn = new sqlconnect.sqlconnect("data.sqlite", "Ie3Cdks0388Csed");
               count = conn.Count(tablename, hash);
               conn.close_dbConnection();
               ts.Complete();

           }
           return count;
       }

       void view(Hashtable hash, out List<Dictionary<string, object>> list, string tablename)
       {
           sqlconnect.sqlconnect conn;
           using (TransactionScope ts = new TransactionScope())
           {
               conn = new sqlconnect.sqlconnect("data.sqlite", "Ie3Cdks0388Csed");
               list = conn.view(tablename, hash);
               conn.close_dbConnection();
               ts.Complete();
           }

       }

       void view2(List<object[]> hash, out List<Dictionary<string, object>> list, string tablename)
       {
           sqlconnect.sqlconnect conn;
           using (TransactionScope ts = new TransactionScope())
           {
               conn = new sqlconnect.sqlconnect("data.sqlite", "Ie3Cdks0388Csed");
               list = conn.view2(tablename, hash);
               conn.close_dbConnection();
               ts.Complete();
           }

       }

       #endregion

    }
}
