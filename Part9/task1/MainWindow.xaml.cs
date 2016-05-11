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
            lbClasses.Items.Clear();
            lbClassContent.Items.Clear();
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbFilePath.Text = browserDialog.SelectedPath;
            }
            DirectoryInfo directory = new DirectoryInfo(browserDialog.SelectedPath);
            List<FileInfo> files = directory.GetFiles("*.dll").ToList();
            foreach (var file in files)
            {
                lbFiles.Items.Add(file);
            }
        }

        private void lbFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbClasses.Items.Clear();
            lbClassContent.Items.Clear();
            var file = lbFiles.SelectedItem as FileInfo;
            Assembly fileAssembly = Assembly.LoadFile(@"C:\Users\Natallia_Sheibak@epam.com\Desktop\net35\WebDriver.dll");
            var content = fileAssembly.GetTypes();
            foreach(var item in content)
            {
                lbClasses.Items.Add(item);
            }
        }
    }
}
