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
            trkTolleranza = new TrackBar();
            label3 = new Label();
            chkPositivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)trkTolleranza).BeginInit();
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
            label2.Location = new Point(12, 167);
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
            btnDa.Size = new Size(707, 46);
            btnDa.TabIndex = 2;
            btnDa.UseVisualStyleBackColor = true;
            btnDa.Click += btnDa_Click;
            // 
            // btnA
            // 
            btnA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnA.Location = new Point(138, 160);
            btnA.Name = "btnA";
            btnA.Size = new Size(707, 46);
            btnA.TabIndex = 3;
            btnA.UseVisualStyleBackColor = true;
            btnA.Click += btnA_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnulla.Location = new Point(701, 443);
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
            btnApplica.Location = new Point(551, 443);
            btnApplica.Name = "btnApplica";
            btnApplica.Size = new Size(144, 46);
            btnApplica.TabIndex = 5;
            btnApplica.Text = "Applica";
            btnApplica.UseVisualStyleBackColor = true;
            btnApplica.Click += btnApplica_Click;
            // 
            // trkTolleranza
            // 
            trkTolleranza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trkTolleranza.Location = new Point(138, 64);
            trkTolleranza.Maximum = 360;
            trkTolleranza.Name = "trkTolleranza";
            trkTolleranza.Size = new Size(707, 90);
            trkTolleranza.TabIndex = 6;
            trkTolleranza.Value = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 64);
            label3.Name = "label3";
            label3.Size = new Size(121, 32);
            label3.TabIndex = 7;
            label3.Text = "Tolleranza";
            // 
            // chkPositivo
            // 
            chkPositivo.AutoSize = true;
            chkPositivo.Location = new Point(138, 212);
            chkPositivo.Name = "chkPositivo";
            chkPositivo.Size = new Size(236, 36);
            chkPositivo.TabIndex = 8;
            chkPositivo.Text = "Controllo positivo";
            chkPositivo.UseVisualStyleBackColor = true;
            // 
            // FrmSostituisci
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 501);
            Controls.Add(chkPositivo);
            Controls.Add(label3);
            Controls.Add(trkTolleranza);
            Controls.Add(btnApplica);
            Controls.Add(btnAnnulla);
            Controls.Add(btnA);
            Controls.Add(btnDa);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSostituisci";
            Text = "FrmSostituisci";
            ((System.ComponentModel.ISupportInitialize)trkTolleranza).EndInit();
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
        private TrackBar trkTolleranza;
        private Label label3;
        private CheckBox chkPositivo;
    }
}