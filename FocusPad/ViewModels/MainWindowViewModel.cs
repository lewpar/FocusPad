using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FocusPad.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public ICommand CommandOpenSettings { get; private set; }
        public ICommand CommandExitProgram { get; private set; }

        private bool _isVisible;
        public bool IsVisible 
        { 
            get => _isVisible; 
            set
            {
                SetAndNotify(ref _isVisible, value);

                if (value)
                {
                    LoadNotes();
                }
            } 
        }

        public MainWindowViewModel()
        {
            CommandOpenSettings = new RelayCommand(OpenSettings);
            CommandExitProgram = new RelayCommand(ExitProgram);

            IsVisible = false;
        }

        private void OpenSettings()
        {
            IsVisible = true;
        }

        private void ExitProgram()
        {
            Application.Current.Shutdown();
        }

        private void LoadNotes()
        {
            // TODO: Load notes
        }
    }
}
