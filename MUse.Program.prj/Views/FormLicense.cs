using System;
using System.IO;
using System.Windows.Forms;
using MyLogClass;

namespace ExamApp
{
    public partial class FormLicense : Form
    {
        #region Init param's

        private readonly settings.examApp appSettings = new settings.examApp();

        #endregion Init param's

        #region Init(default constructor) / Init(constructor with param) Load

        public FormLicense()
        {
            InitializeComponent();
        }

        public FormLicense(bool isSuccess)
        {
            InitializeComponent();

            if (isSuccess)
            {
                labelUpdateStatus.ForeColor = System.Drawing.Color.Green;
                labelUpdateStatus.Text = SignIn.standartData.ErrorMessageReplacer(SignIn.locale, "License update successfully");
            }
            else
            {
                labelUpdateStatus.ForeColor = System.Drawing.Color.Red;
                labelUpdateStatus.Text = SignIn.standartData.ErrorMessageReplacer(SignIn.locale, "Update didn't installing");
            }
        }

        private void FormLicense_Load(object sender, EventArgs e)
        {
            FormLicense lForm = (FormLicense)Application.OpenForms["FormLicense"];

            labelUpdateStatus.Dock = DockStyle.Top;
            labelUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelUpdateStatus.AutoSize = false;

            linkLabelSaveV2C.Dock = DockStyle.Right;

            textBoxAID.Text = FormAbout.aid;
            textBoxKeyID.Text = FormAbout.protectionKeyId;

            if (SignIn.adIsEnabled == false)
            {
                textBoxAID.Visible = false;
                labelAID.Visible = false;

                textBoxKeyID.Location = new System.Drawing.Point(55, 40);
                labelKeyID.Location = new System.Drawing.Point(6, 46);
            }
            else
            {
                textBoxAID.Visible = true;
                labelAID.Visible = true;

                textBoxKeyID.Location = new System.Drawing.Point(55, 52);
                labelKeyID.Location = new System.Drawing.Point(6, 58);
            }
        }

        #endregion Init(default constructor) / Init(constructor with param) Load

        #region Link Label

        private void LinkLabelSaveV2C_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog sf = new SaveFileDialog
            {
                Filter = "v2c files (*.v2c)|*.v2c|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (sf.ShowDialog() == DialogResult.OK)
            {
                //-------------------------------- Save V2C ----------------------------------
                try
                {
                    if (appSettings.enableLogs) Log.Write("Пробуем сохранить V2C файл...");
                    myStream = File.Open(sf.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter createV2CFile = new StreamWriter(myStream);
                    createV2CFile.WriteLine(FormAbout.v2c);
                    createV2CFile.Close();
                    if (appSettings.enableLogs) Log.Write("V2C файл сохранён успешно...");
                }
                catch (Exception ex)
                {
                    if (appSettings.enableLogs) Log.Write("Не могу сохранить V2C: " + Environment.NewLine + FormAbout.v2c + Environment.NewLine + "Ошибка: " + ex);
                    MessageBox.Show(SignIn.standartData.ErrorMessageReplacer(SignIn.locale, "Saving file error: {0}").Replace("{0}", ex.ToString()));
                }
                //----------------------------------------------------------------------------
            }
        }

        #endregion Link Label
    }
}