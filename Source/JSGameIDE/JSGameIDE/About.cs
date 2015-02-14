using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        //Ok button event
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
