using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace TestRegressionTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICollectionView List_Marks { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cr_button_Click(object sender, RoutedEventArgs e)
        {
            var sw = new Stopwatch();
            try
            {
                sw.Start();
                var maxMarks = int.Parse(maxMarksTB.Text);
                var random = new Random();
                var count = int.Parse(countTB.Text);
                var m_count = (count * int.Parse(percentageModeratorTB.Text)) / 100;
                var moderator_indices = new List<int>();

                //Create random moderator indices
                for (int i = 0; i < m_count; i++)
                {
                    var next_indices = random.Next(0, count);
                    if (moderator_indices.IndexOf(next_indices) == -1)
                        moderator_indices.Add(next_indices);
                    else
                        i--;
                }

                //Create random rawmarks  

                DataContext = new MarkViewModel(count, moderator_indices, maxMarks);
                timelb.Content = "Total Time Taken: " + sw.Elapsed;
                sw.Stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sw = new Stopwatch();
            try
            {
                sw.Start();
                var maxMarks = int.Parse(maxMarksTB.Text);
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                var fileName = "";
                if (result == true)
                    fileName = dlg.FileName;
                DataContext = new MarkViewModel(maxMarks, fileName);
                timelb.Content = "Total Time Taken: " + sw.Elapsed;
                sw.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    
}
