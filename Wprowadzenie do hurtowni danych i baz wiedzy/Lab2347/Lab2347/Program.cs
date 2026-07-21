using System;
using System.Windows.Forms;
using Lab2.Interfaces;
using Lab2.Services;

namespace Lab2
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ILogProcessor logProcessor = new LogProcessor();
			IDialogService dialogService = new WinFormsDialogService();

			Application.Run(new Form1(logProcessor,
				dialogService));
		}
	}
}