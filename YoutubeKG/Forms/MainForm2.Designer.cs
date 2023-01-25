namespace YoutubeKG.Forms
{
	partial class MainForm2
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
			this.getFullListButton = new System.Windows.Forms.Button();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.singleMp3DownloadAndConvertButton = new System.Windows.Forms.Button();
			this.downloadFullListAndConvertToMp3Button = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.logRichTextBox = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// getFullListButton
			// 
			this.getFullListButton.Location = new System.Drawing.Point(12, 113);
			this.getFullListButton.Name = "getFullListButton";
			this.getFullListButton.Size = new System.Drawing.Size(84, 23);
			this.getFullListButton.TabIndex = 0;
			this.getFullListButton.Text = "Download list";
			this.getFullListButton.UseVisualStyleBackColor = true;
			this.getFullListButton.Click += new System.EventHandler(this.GetFullListButton_Click);
			// 
			// urlTextBox
			// 
			this.urlTextBox.Location = new System.Drawing.Point(12, 87);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(390, 20);
			this.urlTextBox.TabIndex = 2;
			this.urlTextBox.Text = "https://www.youtube.com/watch?v=rNhUNrdAOPU&list=RDMM&start_radio=1&rv=cjLslfmW7B" +
    "w";
			this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlTextBox_KeyDown);
			// 
			// singleMp3DownloadAndConvertButton
			// 
			this.singleMp3DownloadAndConvertButton.Location = new System.Drawing.Point(155, 113);
			this.singleMp3DownloadAndConvertButton.Name = "singleMp3DownloadAndConvertButton";
			this.singleMp3DownloadAndConvertButton.Size = new System.Drawing.Size(102, 23);
			this.singleMp3DownloadAndConvertButton.TabIndex = 4;
			this.singleMp3DownloadAndConvertButton.Text = "Selected to Mp3";
			this.singleMp3DownloadAndConvertButton.UseVisualStyleBackColor = true;
			this.singleMp3DownloadAndConvertButton.Click += new System.EventHandler(this.SingleMp3DownloadAndConvertButton_Click);
			// 
			// downloadFullListAndConvertToMp3Button
			// 
			this.downloadFullListAndConvertToMp3Button.Location = new System.Drawing.Point(300, 113);
			this.downloadFullListAndConvertToMp3Button.Name = "downloadFullListAndConvertToMp3Button";
			this.downloadFullListAndConvertToMp3Button.Size = new System.Drawing.Size(102, 23);
			this.downloadFullListAndConvertToMp3Button.TabIndex = 5;
			this.downloadFullListAndConvertToMp3Button.Text = "Full list to Mp3";
			this.downloadFullListAndConvertToMp3Button.UseVisualStyleBackColor = true;
			this.downloadFullListAndConvertToMp3Button.Click += new System.EventHandler(this.DownloadFullListAndConvertToMp3Button_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new System.Drawing.Point(12, 142);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(390, 355);
			this.dataGridView1.TabIndex = 7;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Title";
			this.Column1.Name = "Column1";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 58);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(776, 23);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 8;
			// 
			// logRichTextBox
			// 
			this.logRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logRichTextBox.Location = new System.Drawing.Point(417, 142);
			this.logRichTextBox.Name = "logRichTextBox";
			this.logRichTextBox.Size = new System.Drawing.Size(380, 355);
			this.logRichTextBox.TabIndex = 16;
			this.logRichTextBox.Text = "";
			this.logRichTextBox.WordWrap = false;
			// 
			// MainForm2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(809, 509);
			this.Controls.Add(this.logRichTextBox);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.downloadFullListAndConvertToMp3Button);
			this.Controls.Add(this.singleMp3DownloadAndConvertButton);
			this.Controls.Add(this.urlTextBox);
			this.Controls.Add(this.getFullListButton);
			this.Name = "MainForm2";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button getFullListButton;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Button singleMp3DownloadAndConvertButton;
		private System.Windows.Forms.Button downloadFullListAndConvertToMp3Button;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.RichTextBox logRichTextBox;
	}
}

