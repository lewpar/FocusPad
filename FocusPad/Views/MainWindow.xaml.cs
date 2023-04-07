using FocusPad.Utils;
using FocusPad.ViewModels;
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
            this.Title = $"{title} - {ProcessPInvoke.GetForegroundProcessName()}";
            this.Visibility = Visibility.Visible;
        }

        private void FocusPadMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
