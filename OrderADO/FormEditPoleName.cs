using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderADO
{
    public partial class FormEditPoleName : Form
    {
        cTypeOrderPole cTOP=null;
        string strtext = "";
        public FormEditPoleName(cTypeOrderPole ctop, string text)
        {
            cTOP = ctop;
            strtext = text;
            InitializeComponent();
        }

        private void FormEditPoleName_Shown(object sender, EventArgs e)
        {
            this.Text = strtext;
            textBox1.DataBindings.Add("Text", cTOP, "NamePole");
        }

        private void FormEditPoleName_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
