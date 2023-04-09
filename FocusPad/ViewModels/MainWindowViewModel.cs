using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using FocusPad.Models;
using FocusPad.Utils;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FocusPad.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ICommand CommandOpenSettings { get; private set; }
        public ICommand CommandExitProgram { get; private set; }
        public ICommand CommandAddItem { get; private set; }
        public ICommand CommandDeleteItem { get; private set; }

        private bool _isVisible;
        public bool IsVisible 
        { 
            get => _isVisible; 
            set
            {
                this.SetProperty(ref _isVisible, value);

                if (value)
                {
                    LoadNotes();
                }
            } 
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private string _currentProcess;

        private ObservableCollection<FocusNote> _testNotes;
        public ObservableCollection<FocusNote> TestNotes { get => _testNotes; set => this.SetProperty(ref _testNotes, value); }

        private Dictionary<string, ObservableCollection<FocusNote>> _notes;

        public MainWindowViewModel()
        {
            CommandOpenSettings = new RelayCommand(OpenSettings);
            CommandExitProgram = new RelayCommand(ExitProgram);
            CommandAddItem = new RelayCommand(AddItem);
            CommandDeleteItem = new RelayCommand<FocusNote>(DeleteItem);

            IsVisible = false;

            _notes = new Dictionary<string, ObservableCollection<FocusNote>>()
            {
                { "Notepad", new ObservableCollection<FocusNote>() 
                    { 
                        new FocusNote() { Title = "Title", Content = "Test Content" }, 
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" },
                        new FocusNote() { Title = "Title", Content = "Test Content" }
                    } 
                }
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
            _currentProcess = ProcessPInvoke.GetForegroundProcessName();

            if(!_notes.ContainsKey(_currentProcess))
            {
                _notes.Add(_currentProcess, new ObservableCollection<FocusNote>());
            }

            TestNotes = _notes[_currentProcess];
        }

        private void AddItem()
        {
            if(string.IsNullOrEmpty(SearchText))
            {
                return;
            }

            var note = new FocusNote()
            {
                Title = "Untitled",
                Content = SearchText
            };

            _notes[_currentProcess].Add(note);

            SearchText = string.Empty;
        }

        private void DeleteItem(FocusNote note)
        {
            if(TestNotes.Contains(note))
            {
                TestNotes.Remove(note);
                _notes[_currentProcess].Remove(note);
            }
        }
    }
}
