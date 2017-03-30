namespace OrderADO
{
    partial class FormEditPoleName
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Имя поля";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 18;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Location = new System.Drawing.Point(90, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Применить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.Location = new System.Drawing.Point(253, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Отмена";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // FormEditPoleName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 133);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormEditPoleName";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditPoleName";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEditPoleName_FormClosed);
            this.Shown += new System.EventHandler(this.FormEditPoleName_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}