namespace TransferMate
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
            panel1 = new Panel();
            button2 = new Button();
            IpAdressLbl = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            button1 = new Button();
            textBox4 = new TextBox();
            label5 = new Label();
            dosyalarPaneli = new FlowLayoutPanel();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            myMatesPanel = new FlowLayoutPanel();
            KisiAdi = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            istedurdurbtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(IpAdressLbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(548, 28);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown_1;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp_1;
            // 
            // button2
            // 
            button2.Location = new Point(500, 2);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(38, 23);
            button2.TabIndex = 1;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // IpAdressLbl
            // 
            IpAdressLbl.AutoSize = true;
            IpAdressLbl.ForeColor = SystemColors.HotTrack;
            IpAdressLbl.Location = new Point(10, 7);
            IpAdressLbl.Name = "IpAdressLbl";
            IpAdressLbl.Size = new Size(17, 15);
            IpAdressLbl.TabIndex = 0;
            IpAdressLbl.Text = "Ip";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(307, 50);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(307, 92);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(159, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(308, 32);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "Ip Adress";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dosyalarPaneli);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(myMatesPanel);
            panel2.Controls.Add(KisiAdi);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(textBox2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 28);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(548, 522);
            panel2.TabIndex = 4;
            // 
            // button5
            // 
            button5.BackColor = Color.CadetBlue;
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(259, 49);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(24, 22);
            button5.TabIndex = 15;
            button5.Text = "D";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(67, 47);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(24, 22);
            button1.TabIndex = 1;
            button1.Text = "R";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(97, 48);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(156, 23);
            textBox4.TabIndex = 14;
            textBox4.KeyUp += textBox4_KeyUp;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 50);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 13;
            label5.Text = "Dosyalar";
            // 
            // dosyalarPaneli
            // 
            dosyalarPaneli.BackColor = SystemColors.InactiveBorder;
            dosyalarPaneli.Location = new Point(9, 73);
            dosyalarPaneli.Margin = new Padding(3, 2, 3, 2);
            dosyalarPaneli.Name = "dosyalarPaneli";
            dosyalarPaneli.Size = new Size(278, 441);
            dosyalarPaneli.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(308, 207);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 11;
            label4.Text = "My Mates";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 115);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 10;
            label3.Text = "Seçili Dosya";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(305, 134);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(161, 23);
            textBox3.TabIndex = 9;
            // 
            // button4
            // 
            button4.Location = new Point(305, 172);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(159, 22);
            button4.TabIndex = 8;
            button4.Text = "Gönder";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(471, 134);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(58, 22);
            button3.TabIndex = 7;
            button3.Text = "Seç";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // myMatesPanel
            // 
            myMatesPanel.BackColor = SystemColors.InactiveBorder;
            myMatesPanel.Location = new Point(306, 224);
            myMatesPanel.Margin = new Padding(3, 2, 3, 2);
            myMatesPanel.Name = "myMatesPanel";
            myMatesPanel.Size = new Size(231, 290);
            myMatesPanel.TabIndex = 6;
            // 
            // KisiAdi
            // 
            KisiAdi.AutoSize = true;
            KisiAdi.Location = new Point(307, 73);
            KisiAdi.Name = "KisiAdi";
            KisiAdi.Size = new Size(43, 15);
            KisiAdi.TabIndex = 5;
            KisiAdi.Text = "KişiAdi";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(548, 29);
            panel3.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.GradientActiveCaption;
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(308, 0);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 29);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(istedurdurbtn);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(287, 29);
            panel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 8);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 0;
            label2.Text = "Dosya İste";
            // 
            // istedurdurbtn
            // 
            istedurdurbtn.BackColor = Color.SteelBlue;
            istedurdurbtn.ForeColor = SystemColors.Control;
            istedurdurbtn.Location = new Point(151, 4);
            istedurdurbtn.Margin = new Padding(3, 2, 3, 2);
            istedurdurbtn.Name = "istedurdurbtn";
            istedurdurbtn.Size = new Size(70, 22);
            istedurdurbtn.TabIndex = 0;
            istedurdurbtn.Text = "İste";
            istedurdurbtn.UseVisualStyleBackColor = false;
            istedurdurbtn.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(548, 550);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TransferMate V 0.9";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label IpAdressLbl;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Panel panel2;
        private TextBox textBox4;
        private Label label5;
        private FlowLayoutPanel dosyalarPaneli;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private Button button4;
        private Button button3;
        private FlowLayoutPanel myMatesPanel;
        private Label KisiAdi;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Label label2;
        private Button istedurdurbtn;
        private Button button1;
        private Button button5;
    }
}