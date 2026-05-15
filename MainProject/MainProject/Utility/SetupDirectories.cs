using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Utility
{
    
    public class SetupDirectories
    {
        public static string SavedProjectPath
        {
            get => $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\ToDoSaves";
        }
    }
}
