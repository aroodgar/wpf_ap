using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to my Program!", "Hello!");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            //unchecking checkboxes
            this.BacherlorCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.JuniorCheckBox.IsChecked = this.MScCheckBox.IsChecked =
                this.PHDCheckBox.IsChecked = this.PrimaryCheckBox.IsChecked = false;

            //reseting textboxes
            this.NoteTextBox.Text = this.OthersTextBox.Text = this.SavedTextBox.Text = "";
            this.OthersTextBox.IsReadOnly = true;
            this.SavedTextBox.Visibility = Visibility.Hidden;
            this.SavedTextBlock.Visibility = Visibility.Hidden;

            //reseting combobox
            this.UniversityComboBox.SelectedIndex = 0;
        }
    }
}
