using Softbery.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Playlists;
using YoutubeExplode.Videos.Streams;
using Xabe.FFmpeg;
using System.Threading;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Softbery.Text.Extensions;

namespace YoutubeKG.Forms
{
	/// <summary>
	/// 
	/// </summary>
	/// <example>
	/// 
	/// new Form { Controls = { box } }.ShowDialog();
	/// </example>
	public partial class MainForm2 : Form
	{
		List<PlaylistVideo> urls;
		int selected = 0;
		string logmessage = "";
		string log_message = String.Empty;
		FFmpeg fmpeg;
		Logger logger = new Logger();

		/// <summary>
		/// 
		/// </summary>
		public MainForm2()
		{
			InitializeComponent();

			singleMp3DownloadAndConvertButton.Enabled = false;
			downloadFullListAndConvertToMp3Button.Enabled = false;

			Logger.Write += AddLogMessage;
			Logger.Write(new Log { TypeLog=LogType.Information, Message="Program is started."});
		}

		/// <summary>
		/// Add log message to RichTextBox
		/// </summary>
		/// <param name="log"></param>
		private void AddLogMessage(Log log)
		{
			Color color = new Color();
			logger.AddLog(log.TypeLog, log.Message);
			log = logger.Logs.Last();

			switch (log.TypeLog)
			{
				case LogType.Information:
					color = Color.Blue;
					break;
				case LogType.Warning:
					color = Color.Orange;
					break;
				case LogType.Error:
					color = Color.Red;
					break;
				case LogType.Success:
					color = Color.Green;
					break;
				default:
					color = Color.Brown;
					break;
			}

			var font = new Font("Calibri", 10f);

			// Run colorize
			_RichTextBoxColorize(log, color, font);
		}

		/// <summary>
		/// Colorize RichTextBox
		/// </summary>
		/// <param name="log">Log for colorize</param>
		/// <param name="color">Color</param>
		private void _RichTextBoxColorize(Log log , Color color, Font font = null)
		{
			// ////////////////////////////////////////////////////////////////
			// Added from Softbery.Text.RichTextBoxColorizeExtensions
			// ////////////////////////////////////////////////////////////////
			var date = log.Date;
			var time = log.Time;
			var type = log.TypeLog.ToString();
			var message = log.Message;
			var box = logRichTextBox;

			box.AppendText("[" + date + " " + time + "]", color, font);
			box.AppendText("[" + type + "]", color, font);
			box.AppendText(": ");
			box.AppendText(message, Color.Black, font);
			box.AppendText(Environment.NewLine);
			// //////////////////////////////////////////////////
			// Softbery.Text.RichTextBoxColorizeExtensions
			// //////////////////////////////////////////////////

			// Scrolling
			box.ScrollToCaret();
		}

		/// <summary>
		/// Download all list from youtube
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">event arguments</param>
		private async void GetFullListButton_Click(object sender, EventArgs e)
		{
			Logger.Write(new Log { TypeLog = LogType.Information, Message = "Getting list from url ..." });
			
			YoutubeExplode.YoutubeClient youtube = new YoutubeExplode.YoutubeClient();

			try
			{
				Logger.Write(new Log { TypeLog = LogType.Information, Message = "Getting playlist ..." });

				var plylist = await youtube.Playlists.GetVideosAsync(urlTextBox.Text).CollectAsync();
				urls = new List<PlaylistVideo>();

				if (plylist.Count>=1)
				{
					dataGridView1.DataSource = null;
				}

				foreach (var item in plylist)
				{
					dataGridView1.Rows.Add(item.Title);
					urls.Add(item);
				}

				singleMp3DownloadAndConvertButton.Enabled = true;
				downloadFullListAndConvertToMp3Button.Enabled = true;
			}
			catch (Exception ex)
			{
				Logger.Write(new Log { TypeLog = LogType.Error, Message = $"Can't get current playlist <b>{urlTextBox.Text}</b>. Reason: "+ex.Message });
			}			
		}

