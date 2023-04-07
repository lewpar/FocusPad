using FocusPad.Utils;
using FocusPad.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;

namespace FocusPad.Views
{
    public partial class MainWindow : Window
    {
        private KeyboardHook keyHook;
        private string title;

        public MainWindow()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;

            keyHook = new KeyboardHook();
            keyHook.RegisterHotKey(ModifierKeys.Alt | ModifierKeys.Shift, Keys.R);
            keyHook.KeyPressed += KeyHook_KeyPressed;

            title = this.Title;
        }

        private void KeyHook_KeyPressed(object? sender, KeyPressedEventArgs e)
        {
            string focusName = ProcessPInvoke.GetForegroundProcessName();

            if (focusName != "FocusPad")
            {
                this.Title = $"{title} - {focusName}";
                this.Visibility = Visibility.Visible;
            }
        }

        private void FocusPadMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Override the exit and hide to tray.
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void FocusPadMainWindow_Deactivated(object sender, System.EventArgs e)
        {
            // Hide the window when changing focus from current process.
            this.Visibility = Visibility.Hidden;
        }

        private void FocusPadMainWindow_Activated(object sender, System.EventArgs e)
        {
            // Set the current process to the foreground, fixes loss of focus.
            ProcessPInvoke.SetForegroundProcess(Process.GetCurrentProcess());
        }
    }
}
