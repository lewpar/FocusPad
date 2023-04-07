using CommunityToolkit.Mvvm.Input;
using FocusPad.Utils;
using System.Collections.Generic;
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

        private List<string> _testNotes;
        public List<string> TestNotes { get => _testNotes; set => SetAndNotify(ref _testNotes, value); }

        private Dictionary<string, List<string>> _notes;

        public MainWindowViewModel()
        {
            CommandOpenSettings = new RelayCommand(OpenSettings);
            CommandExitProgram = new RelayCommand(ExitProgram);

            IsVisible = false;

            _notes = new Dictionary<string, List<string>>()
            {
                { "Discord", new List<string>() { "A", "B" } },
                { "devenv", new List<string>() { "C", "D" } }
            };
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
            var currentProcess = ProcessPInvoke.GetForegroundProcessName();

            TestNotes = _notes[currentProcess];
        }
    }
}
