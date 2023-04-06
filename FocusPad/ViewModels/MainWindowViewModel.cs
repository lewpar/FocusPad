using CommunityToolkit.Mvvm.Input;

using System.Windows;
using System.Windows.Input;

namespace FocusPad.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand CommandOpenSettings { get; private set; }
        public ICommand CommandExitProgram { get; private set; }

        public MainWindowViewModel()
        {
            CommandOpenSettings = new RelayCommand(OpenSettings);
            CommandExitProgram = new RelayCommand(ExitProgram);
        }

        private void OpenSettings()
        {
        }

        private void ExitProgram()
        {
            Application.Current.Shutdown();
        }
    }
}
