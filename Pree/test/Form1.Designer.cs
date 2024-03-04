namespace Pree
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_crtfolder = new System.Windows.Forms.Button();
            this.Btn_save = new System.Windows.Forms.Button();
            this.CreateMail = new System.Windows.Forms.Button();
            this.chkUrl = new System.Windows.Forms.Timer(this.components);
            this.btn_load = new System.Windows.Forms.Button();
            this.Dataword = new System.Windows.Forms.DataGridView();
            this.TimerSerch = new System.Windows.Forms.Timer(this.components);
            this.lbl_cost = new System.Windows.Forms.Label();
            this.EnailC = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dataword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnailC)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(643, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(301, 218);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_crtfolder
            // 
            this.btn_crtfolder.Location = new System.Drawing.Point(643, 236);
            this.btn_crtfolder.Name = "btn_crtfolder";
            this.btn_crtfolder.Size = new System.Drawing.Size(90, 29);
            this.btn_crtfolder.TabIndex = 1;
            this.btn_crtfolder.Text = "CreateFolder";
            this.btn_crtfolder.UseVisualStyleBackColor = true;
            this.btn_crtfolder.Click += new System.EventHandler(this.Btn_crtfolder_Click);
            // 
            // Btn_save
            // 
            this.Btn_save.Location = new System.Drawing.Point(12, 433);
            this.Btn_save.Name = "Btn_save";
            this.Btn_save.Size = new System.Drawing.Size(96, 62);
            this.Btn_save.TabIndex = 2;
            this.Btn_save.Text = "Start Save Secc";
            this.Btn_save.UseVisualStyleBackColor = true;
            this.Btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // CreateMail
            // 
            this.CreateMail.Location = new System.Drawing.Point(704, 472);
            this.CreateMail.Name = "CreateMail";
            this.CreateMail.Size = new System.Drawing.Size(240, 23);
            this.CreateMail.TabIndex = 3;
            this.CreateMail.Text = "Create Mail";
            this.CreateMail.UseVisualStyleBackColor = true;
            this.CreateMail.Click += new System.EventHandler(this.Button1_Click);
            // 
            // chkUrl
            // 
            this.chkUrl.Interval = 3000;
            this.chkUrl.Tick += new System.EventHandler(this.ChkUrl_Tick);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(114, 433);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(104, 62);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.Btn_load_Click);
            // 
            // Dataword
            // 
            this.Dataword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dataword.Location = new System.Drawing.Point(390, 10);
            this.Dataword.Name = "Dataword";
            this.Dataword.Size = new System.Drawing.Size(240, 220);
            this.Dataword.TabIndex = 5;
            // 
            // TimerSerch
            // 
            this.TimerSerch.Interval = 10000;
            this.TimerSerch.Tick += new System.EventHandler(this.TimerSerch_Tick);
            // 
            // lbl_cost
            // 
            this.lbl_cost.AutoSize = true;
            this.lbl_cost.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cost.Location = new System.Drawing.Point(24, 21);
            this.lbl_cost.Name = "lbl_cost";
            this.lbl_cost.Size = new System.Drawing.Size(114, 42);
            this.lbl_cost.TabIndex = 6;
            this.lbl_cost.Text = "label1";
            // 
            // EnailC
            // 
            this.EnailC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EnailC.Location = new System.Drawing.Point(704, 316);
            this.EnailC.Name = "EnailC";
            this.EnailC.Size = new System.Drawing.Size(240, 150);
            this.EnailC.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load Form @";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EnailC);
            this.Controls.Add(this.lbl_cost);
            this.Controls.Add(this.Dataword);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.CreateMail);
            this.Controls.Add(this.Btn_save);
            this.Controls.Add(this.btn_crtfolder);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dataword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnailC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_crtfolder;
        private System.Windows.Forms.Button Btn_save;
        private System.Windows.Forms.Button CreateMail;
        private System.Windows.Forms.Timer chkUrl;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.DataGridView Dataword;
        private System.Windows.Forms.Timer TimerSerch;
        private System.Windows.Forms.Label lbl_cost;
        private System.Windows.Forms.DataGridView EnailC;
        private System.Windows.Forms.Button button1;
    }
}

