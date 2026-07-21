using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Lab2.Interfaces;
using Lab2.Models;

namespace Lab2
{
	public partial class ProgressForm : Form
	{
		private readonly string _folderPath;
		private readonly ILogProcessor _logProcessor;
		private readonly BackgroundWorker _bw;
		private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);

		public bool IsCancelled { get; private set; }

		public ParsedLogData Result { get; private set; }

		public event Action<FileProcessedData> FileProcessed;

		private bool _closePending;
		private int _totalLinesRead;
		private int _totalValidEntries;
		private int _totalFilesProcessed;

		public ProgressForm(string folderPath,
			ILogProcessor logProcessor)
		{
			InitializeComponent();

			_folderPath = folderPath;
			_logProcessor = logProcessor;

			_bw = new BackgroundWorker();
			_bw.WorkerReportsProgress = true;
			_bw.WorkerSupportsCancellation = true;
			_bw.DoWork += Bw_DoWork;
			_bw.ProgressChanged += Bw_ProgressChanged;
			_bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
		}

		private void BtnStart_Click(object sender,
			EventArgs e)
		{
			BtnStart.Enabled = false;
			BtnStop.Enabled = true;
			BtnClose.Enabled = false;

			if (_bw.IsBusy)
			{
				LblStatus.Text = @"Resuming...";
				_pauseEvent.Set();
			}
			else
			{
				ListBoxFiles.Items.Clear();
				ProgressBar1.Value = 0;
				LblTotalLines.Text = @"Total lines read: 0";
				Result = null;
				IsCancelled = false;
				_totalLinesRead = 0;
				_totalValidEntries = 0;
				_totalFilesProcessed = 0;
				_pauseEvent.Set();
				LblStatus.Text = @"Processing...";
				_bw.RunWorkerAsync(_folderPath);
			}
		}

		private void BtnStop_Click(object sender,
			EventArgs e)
		{
			if (!_bw.IsBusy)
				return;

			_pauseEvent.Reset();
			BtnStart.Enabled = true;
			BtnStop.Enabled = false;
			LblStatus.Text = @"Paused. Click Start to resume.";
		}

		private void Bw_DoWork(object sender,
			DoWorkEventArgs e)
		{
			var path = (string)e.Argument;
			var worker = (BackgroundWorker)sender;
			var result = _logProcessor.ProcessDirectoryForBw(path,
				worker,
				_pauseEvent);

			if (worker.CancellationPending)
				e.Cancel = true;

			e.Result = result;
		}

		private void Bw_ProgressChanged(object sender,
			ProgressChangedEventArgs e)
		{
			ProgressBar1.Value = e.ProgressPercentage;
			var fileData = (FileProcessedData)e.UserState;

			_totalLinesRead += fileData.NewLinesCount;
			_totalValidEntries += fileData.NewEntriesCount;
			_totalFilesProcessed += fileData.FilesCount;
			LblTotalLines.Text = $@"Total lines read: {_totalLinesRead}" +
								 $@"| Valid entries: {_totalValidEntries}" +
								 $@"| Files: {_totalFilesProcessed}";

			FileProcessed?.Invoke(fileData);
		}

		private void Bw_RunWorkerCompleted(object sender,
			RunWorkerCompletedEventArgs e)
		{
			BtnStop.Enabled = false;
			BtnClose.Enabled = true;

			if (e.Cancelled)
			{
				IsCancelled = true;
				LblStatus.Text = @"Import cancelled.";
				return;
			}

			if (_closePending)
			{
				Close();
				return;
			}

			if (!(e.Result is ParsedLogData result))
			{
				return;
			}

			Result = result;
			BtnStart.Enabled = false;
			LblStatus.Text = @"Done! Click Close to load data into lists.";
			LblTotalLines.Text =
				$@"Total lines read: {result.AllLines.Count}" +
				$@"| Valid entries: {result.ValidEntries.Count} | Files: {result.ProcessedFiles.Count}";
		}

		private void BtnClose_Click(object sender,
			EventArgs e)
		{
			Close();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (_bw.IsBusy)
			{
				_bw.CancelAsync();
				_pauseEvent.Set();
				_closePending = true;
				e.Cancel = true;
				return;
			}

			base.OnFormClosing(e);
		}
	}
}