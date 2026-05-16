using MainProject.Model;
using MainProject.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
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
        public string ProjectName
        {
            get => _projectname;
        }

        public string ProjectDesc
        {
            get => _projectdesc;
        }
        private string _projectname = string.Empty;
        private string _projectdesc = string.Empty;

        private void NewProject(object sender, RoutedEventArgs e)
        {
            try
            {
                //SelectedOption = ProjectSelectionOptions.New;
                //Future logic 
                this.BackgroundImage.Visibility  = Visibility.Hidden;
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

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedOption = ProjectSelectionOptions.None;
                //Future logic 
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex} at {MethodBase.GetCurrentMethod()}");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BackApp(object sender, RoutedEventArgs e)
        {
            this.BackgroundImage.Visibility = Visibility.Visible;
        }

        private void TextboxHandler(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            switch (textBox.Name)
            {
                case "ProjectNameTb":
                    _projectname = textBox.Text;
                    break;
                case "ProjectDescTb":
                    _projectdesc = textBox.Text;
                    break;
            }

            if(_projectdesc.Trim().Length * _projectname.Trim().Length > 0 )
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var obj = new ProjectFile();

            obj.MetaData.Name = _projectname;
            obj.MetaData.Description = _projectdesc;

            if(!Directory.Exists(SetupDirectories.SavedProjectPath))
            {
                Directory.CreateDirectory(SetupDirectories.SavedProjectPath);
            }

            var str = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var filepath = $"{SetupDirectories.SavedProjectPath}\\{obj.MetaData.Name.Replace(" ","").Trim()}.tdn";


            if (!File.Exists(filepath))
            {
                File.WriteAllText(filepath, str);
                this.SelectedOption = ProjectSelectionOptions.New;
                this.Close();
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = Directory.GetFiles(SetupDirectories.SavedProjectPath).Where(x=>x.EndsWith(".tdn"));

            var files = new List<ProjectFile>();
            foreach (var file in obj) 
            {
                files.Add(JsonConvert.DeserializeObject<ProjectFile>(File.ReadAllText(file)));
            }

            SavedGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < 4; i++)
            {
                SavedGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            var d = Math.Ceiling(files.Count/4.0);
            int rowcount = Convert.ToInt32(d + 1);

            for(int i = 0; i < rowcount; i++)
            {
                SavedGrid.RowDefinitions.Add(new RowDefinition());
                SavedGrid.RowDefinitions[i].Height = new GridLength(100);
                if (i == rowcount - 1)
                {
                    SavedGrid.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Star);
                }
            }

            int col = 0;
            int row = 0;
            foreach (var item in files) 
            {
                var btn = new Button();
                btn.Content = item.MetaData.Name;
                Grid.SetColumn(btn, col);
                Grid.SetRow(btn, row);
                SavedGrid.Children.Add(btn);
                col++;
                if (col == 4)
                {
                    col = 0;
                    row ++;
                }
            }
        }
    }
}
