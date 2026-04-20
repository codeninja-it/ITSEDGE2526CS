namespace App04
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
            statusStrip1 = new StatusStrip();
            lblCoordinate = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnuNuovo = new ToolStripMenuItem();
            mnuApri = new ToolStripMenuItem();
            mnuSalva = new ToolStripMenuItem();
            mnuEsci = new ToolStripMenuItem();
            modificaToolStripMenuItem = new ToolStripMenuItem();
            mnuSostituisci = new ToolStripMenuItem();
            pctImmagine = new PictureBox();
            dlgApri = new OpenFileDialog();
            dlgSalva = new SaveFileDialog();
            lstLivelli = new ListBox();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctImmagine).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCoordinate });
            statusStrip1.Location = new Point(0, 981);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1250, 42);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblCoordinate
            // 
            lblCoordinate.Name = "lblCoordinate";
            lblCoordinate.Size = new Size(64, 32);
            lblCoordinate.Text = "0 - 0";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, modificaToolStripMenuItem, mnuSostituisci });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1250, 40);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuNuovo, mnuApri, mnuSalva, mnuEsci });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // mnuNuovo
            // 
            mnuNuovo.Name = "mnuNuovo";
            mnuNuovo.Size = new Size(359, 44);
            mnuNuovo.Text = "Nuovo";
            mnuNuovo.Click += mnuNuovo_Click;
            // 
            // mnuApri
            // 
            mnuApri.Name = "mnuApri";
            mnuApri.Size = new Size(359, 44);
            mnuApri.Text = "Apri";
            mnuApri.Click += mnuApri_Click;
            // 
            // mnuSalva
            // 
            mnuSalva.Name = "mnuSalva";
            mnuSalva.Size = new Size(359, 44);
            mnuSalva.Text = "Salva";
            mnuSalva.Click += mnuSalva_Click;
            // 
            // mnuEsci
            // 
            mnuEsci.Name = "mnuEsci";
            mnuEsci.Size = new Size(359, 44);
            mnuEsci.Text = "Esci";
            mnuEsci.Click += mnuEsci_Click;
            // 
            // modificaToolStripMenuItem
            // 
            modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            modificaToolStripMenuItem.Size = new Size(127, 36);
            modificaToolStripMenuItem.Text = "Modifica";
            modificaToolStripMenuItem.Click += modificaToolStripMenuItem_Click;
            // 
            // mnuSostituisci
            // 
            mnuSostituisci.Name = "mnuSostituisci";
            mnuSostituisci.Size = new Size(140, 36);
            mnuSostituisci.Text = "Sostituisci";
            mnuSostituisci.Click += mnuSostituisci_Click;
            // 
            // pctImmagine
            // 
            pctImmagine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pctImmagine.BackColor = Color.Black;
            pctImmagine.Location = new Point(364, 42);
            pctImmagine.Name = "pctImmagine";
            pctImmagine.Size = new Size(886, 939);
            pctImmagine.SizeMode = PictureBoxSizeMode.StretchImage;
            pctImmagine.TabIndex = 2;
            pctImmagine.TabStop = false;
            pctImmagine.MouseMove += PctImmagine_MouseMove;
            // 
            // dlgApri
            // 
            dlgApri.FileName = "openFileDialog1";
            dlgApri.Title = "Seleziona immagine...";
            // 
            // lstLivelli
            // 
            lstLivelli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstLivelli.FormattingEnabled = true;
            lstLivelli.IntegralHeight = false;
            lstLivelli.Location = new Point(0, 43);
            lstLivelli.Name = "lstLivelli";
            lstLivelli.Size = new Size(358, 938);
            lstLivelli.TabIndex = 3;
            lstLivelli.SelectedIndexChanged += lstLivelli_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 1023);
            Controls.Add(lstLivelli);
            Controls.Add(pctImmagine);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctImmagine).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCoordinate;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnuApri;
        private ToolStripMenuItem mnuSalva;
        private ToolStripMenuItem mnuEsci;
        private ToolStripMenuItem modificaToolStripMenuItem;
        private ToolStripMenuItem mnuNuovo;
        private PictureBox pctImmagine;
        private OpenFileDialog dlgApri;
        private SaveFileDialog dlgSalva;
        private ToolStripMenuItem mnuSostituisci;
        private ListBox lstLivelli;
    }
}
