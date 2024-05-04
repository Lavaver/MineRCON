namespace MineRCON.NET
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            textBox4 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            groupBox3 = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            复制选中日志ToolStripMenuItem = new ToolStripMenuItem();
            删除选中日志ToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(781, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 589);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "连接配置";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(24, 141);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(276, 27);
            textBox4.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 109);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 6;
            label3.Text = "目标端口";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 219);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "不会显示密码，确认正确即可";
            textBox3.Size = new Size(276, 27);
            textBox3.TabIndex = 5;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 185);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 4;
            label2.Text = "RCON 密码";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(24, 68);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "例如：xxx.xxx.xxx.xxx";
            textBox2.Size = new Size(276, 27);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 2;
            label1.Text = "连接地址";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(24, 548);
            button3.Name = "button3";
            button3.Size = new Size(276, 29);
            button3.TabIndex = 1;
            button3.Text = "断开连接";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(24, 513);
            button2.Name = "button2";
            button2.Size = new Size(276, 29);
            button2.TabIndex = 0;
            button2.Text = "启动连接";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(listBox1);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(763, 589);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "控制台";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(645, 549);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "发送";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 550);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "命令输入区域";
            textBox1.Size = new Size(616, 27);
            textBox1.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.FormattingEnabled = true;
            listBox1.ImeMode = ImeMode.NoControl;
            listBox1.Location = new Point(23, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(716, 504);
            listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 复制选中日志ToolStripMenuItem, 删除选中日志ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(169, 52);
            // 
            // 复制选中日志ToolStripMenuItem
            // 
            复制选中日志ToolStripMenuItem.Name = "复制选中日志ToolStripMenuItem";
            复制选中日志ToolStripMenuItem.Size = new Size(168, 24);
            复制选中日志ToolStripMenuItem.Text = "复制选中日志";
            复制选中日志ToolStripMenuItem.Click += 复制选中日志ToolStripMenuItem_Click;
            // 
            // 删除选中日志ToolStripMenuItem
            // 
            删除选中日志ToolStripMenuItem.Name = "删除选中日志ToolStripMenuItem";
            删除选中日志ToolStripMenuItem.Size = new Size(168, 24);
            删除选中日志ToolStripMenuItem.Text = "删除选中日志";
            删除选中日志ToolStripMenuItem.Click += 删除选中日志ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 613);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MineRCON";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private ListBox listBox1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private Button button3;
        private TextBox textBox4;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 复制选中日志ToolStripMenuItem;
        private ToolStripMenuItem 删除选中日志ToolStripMenuItem;
    }
}
