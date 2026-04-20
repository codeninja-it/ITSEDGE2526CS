namespace App04
{
    partial class FrmSostituisci
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
            label1 = new Label();
            label2 = new Label();
            btnDa = new Button();
            btnA = new Button();
            btnAnnulla = new Button();
            btnApplica = new Button();
            dlgColore = new ColorDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 0;
            label1.Text = "Trova";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 1;
            label2.Text = "Sostituisci";
            // 
            // btnDa
            // 
            btnDa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDa.Location = new Point(138, 12);
            btnDa.Name = "btnDa";
            btnDa.Size = new Size(342, 46);
            btnDa.TabIndex = 2;
            btnDa.UseVisualStyleBackColor = true;
            btnDa.Click += btnDa_Click;
            // 
            // btnA
            // 
            btnA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnA.Location = new Point(138, 77);
            btnA.Name = "btnA";
            btnA.Size = new Size(342, 46);
            btnA.TabIndex = 3;
            btnA.UseVisualStyleBackColor = true;
            btnA.Click += btnA_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnulla.Location = new Point(336, 227);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(144, 46);
            btnAnnulla.TabIndex = 4;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // btnApplica
            // 
            btnApplica.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApplica.Location = new Point(186, 227);
            btnApplica.Name = "btnApplica";
            btnApplica.Size = new Size(144, 46);
            btnApplica.TabIndex = 5;
            btnApplica.Text = "Applica";
            btnApplica.UseVisualStyleBackColor = true;
            btnApplica.Click += btnApplica_Click;
            // 
            // FrmSostituisci
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 285);
            Controls.Add(btnApplica);
            Controls.Add(btnAnnulla);
            Controls.Add(btnA);
            Controls.Add(btnDa);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSostituisci";
            Text = "FrmSostituisci";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnDa;
        private Button btnA;
        private Button btnAnnulla;
        private Button btnApplica;
        private ColorDialog dlgColore;
    }
}