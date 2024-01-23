/*
 * Assignment 2
 * 
 * Name: Bilal Ozdemir
 * 
 * Date: November 1, 2023
 * 
 * Latest Revision Date: November 1, 2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOzdemirQGame
{
    public partial class controlPanel : Form
    {
        public controlPanel()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DesignerForm designerForm = new DesignerForm();
            designerForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play play = new Play();
            play.Show();
        }
    }
}
