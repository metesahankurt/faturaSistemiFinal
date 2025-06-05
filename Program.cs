namespace FaturaKasaSistemi;
using System;
using System.Windows.Forms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (sender, args) =>
        {
            MessageBox.Show(args.Exception.ToString(), "Beklenmeyen Hata");
        };
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            MessageBox.Show(args.ExceptionObject.ToString(), "Kritik Hata");
        };
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        using (var loginForm = new LoginForm())
        {
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                // Giriş başarısızsa uygulama kapansın
                return;
            }
        }
    }    
}