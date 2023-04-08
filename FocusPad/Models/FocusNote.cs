using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusPad.Models
{
    public class FocusNote : ObservableObject
    {
        private string _title;
        public string Title { get => _title; set => this.SetProperty(ref _title, value); }

        private string _content;
        public string Content { get => _content; set => this.SetProperty(ref _content, value); }
    }
}
