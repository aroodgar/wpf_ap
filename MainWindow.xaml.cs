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
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentProjectPath;
        private string university = "";
        private string education = "";

        public MainWindow()
        {
            InitializeComponent();
            currentProjectPath = Directory.GetCurrentDirectory().ToString();
            this.OthersTextBox.IsReadOnly = true;
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

            //reseting personal tab textboxes and richtextbox
            this.NameTextBox.Text = "";
            this.FamilyNameTextBox.Text = "";
            this.AgeTextBox.Text = "";
            this.StudentIDTextBox.Text = "";
            this.EquationRichTextBox.Document.Blocks.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string saveContent = "Name:" + NameTextBox.Text + "\nFamilyName:" + FamilyNameTextBox.Text + 
                "\nAge:" + AgeTextBox.Text + "\nStudentID:" + StudentIDTextBox.Text + "\n";
            string selectedComboItem = ((ComboBoxItem)(this.UniversityComboBox.SelectedValue)).Content.ToString();
            if(selectedComboItem == "None")
            {
                university = "None";
            }
            else if(selectedComboItem == "Others...")
            {
                university = this.OthersTextBox.Text;
            }
            else
            {
                university = selectedComboItem;
            }

            saveContent += ("Education:" + education + "\n");
            saveContent += ("University:" + university + "\n");
            saveContent += ("Note:" + NoteTextBox.Text + "\n");
            saveContent += "***\n";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt*)|*.txt";
            saveFileDialog.InitialDirectory = currentProjectPath;
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, saveContent);
        }

        private void PrimaryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BacherlorCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.JuniorCheckBox.IsChecked =
                this.MScCheckBox.IsChecked = this.PHDCheckBox.IsChecked = false;
            education = "PrimarySchool";
        }

        private void JuniorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BacherlorCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.PrimaryCheckBox.IsChecked =
                this.MScCheckBox.IsChecked = this.PHDCheckBox.IsChecked = false;
            education = "JuniorHighSchool";
        }

        private void HighCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BacherlorCheckBox.IsChecked = this.PrimaryCheckBox.IsChecked = this.JuniorCheckBox.IsChecked =
                this.MScCheckBox.IsChecked = this.PHDCheckBox.IsChecked = false;
            education = "HighSchoolDiploma";
        }

        private void BacherlorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.PrimaryCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.JuniorCheckBox.IsChecked =
                this.MScCheckBox.IsChecked = this.PHDCheckBox.IsChecked = false;
            education = "BachelorDegree";
        }

        private void MScCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BacherlorCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.JuniorCheckBox.IsChecked =
                this.PrimaryCheckBox.IsChecked = this.PHDCheckBox.IsChecked = false;
            education = "MScEducation";
        }

        private void PHDCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.BacherlorCheckBox.IsChecked = this.HighCheckBox.IsChecked = this.JuniorCheckBox.IsChecked =
                this.MScCheckBox.IsChecked = this.PrimaryCheckBox.IsChecked = false;
            education = "PHD";
        }

        private void UniversityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItemContent = ((ComboBoxItem)(((ComboBox)sender).SelectedValue)).Content.ToString();
            if (this.OthersTextBox == null)
                return;

            if (selectedItemContent == "Others...")
            {
                this.OthersTextBox.IsReadOnly = false;
            }
            else
            {
                university = selectedItemContent;
                this.OthersTextBox.Text = "";
                this.OthersTextBox.IsReadOnly = true;
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt*)|*.txt";
            openFileDialog.InitialDirectory = currentProjectPath;
            if(openFileDialog.ShowDialog() == true)
            {
                this.SavedTextBlock.Visibility = Visibility.Visible;
                this.SavedTextBox.Visibility = Visibility.Visible;
                this.SavedTextBox.Text += File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void PictureButton_Click(object sender, RoutedEventArgs e)
        {
            //ImageHolder.Source = new BitmapImage(new Uri(currentProjectPath + @"\download.png", UriKind.Relative));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = currentProjectPath;
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                ImageHolder.Source = new BitmapImage(fileUri);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            education = "";
        }

    }
}
