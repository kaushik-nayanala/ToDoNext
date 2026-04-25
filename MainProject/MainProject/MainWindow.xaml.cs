using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using MainProject.View;
using MainProject.Model;
namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectSelectionOptions? StartUpSequence {  get; set; }
        public MainWindow()
        {

            try
            {
                var project = new ProjectSelection();
                project.ShowDialog();
                StartUpSequence = project.SelectedOption;

                switch (project.SelectedOption)
                {
                    case ProjectSelectionOptions.New:
                    case ProjectSelectionOptions.Recent:
                    case ProjectSelectionOptions.Opened:
                    case ProjectSelectionOptions.Saved:
                        InitializeComponent();
                        return;
                }
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }
    }
}