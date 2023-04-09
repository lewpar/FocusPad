using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FocusPad.Controls
{
    /// <summary>
    /// Interaction logic for EditableTextBlock.xaml
    /// </summary>
    public partial class EditableTextBlock : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBlock), new PropertyMetadata(default(string)));

        public Style TextBoxStyle
        {
            get { return (Style)GetValue(TextBoxStyleProperty); }
            set { SetValue(TextBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty TextBoxStyleProperty =
            DependencyProperty.Register("TextBoxStyle", typeof(Style), typeof(EditableTextBlock), new PropertyMetadata(default(Style)));

        public EditableTextBlock()
        {
            InitializeComponent();
        }

        private void eTextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            eTextBlock.Visibility = Visibility.Collapsed;
            eTextBox.Visibility = Visibility.Visible;

            eTextBox.Focus();
            eTextBox.SelectAll();

            // Required or else the selection process won't occur above.
            e.Handled = true;
        }

        private void eTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            eTextBlock.Visibility = Visibility.Visible;
            eTextBox.Visibility = Visibility.Collapsed;
        }

        private void eTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                eTextBlock.Visibility = Visibility.Visible;
                eTextBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