		/// <summary>
		/// Download single title to folder and convert to mp3
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void SingleMp3DownloadAndConvertButton_Click(object sender, EventArgs e)
		{
			var folder = AppDomain.CurrentDomain.BaseDirectory + "\\downloaded\\";
			singleMp3DownloadAndConvertButton.Enabled = false;

			Logger.Write(new Log() { TypeLog=LogType.Information, Message="Start downloading..." });

			// Download
			await DownloadAsync(selected);

			Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Converting title {selected} to mp3..." });
			
			// Convert
			var convert = new NReco.VideoConverter.FFMpegConverter();
			convert.ConvertMedia(folder+urls[selected].Title+".mp4",  folder + urls[selected].Title + ".mp3", "mp3");

			singleMp3DownloadAndConvertButton.Enabled = true;
		}

		/// <summary>
		/// Downloading selected url
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		private async Task DownloadAsync(int index)
		{
			var type = "mp4";
			var client = new YoutubeClient();
			var folder = AppDomain.CurrentDomain.BaseDirectory + "\\downloaded\\";
			// Log
			Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Get information about {urls[index].Title}." });

			var streamInfoSet = await client.Videos.Streams.GetManifestAsync(urls[index].Url);
			var streamInfo = streamInfoSet.GetMuxedStreams().GetWithHighestBitrate();

			if (!Directory.Exists(folder))
			{
				try
				{
					Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Create folder: {folder}." });
					Directory.CreateDirectory(folder);
				}
				catch (Exception ex)
				{
					Logger.Write(new Log() { TypeLog = LogType.Error, Message = $"Can't create {folder}. Because: " + ex.Message });
				}
			}

			try
			{
				Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Downloading {urls[index].Title}." });
				await client.Videos.Streams.DownloadAsync(streamInfo, folder + urls[index].Title + "." + type);
				Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Success." });
			}
			catch (Exception ex)
			{
				Logger.Write(new Log() { TypeLog = LogType.Error, Message = $"Can't download {urls[index].Title}. Reason: " + ex.Message });
			}
		}

		private async void DownloadFullListAndConvertToMp3Button_Click(object sender, EventArgs e)
		{
			var folder = AppDomain.CurrentDomain.BaseDirectory + "\\downloaded\\";
			downloadFullListAndConvertToMp3Button.Enabled = false;

			Logger.Write(new Log() { TypeLog = LogType.Information, Message = "Start downloading list..." });

			for (int i = 0; i < urls.Count; i++)
			{
				var file = AppDomain.CurrentDomain.BaseDirectory + "\\downloaded\\" + urls[i].Title + ".mp4";

				Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Downloading: {urls[i].Title}" });

				// Download
				await DownloadAsync(i);

				Logger.Write(new Log() { TypeLog = LogType.Success, Message = $"Downloaded!" });
				Logger.Write(new Log() { TypeLog = LogType.Information, Message = $"Converting to mp3: {urls[i].Title}" });

				// Convert
				var convert = new NReco.VideoConverter.FFMpegConverter();
				convert.ConvertMedia(folder + urls[i].Title + ".mp4", folder + urls[i].Title + ".mp3", "mp3");

				Logger.Write(new Log() { TypeLog = LogType.Success, Message = $"Converted!" });
			}

			Logger.Write(new Log() { TypeLog = LogType.Success, Message = "List downloaded and converted." });

			downloadFullListAndConvertToMp3Button.Enabled = true;
		}

		private void DataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			selected = dataGridView1.CurrentRow.Index;
		}

		private void Button4_Click(object sender, EventArgs e)
		{

		}

		private void Button5_Click(object sender, EventArgs e)
		{
			
		}

		private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue==13)
			{
				// Get full list from Youtube
				GetFullListButton_Click(sender, e);
			}
		}

		private void LogWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{

		}
	}
}
