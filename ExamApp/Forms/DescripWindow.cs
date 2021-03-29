using System;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class DescripWindow : Form
    {
        MainWindow MainWin;
        public DescripWindow(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }


        private void DescripWindow_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
    }
}
