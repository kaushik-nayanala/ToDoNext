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
using System.Reflection.Metadata.Ecma335;
namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectSelectionOptions? StartUpSequence {  get; set; }
        public static MainWindow? Instance { get; set; }
        public MainWindow()
        {

            try
            {
                var project = new ProjectSelection();
                project.ShowDialog();
                StartUpSequence = project.SelectedOption;
                Instance = this;
                switch (project.SelectedOption)
                {
                    case ProjectSelectionOptions.New:
                        InitializeComponent();
                        return;
                }

                this.Close();
                Environment.Exit(0);
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

        public void SetUpNewProject(string PName,string PDescription)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    if (this.EntireScreen.Visibility == Visibility.Visible)
                    {
                        this.EntireScreen.Visibility = Visibility.Collapsed;
                        this.EntireScreenFrame.Content = null;
                        this.Height = SystemParameters.FullPrimaryScreenHeight;
                        this.Width  = SystemParameters.FullPrimaryScreenWidth;
                        this.WindowState =WindowState.Maximized;
                        this.MainScreenFrame.Content = new Homepage();
                        this.MainMenuFrame.Content   = new BasicElementPanel();
                    }
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }
    }
}