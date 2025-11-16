namespace Statki
{
    partial class Serwer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonDolacz = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.buttonWyslij = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWiadomosc = new System.Windows.Forms.TextBox();
            this.panelMojaPlanszy = new System.Windows.Forms.Panel();
            this.panelPlanszaPrzeciwnika = new System.Windows.Forms.Panel();
            this.lblTura = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCzasGry = new System.Windows.Forms.Label();
            this.timerGry = new System.Windows.Forms.Timer(this.components);
            this.buttonPoddaj = new System.Windows.Forms.Button();
            this.buttonOrientacja = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDolacz
            // 
            this.buttonDolacz.Location = new System.Drawing.Point(9, 55);
            this.buttonDolacz.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDolacz.Name = "buttonDolacz";
            this.buttonDolacz.Size = new System.Drawing.Size(66, 30);
            this.buttonDolacz.TabIndex = 0;
            this.buttonDolacz.Text = "Połącz";
            this.buttonDolacz.UseVisualStyleBackColor = true;
            this.buttonDolacz.Click += new System.EventHandler(this.buttonDolacz_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(80, 55);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(61, 30);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(9, 10);
            this.txtAdres.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(133, 20);
            this.txtAdres.TabIndex = 2;
            this.txtAdres.TextChanged += new System.EventHandler(this.txtAdres_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(9, 32);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(133, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(9, 90);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(133, 261);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = "";
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // buttonWyslij
            // 
            this.buttonWyslij.Location = new System.Drawing.Point(9, 378);
            this.buttonWyslij.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWyslij.Name = "buttonWyslij";
            this.buttonWyslij.Size = new System.Drawing.Size(132, 26);
            this.buttonWyslij.TabIndex = 5;
            this.buttonWyslij.Text = "Wyślij";
            this.buttonWyslij.UseVisualStyleBackColor = true;
            this.buttonWyslij.Click += new System.EventHandler(this.buttonWyslij_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(9, 409);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(132, 26);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Graj!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Visible = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port";
            // 
            // txtWiadomosc
            // 
            this.txtWiadomosc.Location = new System.Drawing.Point(9, 355);
            this.txtWiadomosc.Margin = new System.Windows.Forms.Padding(2);
            this.txtWiadomosc.Name = "txtWiadomosc";
            this.txtWiadomosc.Size = new System.Drawing.Size(133, 20);
            this.txtWiadomosc.TabIndex = 9;
            this.txtWiadomosc.TextChanged += new System.EventHandler(this.txtWiadomosc_TextChanged);
            // 
            // panelMojaPlanszy
            // 
            this.panelMojaPlanszy.BackColor = System.Drawing.Color.White;
            this.panelMojaPlanszy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMojaPlanszy.Location = new System.Drawing.Point(183, 32);
            this.panelMojaPlanszy.Margin = new System.Windows.Forms.Padding(2);
            this.panelMojaPlanszy.Name = "panelMojaPlanszy";
            this.panelMojaPlanszy.Size = new System.Drawing.Size(352, 352);
            this.panelMojaPlanszy.TabIndex = 10;
            // 
            // panelPlanszaPrzeciwnika
            // 
            this.panelPlanszaPrzeciwnika.BackColor = System.Drawing.Color.White;
            this.panelPlanszaPrzeciwnika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlanszaPrzeciwnika.Location = new System.Drawing.Point(577, 32);
            this.panelPlanszaPrzeciwnika.Margin = new System.Windows.Forms.Padding(2);
            this.panelPlanszaPrzeciwnika.Name = "panelPlanszaPrzeciwnika";
            this.panelPlanszaPrzeciwnika.Size = new System.Drawing.Size(352, 352);
            this.panelPlanszaPrzeciwnika.TabIndex = 11;
            // 
            // lblTura
            // 
            this.lblTura.AutoSize = true;
            this.lblTura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTura.Location = new System.Drawing.Point(573, 487);
            this.lblTura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTura.Name = "lblTura";
            this.lblTura.Size = new System.Drawing.Size(45, 20);
            this.lblTura.TabIndex = 11;
            this.lblTura.Text = "Tura";
            this.lblTura.Click += new System.EventHandler(this.lblTura_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(11, 487);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblCzasGry
            // 
            this.lblCzasGry.AutoSize = true;
            this.lblCzasGry.Location = new System.Drawing.Point(6, 463);
            this.lblCzasGry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCzasGry.Name = "lblCzasGry";
            this.lblCzasGry.Size = new System.Drawing.Size(80, 13);
            this.lblCzasGry.TabIndex = 13;
            this.lblCzasGry.Text = "Czas gry: 00:00";
            // 
            // timerGry
            // 
            this.timerGry.Interval = 1000;
            this.timerGry.Tick += new System.EventHandler(this.timerGry_Tick);
            // 
            // buttonPoddaj
            // 
            this.buttonPoddaj.Location = new System.Drawing.Point(183, 503);
            this.buttonPoddaj.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPoddaj.Name = "buttonPoddaj";
            this.buttonPoddaj.Size = new System.Drawing.Size(106, 24);
            this.buttonPoddaj.TabIndex = 14;
            this.buttonPoddaj.Text = "Poddaj partię";
            this.buttonPoddaj.UseVisualStyleBackColor = true;
            this.buttonPoddaj.Click += new System.EventHandler(this.buttonPoddaj_Click);
            // 
            // buttonOrientacja
            // 
            this.buttonOrientacja.Location = new System.Drawing.Point(348, 503);
            this.buttonOrientacja.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOrientacja.Name = "buttonOrientacja";
            this.buttonOrientacja.Size = new System.Drawing.Size(135, 24);
            this.buttonOrientacja.TabIndex = 15;
            this.buttonOrientacja.Text = "Orientacja: Poziomo";
            this.buttonOrientacja.UseVisualStyleBackColor = true;
            this.buttonOrientacja.Click += new System.EventHandler(this.buttonOrientacja_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Moja plansza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(679, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Plansza przeciwnika";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Serwer
            // 
            this.AcceptButton = this.buttonWyslij;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 538);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonOrientacja);
            this.Controls.Add(this.buttonPoddaj);
            this.Controls.Add(this.lblCzasGry);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTura);
            this.Controls.Add(this.panelPlanszaPrzeciwnika);
            this.Controls.Add(this.panelMojaPlanszy);
            this.Controls.Add(this.txtWiadomosc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonWyslij);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonDolacz);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Serwer";
            this.Text = "Statki - Serwer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDolacz;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button buttonWyslij;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWiadomosc;
        private System.Windows.Forms.Panel panelMojaPlanszy;
        private System.Windows.Forms.Panel panelPlanszaPrzeciwnika;
        private System.Windows.Forms.Label lblTura;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCzasGry;
        private System.Windows.Forms.Timer timerGry;
        private System.Windows.Forms.Button buttonPoddaj;
        private System.Windows.Forms.Button buttonOrientacja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
