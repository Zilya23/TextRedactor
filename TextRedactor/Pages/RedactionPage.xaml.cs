using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextRedactor.Pages
{
    /// <summary>
    /// Логика взаимодействия для RedactionPage.xaml
    /// </summary>
    public partial class RedactionPage : Page
    {
        public static string path = "";
        public RedactionPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(path.Length == 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (saveFileDialog.ShowDialog().GetValueOrDefault())
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(tb_text.Text);
                    streamWriter.Close();
                }
                tb_text.Text = "";
                path = "";
            }
            else
            {
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(tb_text.Text);
                writer.Close();
                tb_text.Text = "";
                path = "";
            }
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (o.ShowDialog().GetValueOrDefault())
            {
                path = o.FileName;
                tb_text.Text = File.ReadAllText(o.FileName, Encoding.Default);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            tb_text.Text = "";
            path = "";
        }
    }
}
