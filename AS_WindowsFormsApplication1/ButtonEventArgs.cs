using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AnalysisServices;

namespace AS_WindowsFormsApplication
{
    public class ButtonEventArgs : EventArgs
    {
        public ButtonEventArgs(string connectionString)
        {
            this.connectionString = "DataSource=" + connectionString;
        }

        public Server MyServer { get; set; }
        public Cube MyCube { get; set; }
        public string connectionString { get; set; }
    }
}
