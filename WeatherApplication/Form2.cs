using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApplication
{
    public partial class Form2 : Form
    {

        
        public Form2(Cities city)
        {
            InitializeComponent();
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }
    }
}
