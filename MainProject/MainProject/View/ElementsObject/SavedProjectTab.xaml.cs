using System;
using System.Collections.Generic;
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

namespace MainProject.View.ElementsObject
{
    /// <summary>
    /// Interaction logic for SavedProjectTab.xaml
    /// </summary>
    public partial class SavedProjectTab : UserControl
    {

        public SavedProjectTab(string projname, string desc, string crettime, string creatdate)
        {
            InitializeComponent();
            this.Dispatcher.Invoke(() =>
            {
                this.ProjectName.Content = projname;
                this.Description.Text = $"{desc.Substring(0,98)}...";
                this.CreationTime.Content = crettime;
                this.CreationDate.Content = creatdate;
            });
        }

        private void Selected(object sender, RoutedEventArgs e)
        {

        }

        private void UnSelected(object sender, RoutedEventArgs e)
        {

        }
    }
}
