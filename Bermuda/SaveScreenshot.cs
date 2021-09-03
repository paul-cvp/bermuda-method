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

        private readonly Bitmap backupImage;
        private readonly Bitmap originalImage;

        private Rectangle rect = new Rectangle();
        private string imagePath;
        private Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object
        private bool isMouseDown = new Boolean();//this is used to evaluate whether our mousebutton is down or not
        private Point initialLinePoint = Point.Empty;//Point.Empty represents null for a Point object

        public SaveScreenshot(Image imageToEdit)
        {
            InitializeComponent();
            pbCapture.Image = imageToEdit;
            backupImage = new Bitmap(imageToEdit);

            trackBarThickness.Minimum = 2;
            trackBarThickness.Maximum = 20;
            trackBarThickness.Value = 2;
            labelBrushSize.Text = "2";
            comboBoxToolTipItem.SelectedIndex = 0;

            this.groupBoxImageHighlighting.Left = pbCapture.Width + 20;
            this.Size = new Size(pbCapture.Location.X, pbCapture.Height - pbCapture.Location.Y);
            btnRecapture.Visible = false;

        }

        public SaveScreenshot(Int32 x, Int32 y, Int32 w, Int32 h, Size s)
        {
            InitializeComponent();
            //C#: how to take a screenshot of a portion of screen https://stackoverflow.com/a/3306633/5260872

            Rectangle rect = new Rectangle(x, y, w, h);
            originalImage = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(originalImage);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s, CopyPixelOperation.SourceCopy);

            string appPath = Environment.CurrentDirectory + @"\Screenshots\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            imagePath = appPath + "Capture" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".jpeg";
            originalImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            backupImage = new Bitmap(originalImage);
            pbCapture.Image = originalImage;

            trackBarThickness.Minimum = 2;
            trackBarThickness.Maximum = 20;
            trackBarThickness.Value = 2;
            labelBrushSize.Text = "2";
            comboBoxToolTipItem.SelectedIndex = 0;

            this.groupBoxImageHighlighting.Left = pbCapture.Width+20;
            this.Size = new Size(pbCapture.Location.X, pbCapture.Height - pbCapture.Location.Y);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ApplicationContext.Instance.currentDK is null)
                ApplicationContext.Instance.currentDK = new Model.DomainKnowledge();
            ApplicationContext.Instance.currentDK.ScreenshotImage = new Model.Screenshot(pbCapture.Image, imagePath);
            //Mapping mapping = new Mapping();
            this.Close();
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

        //https://simpledevcode.wordpress.com/2014/02/06/drawing-by-mouse-on-a-picturebox-freehand-drawing/

        private void pbCapture_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pbCapture.Image != null)
            {
                switch (comboBoxToolTipItem.SelectedItem)
                {
                    case "Pen":
                        {
                            break;
                        }
                    case "Line":
                        {
                            if (lastPoint != null && lastPoint.X > 0 && lastPoint.Y > 0)
                            {
                                e.Graphics.DrawLine(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), initialLinePoint, lastPoint);
                            }
                            break;
                        }
                    case "Rectangle":
                        {
                            if (rect != null && rect.Width > 0 && rect.Height > 0)
                            {
                                e.Graphics.DrawRectangle(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), rect);
                            }
                            break;
                        }
                    case "Elipse":
                        {

                            if (rect != null && rect.Width > 0 && rect.Height > 0)
                            {
                                e.Graphics.DrawEllipse(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), rect);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void pbCapture_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;//we assign the lastPoint to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)
            isMouseDown = true;//we set to true because our mouse button is down (clicked)

            switch (comboBoxToolTipItem.SelectedItem)
            {
                case "Pen":
                    {
                        break;
                    }
                case "Line":
                    {
                        initialLinePoint = e.Location;
                        break;
                    }
                case "Rectangle":
                case "Elipse":
                    {
                        rect = new Rectangle();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private void pbCapture_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)//check to see if the mouse button is down

            {

                if (lastPoint != null)//if our last point is not null, which in this case we have assigned above

                {

                    //if (pbCapture.Image == null)//if no available bitmap exists on the picturebox to draw on

                    //{
                    //    //create a new bitmap
                    //    Bitmap bmp = new Bitmap(pbCapture.Width, pbCapture.Height);

                    //    pbCapture.Image = bmp; //assign the picturebox.Image property to the bitmap created

                    //}

                    using (Graphics g = Graphics.FromImage(pbCapture.Image))
                    {//we need to create a Graphics object to draw on the picture box, its our main tool

                        //when making a Pen object, you can just give it color only or give it color and pen size
                        switch (comboBoxToolTipItem.SelectedItem)
                        {
                            case "Pen":
                                {
                                    g.DrawLine(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), lastPoint, e.Location);
                                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position
                                    break;
                                }
                            case "Line":
                                {
                                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position
                                    break;
                                }
                            case "Rectangle":
                            case "Elipse":
                                {
                                    Point tempEndPoint = e.Location;
                                    rect.Location = new Point(
                                        Math.Min(lastPoint.X, tempEndPoint.X),
                                        Math.Min(lastPoint.Y, tempEndPoint.Y));
                                    rect.Size = new Size(
                                        Math.Abs(lastPoint.X - tempEndPoint.X),
                                        Math.Abs(lastPoint.Y - tempEndPoint.Y));
                                    break;
                                }
                            default:
                                {
                                    g.DrawLine(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), lastPoint, e.Location);
                                    break;
                                }
                        }
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        //this is to give the drawing a more smoother, less sharper look
                    }
                    pbCapture.Invalidate();//refreshes the picturebox
                }

            }
        }

        private void pbCapture_MouseUp(object sender, MouseEventArgs e)
        {

            isMouseDown = false;
            using (Graphics g = Graphics.FromImage(pbCapture.Image))
            {//we need to create a Graphics object to draw on the picture box, its our main tool

                //when making a Pen object, you can just give it color only or give it color and pen size
                switch (comboBoxToolTipItem.SelectedItem)
                {
                    case "Pen":
                        {
                            break;
                        }
                    case "Line":
                        {
                            g.DrawLine(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), initialLinePoint, e.Location);
                            break;
                        }
                    case "Rectangle":
                        {
                            g.DrawRectangle(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), rect);
                            break;
                        }
                    case "Elipse":
                        {
                            g.DrawEllipse(new Pen(labelColorPicker.BackColor, trackBarThickness.Value), rect);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            pbCapture.Invalidate();//refreshes the picturebox
            lastPoint = Point.Empty;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pbCapture.Image = null;
            try
            {
                pbCapture.Image = new Bitmap(backupImage);
            } catch (Exception ex)
            {

            }
            rect = new Rectangle();
            pbCapture.Invalidate();//refreshes the picturebox
        }

        private void trackBarThickness_Scroll(object sender, EventArgs e)
        {
            var thickness = trackBarThickness.Value;
            labelBrushSize.Text = thickness.ToString();
        }

        private void labelColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelColorPicker.BackColor = colorDialog1.Color;
            }
        }
    }
}
