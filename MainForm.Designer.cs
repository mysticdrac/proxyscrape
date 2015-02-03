/*
 * Created by SharpDevelop.
 * User: maranisha
 * Date: 12/16/2014
 * Time: 7:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace proxyform
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button7 = new proxyform.CustomBtn();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button9 = new proxyform.CustomBtn();
            this.button8 = new proxyform.CustomBtn();
            this.button1 = new proxyform.CustomBtn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button11 = new proxyform.CustomBtn();
            this.label19 = new System.Windows.Forms.Label();
            this.button2 = new proxyform.CustomBtn();
            this.button6 = new proxyform.CustomBtn();
            this.button5 = new proxyform.CustomBtn();
            this.button4 = new proxyform.CustomBtn();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Col_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_https = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_google = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.valid_chk = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.transparant_chk = new System.Windows.Forms.CheckBox();
            this.anon_chk = new System.Windows.Forms.CheckBox();
            this.elite_chk = new System.Windows.Forms.CheckBox();
            this.slow_chk = new System.Windows.Forms.CheckBox();
            this.fast_chk = new System.Windows.Forms.CheckBox();
            this.google_chk = new System.Windows.Forms.CheckBox();
            this.Statsgroup = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Statsgroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 100000;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(500, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel2.Text = "Memory usage : ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel2.Controls.Add(this.Statsgroup);
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(897, 497);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(897, 417);
            this.splitContainer2.SplitterDistance = 332;
            this.splitContainer2.TabIndex = 3;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.MinimumSize = new System.Drawing.Size(240, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer4.Panel1.Controls.Add(this.button7);
            this.splitContainer4.Panel1.Controls.Add(this.button9);
            this.splitContainer4.Panel1.Controls.Add(this.button8);
            this.splitContainer4.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel2);
            this.splitContainer4.Panel2.Controls.Add(this.button3);
            this.splitContainer4.Size = new System.Drawing.Size(332, 417);
            this.splitContainer4.SplitterDistance = 82;
            this.splitContainer4.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.ImageIndex = 12;
            this.button7.ImageList = this.imageList2;
            this.button7.Location = new System.Drawing.Point(231, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 75);
            this.button7.StartImgNumb = 12;
            this.button7.TabIndex = 8;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button7.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button7.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "startscrape.gif");
            this.imageList2.Images.SetKeyName(1, "startscrape-hover.gif");
            this.imageList2.Images.SetKeyName(2, "startscrape-press.gif");
            this.imageList2.Images.SetKeyName(3, "stopscrape.gif");
            this.imageList2.Images.SetKeyName(4, "stopscrape-hover.gif");
            this.imageList2.Images.SetKeyName(5, "stopscrape-press.gif");
            this.imageList2.Images.SetKeyName(6, "savelinks.gif");
            this.imageList2.Images.SetKeyName(7, "savelinks-hover.gif");
            this.imageList2.Images.SetKeyName(8, "savelinks-press.gif");
            this.imageList2.Images.SetKeyName(9, "importlinks.gif");
            this.imageList2.Images.SetKeyName(10, "importlinks-hover.gif");
            this.imageList2.Images.SetKeyName(11, "importlinks-press.gif");
            this.imageList2.Images.SetKeyName(12, "clearlinks.gif");
            this.imageList2.Images.SetKeyName(13, "clearlinks-hover.gif");
            this.imageList2.Images.SetKeyName(14, "clearlinks-press.gif");
            this.imageList2.Images.SetKeyName(15, "starttest.gif");
            this.imageList2.Images.SetKeyName(16, "starttest-hover.gif");
            this.imageList2.Images.SetKeyName(17, "starttest-press.gif");
            this.imageList2.Images.SetKeyName(18, "stoptest.gif");
            this.imageList2.Images.SetKeyName(19, "stoptest-hover.gif");
            this.imageList2.Images.SetKeyName(20, "stoptest-press.gif");
            this.imageList2.Images.SetKeyName(21, "saveproxy.gif");
            this.imageList2.Images.SetKeyName(22, "saveproxy-hover.gif");
            this.imageList2.Images.SetKeyName(23, "saveproxy-press.gif");
            this.imageList2.Images.SetKeyName(24, "importproxy.gif");
            this.imageList2.Images.SetKeyName(25, "importproxy-hover.gif");
            this.imageList2.Images.SetKeyName(26, "importproxy-press.gif");
            this.imageList2.Images.SetKeyName(27, "clearlist.gif");
            this.imageList2.Images.SetKeyName(28, "clearlist-hover.gif");
            this.imageList2.Images.SetKeyName(29, "clearlist-press.gif");
            this.imageList2.Images.SetKeyName(30, "clearmemory.gif");
            this.imageList2.Images.SetKeyName(31, "clearmemory-hover.gif");
            this.imageList2.Images.SetKeyName(32, "clearmemory-press.gif");
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.ImageIndex = 6;
            this.button9.ImageList = this.imageList2;
            this.button9.Location = new System.Drawing.Point(82, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 75);
            this.button9.StartImgNumb = 6;
            this.button9.TabIndex = 6;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button9.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button9.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button8.ImageIndex = 9;
            this.button8.ImageList = this.imageList2;
            this.button8.Location = new System.Drawing.Point(157, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 75);
            this.button8.StartImgNumb = 9;
            this.button8.TabIndex = 6;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button8.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button8.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(7, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.StartImgNumb = 0;
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button1.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button1.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 331);
            this.panel2.TabIndex = 4;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox2.DetectUrls = false;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(328, 327);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(343, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(561, 417);
            this.splitContainer3.SplitterDistance = 84;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button11);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.MaximumSize = new System.Drawing.Size(0, 84);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 84);
            this.panel3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(461, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Time";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button11.ImageIndex = 15;
            this.button11.ImageList = this.imageList2;
            this.button11.Location = new System.Drawing.Point(14, 3);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button11.Size = new System.Drawing.Size(75, 75);
            this.button11.StartImgNumb = 15;
            this.button11.TabIndex = 11;
            this.button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button11.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button11.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(455, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "00:00:00";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.ImageIndex = 30;
            this.button2.ImageList = this.imageList2;
            this.button2.Location = new System.Drawing.Point(313, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.StartImgNumb = 30;
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button2.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button2.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.ImageIndex = 27;
            this.button6.ImageList = this.imageList2;
            this.button6.Location = new System.Drawing.Point(238, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 75);
            this.button6.StartImgNumb = 27;
            this.button6.TabIndex = 9;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button6.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button6.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.ImageIndex = 24;
            this.button5.ImageList = this.imageList2;
            this.button5.Location = new System.Drawing.Point(163, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 75);
            this.button5.StartImgNumb = 24;
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button5.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button5.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.ImageIndex = 21;
            this.button4.ImageList = this.imageList2;
            this.button4.Location = new System.Drawing.Point(88, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.StartImgNumb = 21;
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown);
            this.button4.MouseEnter += new System.EventHandler(this.BtnHover);
            this.button4.MouseLeave += new System.EventHandler(this.BtnLeave);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer5.Panel2.Controls.Add(this.panel4);
            this.splitContainer5.Size = new System.Drawing.Size(561, 329);
            this.splitContainer5.SplitterDistance = 416;
            this.splitContainer5.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 329);
            this.panel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_ip,
            this.col_https,
            this.col_google,
            this.col_speed,
            this.col_type});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(412, 325);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Col_ip
            // 
            this.Col_ip.Text = "Ipport";
            this.Col_ip.Width = 169;
            // 
            // col_https
            // 
            this.col_https.Text = "Https";
            this.col_https.Width = 61;
            // 
            // col_google
            // 
            this.col_google.Text = "Google";
            // 
            // col_speed
            // 
            this.col_speed.Text = "Speed";
            // 
            // col_type
            // 
            this.col_type.Text = "Typeprox";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "false.gif");
            this.imageList1.Images.SetKeyName(1, "check.gif");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(129, 274);
            this.panel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.valid_chk);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.transparant_chk);
            this.groupBox1.Controls.Add(this.anon_chk);
            this.groupBox1.Controls.Add(this.elite_chk);
            this.groupBox1.Controls.Add(this.slow_chk);
            this.groupBox1.Controls.Add(this.fast_chk);
            this.groupBox1.Controls.Add(this.google_chk);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // valid_chk
            // 
            this.valid_chk.AutoSize = true;
            this.valid_chk.Checked = true;
            this.valid_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.valid_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valid_chk.ForeColor = System.Drawing.Color.White;
            this.valid_chk.Location = new System.Drawing.Point(15, 33);
            this.valid_chk.Name = "valid_chk";
            this.valid_chk.Size = new System.Drawing.Size(54, 17);
            this.valid_chk.TabIndex = 21;
            this.valid_chk.Text = "Valid";
            this.valid_chk.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(30, 209);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "Filter";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // transparant_chk
            // 
            this.transparant_chk.AutoSize = true;
            this.transparant_chk.Checked = true;
            this.transparant_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.transparant_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transparant_chk.ForeColor = System.Drawing.Color.White;
            this.transparant_chk.Location = new System.Drawing.Point(15, 171);
            this.transparant_chk.Name = "transparant_chk";
            this.transparant_chk.Size = new System.Drawing.Size(54, 17);
            this.transparant_chk.TabIndex = 19;
            this.transparant_chk.Text = "Lvl 3";
            this.transparant_chk.UseVisualStyleBackColor = true;
            // 
            // anon_chk
            // 
            this.anon_chk.AutoSize = true;
            this.anon_chk.Checked = true;
            this.anon_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.anon_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anon_chk.ForeColor = System.Drawing.Color.White;
            this.anon_chk.Location = new System.Drawing.Point(15, 148);
            this.anon_chk.Name = "anon_chk";
            this.anon_chk.Size = new System.Drawing.Size(54, 17);
            this.anon_chk.TabIndex = 18;
            this.anon_chk.Text = "Lvl 2";
            this.anon_chk.UseVisualStyleBackColor = true;
            // 
            // elite_chk
            // 
            this.elite_chk.AutoSize = true;
            this.elite_chk.Checked = true;
            this.elite_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.elite_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elite_chk.ForeColor = System.Drawing.Color.White;
            this.elite_chk.Location = new System.Drawing.Point(15, 125);
            this.elite_chk.Name = "elite_chk";
            this.elite_chk.Size = new System.Drawing.Size(54, 17);
            this.elite_chk.TabIndex = 17;
            this.elite_chk.Text = "Lvl 1";
            this.elite_chk.UseVisualStyleBackColor = true;
            // 
            // slow_chk
            // 
            this.slow_chk.AutoSize = true;
            this.slow_chk.Checked = true;
            this.slow_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.slow_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slow_chk.ForeColor = System.Drawing.Color.White;
            this.slow_chk.Location = new System.Drawing.Point(15, 102);
            this.slow_chk.Name = "slow_chk";
            this.slow_chk.Size = new System.Drawing.Size(93, 17);
            this.slow_chk.TabIndex = 16;
            this.slow_chk.Text = "Slow Speed";
            this.slow_chk.UseVisualStyleBackColor = true;
            // 
            // fast_chk
            // 
            this.fast_chk.AutoSize = true;
            this.fast_chk.Checked = true;
            this.fast_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fast_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fast_chk.ForeColor = System.Drawing.Color.White;
            this.fast_chk.Location = new System.Drawing.Point(15, 79);
            this.fast_chk.Name = "fast_chk";
            this.fast_chk.Size = new System.Drawing.Size(90, 17);
            this.fast_chk.TabIndex = 15;
            this.fast_chk.Text = "Fast Speed";
            this.fast_chk.UseVisualStyleBackColor = true;
            // 
            // google_chk
            // 
            this.google_chk.AutoSize = true;
            this.google_chk.Checked = true;
            this.google_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.google_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.google_chk.ForeColor = System.Drawing.Color.White;
            this.google_chk.Location = new System.Drawing.Point(15, 56);
            this.google_chk.Name = "google_chk";
            this.google_chk.Size = new System.Drawing.Size(66, 17);
            this.google_chk.TabIndex = 14;
            this.google_chk.Text = "Google";
            this.google_chk.UseVisualStyleBackColor = true;
            // 
            // Statsgroup
            // 
            this.Statsgroup.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Statsgroup.Controls.Add(this.label18);
            this.Statsgroup.Controls.Add(this.label17);
            this.Statsgroup.Controls.Add(this.label16);
            this.Statsgroup.Controls.Add(this.label15);
            this.Statsgroup.Controls.Add(this.label14);
            this.Statsgroup.Controls.Add(this.label13);
            this.Statsgroup.Controls.Add(this.label10);
            this.Statsgroup.Controls.Add(this.label9);
            this.Statsgroup.Controls.Add(this.label2);
            this.Statsgroup.Controls.Add(this.label1);
            this.Statsgroup.ForeColor = System.Drawing.Color.White;
            this.Statsgroup.Location = new System.Drawing.Point(454, 2);
            this.Statsgroup.Name = "Statsgroup";
            this.Statsgroup.Size = new System.Drawing.Size(381, 71);
            this.Statsgroup.TabIndex = 20;
            this.Statsgroup.TabStop = false;
            this.Statsgroup.Text = "Statistics";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(127, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(127, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(13, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "DoneThread";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(11, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Working Thread";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(289, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(289, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(208, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Bad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(207, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Good";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(288, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(207, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Proxy count:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(226, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "TimeOut";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.comboBox2.Location = new System.Drawing.Point(285, 49);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(57, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(87, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(15, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Bad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(226, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thread";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.comboBox1.Location = new System.Drawing.Point(286, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(87, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(87, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Good";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total List";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(897, 519);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(846, 546);
            this.Name = "MainForm";
            this.Text = "Proxy Fresh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Statsgroup.ResumeLayout(false);
            this.Statsgroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private proxyform.CustomBtn button9;
        private proxyform.CustomBtn button8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList imageList1;
        internal CustomBtn button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader Col_ip;
        private System.Windows.Forms.ColumnHeader col_https;
        private System.Windows.Forms.ColumnHeader col_google;
        private System.Windows.Forms.ColumnHeader col_speed;
        private System.Windows.Forms.ColumnHeader col_type;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel3;
        internal proxyform.CustomBtn button11;
        private proxyform.CustomBtn button2;
        private proxyform.CustomBtn button6;
        private proxyform.CustomBtn button5;
        private proxyform.CustomBtn button4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox Statsgroup;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox transparant_chk;
        private System.Windows.Forms.CheckBox anon_chk;
        private System.Windows.Forms.CheckBox elite_chk;
        private System.Windows.Forms.CheckBox slow_chk;
        private System.Windows.Forms.CheckBox fast_chk;
        private System.Windows.Forms.CheckBox google_chk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private proxyform.CustomBtn button7;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox valid_chk;
	}
}
