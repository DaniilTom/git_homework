namespace Lesson_8
{
    partial class SetPassword
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
            this.numeric1 = new System.Windows.Forms.NumericUpDown();
            this.numeric2 = new System.Windows.Forms.NumericUpDown();
            this.numeric3 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numeric4 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric4)).BeginInit();
            this.SuspendLayout();
            // 
            // numeric1
            // 
            this.numeric1.Location = new System.Drawing.Point(8, 33);
            this.numeric1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numeric1.Name = "numeric1";
            this.numeric1.Size = new System.Drawing.Size(39, 20);
            this.numeric1.TabIndex = 0;
            // 
            // numeric2
            // 
            this.numeric2.Location = new System.Drawing.Point(53, 33);
            this.numeric2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numeric2.Name = "numeric2";
            this.numeric2.Size = new System.Drawing.Size(39, 20);
            this.numeric2.TabIndex = 0;
            // 
            // numeric3
            // 
            this.numeric3.Location = new System.Drawing.Point(98, 33);
            this.numeric3.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numeric3.Name = "numeric3";
            this.numeric3.Size = new System.Drawing.Size(39, 20);
            this.numeric3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите пароль:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numeric4
            // 
            this.numeric4.Location = new System.Drawing.Point(143, 33);
            this.numeric4.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numeric4.Name = "numeric4";
            this.numeric4.Size = new System.Drawing.Size(39, 20);
            this.numeric4.TabIndex = 0;
            // 
            // SetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric4);
            this.Controls.Add(this.numeric3);
            this.Controls.Add(this.numeric2);
            this.Controls.Add(this.numeric1);
            this.Name = "SetPassword";
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numeric1;
        private System.Windows.Forms.NumericUpDown numeric2;
        private System.Windows.Forms.NumericUpDown numeric3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numeric4;
    }
}