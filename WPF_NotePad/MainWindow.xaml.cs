using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace WPF_NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileOpen_button(object sender, RoutedEventArgs e)
        {

        }

        private void Save_button(object sender, RoutedEventArgs e)
        {
            string filename = "Wordpad.json";
            var jsonData = JsonSerializer.Serialize(textbox1.Text, new JsonSerializerOptions { WriteIndented = true });//PROBLEM
            File.WriteAllText(filename, jsonData);
            MessageBox.Show("File saved successfully ");
        }

        private void Cut_button(object sender, RoutedEventArgs e)
        {
            string filename = "copyfile";
            var jsonData = JsonSerializer.Serialize(textbox1.Text, new JsonSerializerOptions { WriteIndented = true });//PROBLEM
            File.WriteAllText(filename, jsonData);
            MessageBox.Show("File has cutted successfully ");
            textbox1.Clear();
        }

        private void Copy_button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textbox1.SelectedText))
                {
                    string filename = "copyfile";
                    Clipboard.SetText(textbox1.SelectedText);
                    var jsonData = JsonSerializer.Serialize(textbox1.SelectedText, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filename, jsonData);

                    MessageBox.Show("Selected text has copied");
                }
                else
                {
                    MessageBox.Show("there is no text");
                }
            }
            catch { }
            {
                MessageBox.Show("");
            }


        }

        private void Paste_button(object sender, RoutedEventArgs e)
        {
            string filename = "copyfile";

            if (File.Exists(filename))
            {
                string jsondata = File.ReadAllText(filename);
                textbox1.Text = JsonSerializer.Deserialize<string>(jsondata);
                MessageBox.Show("Text pasted successfully");

            }
        }

        private void SelectAll_button(object sender, RoutedEventArgs e)
        {

            textbox1.SelectAll();
            textbox1.SelectionBrush = Brushes.Bisque;
            textbox1.SelectionOpacity = 0.5;
        }

    }
}
