using FocusPad.Utils;
using FocusPad.ViewModels;
using System.Windows;
using System.Windows.Forms;

namespace FocusPad.Views
{
    public partial class MainWindow : Window
    {
        private KeyboardHook keyHook;

        public MainWindow()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;

            keyHook = new KeyboardHook();
            keyHook.RegisterHotKey(ModifierKeys.Alt | ModifierKeys.Shift, Keys.R);
            keyHook.KeyPressed += KeyHook_KeyPressed;
        }

        private void KeyHook_KeyPressed(object? sender, KeyPressedEventArgs e)
        {
            this.Visibility = Visibility.Visible;
        }

        private void FocusPadMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
