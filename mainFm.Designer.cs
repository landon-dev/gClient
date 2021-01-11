
namespace gClient
{
    partial class mainFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFm));
            this.headPnl = new System.Windows.Forms.Panel();
            this.bodyPnl = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pinBtn = new System.Windows.Forms.Button();
            this.minBtn = new System.Windows.Forms.Button();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.classicLbl = new System.Windows.Forms.Label();
            this.eraLbl = new System.Windows.Forms.Label();
            this.zoneLbl = new System.Windows.Forms.Label();
            this.westLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headPnl.SuspendLayout();
            this.bodyPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // headPnl
            // 
            this.headPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.headPnl.Controls.Add(this.nameLbl);
            this.headPnl.Controls.Add(this.logoPic);
            this.headPnl.Controls.Add(this.minBtn);
            this.headPnl.Controls.Add(this.pinBtn);
            this.headPnl.Controls.Add(this.closeBtn);
            this.headPnl.Cursor = System.Windows.Forms.Cursors.Default;
            this.headPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPnl.Location = new System.Drawing.Point(0, 0);
            this.headPnl.Name = "headPnl";
            this.headPnl.Size = new System.Drawing.Size(559, 21);
            this.headPnl.TabIndex = 0;
            this.headPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPnl_MouseDown);
            // 
            // bodyPnl
            // 
            this.bodyPnl.Controls.Add(this.label2);
            this.bodyPnl.Controls.Add(this.westLbl);
            this.bodyPnl.Controls.Add(this.zoneLbl);
            this.bodyPnl.Controls.Add(this.eraLbl);
            this.bodyPnl.Controls.Add(this.classicLbl);
            this.bodyPnl.Controls.Add(this.label1);
            this.bodyPnl.Controls.Add(this.label6);
            this.bodyPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPnl.Location = new System.Drawing.Point(0, 21);
            this.bodyPnl.Name = "bodyPnl";
            this.bodyPnl.Size = new System.Drawing.Size(559, 328);
            this.bodyPnl.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(533, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(26, 21);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // pinBtn
            // 
            this.pinBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pinBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.pinBtn.FlatAppearance.BorderSize = 0;
            this.pinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pinBtn.Image = ((System.Drawing.Image)(resources.GetObject("pinBtn.Image")));
            this.pinBtn.Location = new System.Drawing.Point(507, 0);
            this.pinBtn.Name = "pinBtn";
            this.pinBtn.Size = new System.Drawing.Size(26, 21);
            this.pinBtn.TabIndex = 5;
            this.pinBtn.UseVisualStyleBackColor = true;
            this.pinBtn.Click += new System.EventHandler(this.pinBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Image = ((System.Drawing.Image)(resources.GetObject("minBtn.Image")));
            this.minBtn.Location = new System.Drawing.Point(481, 0);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(26, 21);
            this.minBtn.TabIndex = 6;
            this.minBtn.UseVisualStyleBackColor = true;
            // 
            // logoPic
            // 
            this.logoPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(0, 0);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(20, 21);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            this.logoPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoPic_MouseDown);
            // 
            // nameLbl
            // 
            this.nameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.ForeColor = System.Drawing.Color.White;
            this.nameLbl.Location = new System.Drawing.Point(20, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(52, 21);
            this.nameLbl.TabIndex = 7;
            this.nameLbl.Text = "gClient";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanks for using gClient, select one of\r\nthe servers bellow to continue!";
            // 
            // classicLbl
            // 
            this.classicLbl.AutoSize = true;
            this.classicLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.classicLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.classicLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.classicLbl.Location = new System.Drawing.Point(32, 93);
            this.classicLbl.Name = "classicLbl";
            this.classicLbl.Size = new System.Drawing.Size(146, 21);
            this.classicLbl.TabIndex = 1;
            this.classicLbl.Text = "GraalOnline Classic";
            this.classicLbl.Click += new System.EventHandler(this.classicLbl_Click);
            // 
            // eraLbl
            // 
            this.eraLbl.AutoSize = true;
            this.eraLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.eraLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.eraLbl.Location = new System.Drawing.Point(32, 125);
            this.eraLbl.Name = "eraLbl";
            this.eraLbl.Size = new System.Drawing.Size(120, 21);
            this.eraLbl.TabIndex = 2;
            this.eraLbl.Text = "GraalOnline Era";
            this.eraLbl.Click += new System.EventHandler(this.eraLbl_Click);
            // 
            // zoneLbl
            // 
            this.zoneLbl.AutoSize = true;
            this.zoneLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zoneLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.zoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zoneLbl.Location = new System.Drawing.Point(32, 158);
            this.zoneLbl.Name = "zoneLbl";
            this.zoneLbl.Size = new System.Drawing.Size(135, 21);
            this.zoneLbl.TabIndex = 3;
            this.zoneLbl.Text = "GraalOnline Zone";
            this.zoneLbl.Click += new System.EventHandler(this.zoneLbl_Click);
            // 
            // westLbl
            // 
            this.westLbl.AutoSize = true;
            this.westLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.westLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.westLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.westLbl.Location = new System.Drawing.Point(32, 194);
            this.westLbl.Name = "westLbl";
            this.westLbl.Size = new System.Drawing.Size(155, 21);
            this.westLbl.TabIndex = 4;
            this.westLbl.Text = "GraalOnline Ol\'West";
            this.westLbl.Click += new System.EventHandler(this.westLbl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.label6.Location = new System.Drawing.Point(468, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Team 774";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hi Zeavenly ;)";
            // 
            // mainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(559, 350);
            this.Controls.Add(this.bodyPnl);
            this.Controls.Add(this.headPnl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainFm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFm_FormClosing);
            this.Resize += new System.EventHandler(this.mainFm_Resize);
            this.headPnl.ResumeLayout(false);
            this.bodyPnl.ResumeLayout(false);
            this.bodyPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel headPnl;
        public System.Windows.Forms.Panel bodyPnl;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Button pinBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.PictureBox logoPic;
        public System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label westLbl;
        private System.Windows.Forms.Label zoneLbl;
        private System.Windows.Forms.Label eraLbl;
        private System.Windows.Forms.Label classicLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

