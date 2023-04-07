using CommunityToolkit.Mvvm.Input;
using FocusPad.Models;
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

        private List<FocusNote> _testNotes;
        public List<FocusNote> TestNotes { get => _testNotes; set => SetAndNotify(ref _testNotes, value); }

        private Dictionary<string, List<FocusNote>> _notes;

        public MainWindowViewModel()
        {
            CommandOpenSettings = new RelayCommand(OpenSettings);
            CommandExitProgram = new RelayCommand(ExitProgram);

            IsVisible = false;

            _notes = new Dictionary<string, List<FocusNote>>()
            {
                { "Notepad", new List<FocusNote>() { new FocusNote() { Content = "Test" } } }
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
