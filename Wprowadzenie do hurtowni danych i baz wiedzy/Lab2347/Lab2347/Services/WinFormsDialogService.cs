using System.Windows.Forms;
using Lab2.Interfaces;

namespace Lab2.Services
{
	public class WinFormsDialogService : IDialogService
	{
		public string ShowFileDialog(string title,
			string filter)
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = title;
				openFileDialog.Filter = filter;
				openFileDialog.CheckFileExists = true;
				openFileDialog.CheckPathExists = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					return openFileDialog.FileName;
				}
			}

			return null;
		}

		public string ShowFolderDialog()
		{
			using (var folderDialog = new FolderBrowserDialog())
			{
				if (folderDialog.ShowDialog() == DialogResult.OK)
				{
					return folderDialog.SelectedPath;
				}
			}
			return null;
		}

		public void ShowInfo(string message,
			string title)
		{
			MessageBox.Show(message,
				title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		public void ShowError(string message,
			string title)
		{
			MessageBox.Show(message,
				title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
		}
	}
}