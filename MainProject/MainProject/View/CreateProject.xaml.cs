using MainProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace MainProject.View
{
    /// <summary>
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Page
    {
        public string ProjectName { get; set;}
        public string ProjectDescription { get; set;}
        public CreateProject()
        {
            ProjectName = ProjectDescription = string.Empty;
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectName = ProjectNameTB.Text;
                ProjectDescription = ProjectDescriptionTB.Text;
                MainWindow.Instance?.SetUpNewProject(ProjectName,ProjectDescription);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }
    }
}
