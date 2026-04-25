using MainProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace MainProject.View
{
    /// <summary>
    /// Interaction logic for ProjectSelection.xaml
    /// </summary>
    public partial class ProjectSelection : Window
    {
        public ProjectSelectionOptions SelectedOption = ProjectSelectionOptions.None;
        public ProjectSelection()
        {
            InitializeComponent();
        }

        private void NewProject(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedOption = ProjectSelectionOptions.New;
                //Future logic 
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }

        private void RecentProject(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedOption = ProjectSelectionOptions.Recent;
                //Future logic 
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }

        private void SavedProject(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedOption = ProjectSelectionOptions.Saved;
                //Future logic 
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }

        private void OpenedProject(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedOption = ProjectSelectionOptions.Opened;
                //Future logic 
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }
    }
}
