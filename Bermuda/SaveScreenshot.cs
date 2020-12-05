using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bermuda
{
    public partial class SaveScreenshot : Form
    {
        Bitmap bmp;
        string imagePath;
        public SaveScreenshot(Int32 x, Int32 y, Int32 w, Int32 h, Size s)
        {
            InitializeComponent();
            //C#: how to take a screenshot of a portion of screen https://stackoverflow.com/a/3306633/5260872

            Rectangle rect = new Rectangle(x, y, w, h);
            bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s, CopyPixelOperation.SourceCopy);

            string appPath = Environment.CurrentDirectory + @"\Screenshots\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            imagePath = appPath+ "Capture" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".jpeg";
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            pbCapture.Image = bmp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ApplicationContext.Instance.currentDK is null)
                ApplicationContext.Instance.currentDK = new Model.DomainKnowledge();
            ApplicationContext.Instance.currentDK.ScreenshotImage = new Model.Screenshot(bmp, imagePath);
            //Mapping mapping = new Mapping();
            this.Hide();
            //mapping.Show();
            //this.logicalParent.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void buttonRecapture_Click(object sender, EventArgs e)
        {
            SelectArea selectArea = new SelectArea();
            this.Hide();
            selectArea.ShowDialog();
        }
    }
}
