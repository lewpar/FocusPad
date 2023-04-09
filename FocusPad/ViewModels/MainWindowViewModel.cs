using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using FocusPad.Models;
using FocusPad.Utils;

using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<FocusNote> _currentNotes;
        public ObservableCollection<FocusNote> CurrentNotes { get => _currentNotes; set => this.SetProperty(ref _currentNotes, value); }

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
                { 
                    "Notepad", new ObservableCollection<FocusNote>() 
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

            // Create new note-list if not exist for current process.
            if(!_notes.ContainsKey(_currentProcess))
            {
                _notes.Add(_currentProcess, new ObservableCollection<FocusNote>());
            }

            CurrentNotes = _notes[_currentProcess];
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

            CurrentNotes.Insert(0, note);

            SearchText = string.Empty;
        }

        private void DeleteItem(FocusNote note)
        {
            if(CurrentNotes.Contains(note))
            {
                CurrentNotes.Remove(note);
            }
        }
    }
}
