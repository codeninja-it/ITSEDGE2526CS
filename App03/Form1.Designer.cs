namespace App03
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
            btnApri = new Button();
            lstContatti = new ListBox();
            SuspendLayout();
            // 
            // btnApri
            // 
            btnApri.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApri.Location = new Point(980, 827);
            btnApri.Name = "btnApri";
            btnApri.Size = new Size(122, 48);
            btnApri.TabIndex = 0;
            btnApri.Text = "+";
            btnApri.UseVisualStyleBackColor = true;
            btnApri.Click += btnApri_Click;
            // 
            // lstContatti
            // 
            lstContatti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstContatti.FormattingEnabled = true;
            lstContatti.IntegralHeight = false;
            lstContatti.Location = new Point(28, 12);
            lstContatti.Name = "lstContatti";
            lstContatti.Size = new Size(1074, 809);
            lstContatti.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 895);
            Controls.Add(lstContatti);
            Controls.Add(btnApri);
            Name = "Form1";
            Text = "Rubrica";
            ResumeLayout(false);
        }

        #endregion

        private Button btnApri;
        private ListBox lstContatti;
    }
}
