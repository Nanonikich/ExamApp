using System;
using System.Linq;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class FormKeys : Form
    {
        #region Init / Load / Closing

        public FormKeys()
        {
            InitializeComponent();

            buttonSelect.DialogResult = DialogResult.Yes;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void FormKeys_Load(object sender, EventArgs e)
        {
            buttonSelect.Enabled = false;

            for (int i = 0; i < FormAbout.avalibleKeys.Count(); i++)
            {
                listBoxKeys.Items.Add(FormAbout.avalibleKeys[i].keyType + " | Key ID = " + FormAbout.avalibleKeys[i].keyId);
            }
        }

        private void FormKeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            listBoxKeys.Items.Clear();
        }

        #endregion Init / Load / Closing

        #region ListBox Changed Selected

        private void ListBoxKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSelect.Enabled = true;
        }

        #endregion ListBox Changed Selected

        #region Buttons

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            string[] tmpSelected = listBoxKeys.SelectedItem.ToString().Split(' ');

            SignIn.curentKeyId = tmpSelected[tmpSelected.Count() - 1];
            listBoxKeys.Items.Clear();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            listBoxKeys.Items.Clear();
            this.Close();
        }

        #endregion Buttons
    }
}