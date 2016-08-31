namespace FileScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_scan = new System.Windows.Forms.Button();
            this.lbl_display = new System.Windows.Forms.Label();
            this.btn_about = new System.Windows.Forms.Button();
            this.nud_layer = new System.Windows.Forms.NumericUpDown();
            this.lbl_layer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_layer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_scan
            // 
            this.btn_scan.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_scan.Location = new System.Drawing.Point(72, 160);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(131, 63);
            this.btn_scan.TabIndex = 0;
            this.btn_scan.Text = "start scan!";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // lbl_display
            // 
            this.lbl_display.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_display.Location = new System.Drawing.Point(12, 24);
            this.lbl_display.Name = "lbl_display";
            this.lbl_display.Size = new System.Drawing.Size(260, 66);
            this.lbl_display.TabIndex = 1;
            this.lbl_display.Text = "place me in the root dirctory and press the button to start";
            this.lbl_display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_about
            // 
            this.btn_about.BackColor = System.Drawing.Color.Transparent;
            this.btn_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_about.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_about.Location = new System.Drawing.Point(221, 226);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(51, 23);
            this.btn_about.TabIndex = 2;
            this.btn_about.Text = "about";
            this.btn_about.UseVisualStyleBackColor = false;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // nud_layer
            // 
            this.nud_layer.Location = new System.Drawing.Point(173, 120);
            this.nud_layer.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_layer.Name = "nud_layer";
            this.nud_layer.Size = new System.Drawing.Size(58, 21);
            this.nud_layer.TabIndex = 3;
            // 
            // lbl_layer
            // 
            this.lbl_layer.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_layer.Location = new System.Drawing.Point(22, 118);
            this.lbl_layer.Name = "lbl_layer";
            this.lbl_layer.Size = new System.Drawing.Size(145, 37);
            this.lbl_layer.TabIndex = 4;
            this.lbl_layer.Text = "layers to scan:  (0 is no limit)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbl_layer);
            this.Controls.Add(this.nud_layer);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.lbl_display);
            this.Controls.Add(this.btn_scan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "file scanner";
            ((System.ComponentModel.ISupportInitialize)(this.nud_layer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.Label lbl_display;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.NumericUpDown nud_layer;
        private System.Windows.Forms.Label lbl_layer;
    }
}

