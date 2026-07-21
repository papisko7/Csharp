namespace Lab2.Interfaces
{
	public interface IDialogService
	{
		string ShowFileDialog(string title,
			string filter);

		string ShowFolderDialog();

		void ShowInfo(string message,
			string title);

		void ShowError(string message,
			string title);
	}
}