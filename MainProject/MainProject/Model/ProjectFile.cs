using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Model
{
    public class ProjectFile
    {
        public MetaData MetaData = new MetaData();
    }

    public class MetaData
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
