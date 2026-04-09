namespace App04
{
    partial class FormImpostazioni
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
            btnAnnulla = new Button();
            btnSalva = new Button();
            label1 = new Label();
            label2 = new Label();
            btnColore = new Button();
            trkTratto = new TrackBar();
            trkArrotindamento = new TrackBar();
            label3 = new Label();
            dlgColore = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)trkTratto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkArrotindamento).BeginInit();
            SuspendLayout();
            // 
            // btnAnnulla
            // 
            btnAnnulla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnulla.Location = new Point(538, 297);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(150, 46);
            btnAnnulla.TabIndex = 0;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // btnSalva
            // 
            btnSalva.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalva.Location = new Point(382, 297);
            btnSalva.Name = "btnSalva";
            btnSalva.Size = new Size(150, 46);
            btnSalva.TabIndex = 1;
            btnSalva.Text = "Salva";
            btnSalva.UseVisualStyleBackColor = true;
            btnSalva.Click += btnSalva_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(158, 32);
            label1.TabIndex = 2;
            label1.Text = "Colore penna";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 89);
            label2.Name = "label2";
            label2.Size = new Size(185, 32);
            label2.TabIndex = 3;
            label2.Text = "Larghezza tratto";
            // 
            // btnColore
            // 
            btnColore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnColore.Location = new Point(207, 26);
            btnColore.Name = "btnColore";
            btnColore.Size = new Size(481, 46);
            btnColore.TabIndex = 4;
            btnColore.UseVisualStyleBackColor = true;
            btnColore.Click += btnColore_Click;
            // 
            // trkTratto
            // 
            trkTratto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trkTratto.Location = new Point(207, 89);
            trkTratto.Name = "trkTratto";
            trkTratto.Size = new Size(481, 90);
            trkTratto.TabIndex = 5;
            // 
            // trkArrotindamento
            // 
            trkArrotindamento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trkArrotindamento.Location = new Point(207, 185);
            trkArrotindamento.Name = "trkArrotindamento";
            trkArrotindamento.Size = new Size(481, 90);
            trkArrotindamento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 185);
            label3.Name = "label3";
            label3.Size = new Size(191, 32);
            label3.TabIndex = 7;
            label3.Text = "Arrotondamento";
            // 
            // FormImpostazioni
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 355);
            Controls.Add(label3);
            Controls.Add(trkArrotindamento);
            Controls.Add(trkTratto);
            Controls.Add(btnColore);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSalva);
            Controls.Add(btnAnnulla);
            Name = "FormImpostazioni";
            Text = "Impostazioni";
            ((System.ComponentModel.ISupportInitialize)trkTratto).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkArrotindamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnnulla;
        private Button btnSalva;
        private Label label1;
        private Label label2;
        private Button btnColore;
        private TrackBar trkTratto;
        private TrackBar trkArrotindamento;
        private Label label3;
        private ColorDialog dlgColore;
    }
}