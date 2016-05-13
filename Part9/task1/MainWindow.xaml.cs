using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.IO;

namespace task1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            lbTypes.Items.Clear();
            lbTypeContent.Items.Clear();
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbFilePath.Text = browserDialog.SelectedPath;
                DirectoryInfo directory = new DirectoryInfo(browserDialog.SelectedPath);
                List<FileInfo> files = directory.GetFiles("*.dll").ToList();
                foreach (var file in files)
                {
                    lbFiles.Items.Add(file);
                }
            }
        }

        private void lbFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbTypes.Items.Clear();
            lbTypeContent.Items.Clear();
            var file = lbFiles.SelectedItem as FileInfo;
            if (file != null)
            {
                try
                {
                    Assembly fileAssembly = Assembly.LoadFile(file.FullName);
                    var content = fileAssembly.GetTypes();
                    foreach (var item in content)
                    {
                        lbTypes.Items.Add(item);
                    }
                    lbTypes.DisplayMemberPath = "Name";
                }
                catch (ReflectionTypeLoadException error)
                {
                    System.Windows.MessageBox.Show("Some error with loading the current file ocurred.", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void lbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillListBoxTypeContent();
        }

        private void cmbContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbTypes.Items.Count > 0)
            {
                FillListBoxTypeContent();
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FillListBoxTypeContent()
        {
            lbTypeContent.Items.Clear();
            var type = lbTypes.SelectedItem as Type;
            if (type != null)
            {
                MemberInfo[] items = null;
                switch (cmbContent.SelectedIndex)
                {
                    case 0:
                        items = type.GetMembers().Where(t=> (t as EventInfo)==null).Select(t=>t).ToArray();
                        break;
                    case 1:
                        items = type.GetFields();
                        break;
                    case 2:
                        items = type.GetMethods();
                        break;
                    case 3:
                        items = type.GetProperties();
                        break;
                }
                foreach (var item in items)
                {
                    lbTypeContent.Items.Add(item);
                }
                lbTypeContent.DisplayMemberPath = "Name";
            }
        }
    }
}
