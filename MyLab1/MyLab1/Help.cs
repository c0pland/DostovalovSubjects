using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyLab1
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("HelpText.txt");

            HelpTextBox.Text = sr.ReadToEnd();
        }


    }
}
