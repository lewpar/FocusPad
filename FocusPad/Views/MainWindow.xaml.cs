using FocusPad.ViewModels;
using System.Windows;

namespace FocusPad.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
        }

        private void FocusPadMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
