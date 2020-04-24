using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class formCWID : Form
    {
        public formCWID()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //hide CWID form
            this.Hide();

            //open the main form and pass the cwid in
            formMain showMain = new formMain(textBoxCWID.Text); 
            if(showMain.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }
        }

        private void formCWID_Load(object sender, EventArgs e)
        {

        }
    }
}
