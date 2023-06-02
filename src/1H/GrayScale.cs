using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//以下、OpenCvsharpの使用とMatの変換用として追加
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace GrayScale{

    public partial class Form1 : Form{

        private Mat _image;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PictureBoxのサイズに合わせて表示
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //画像の読込み
            _image = Cv2.ImRead(@"C:\coffee.jpg");
            pictureBox1.Image = BitmapConverter.ToBitmap(_image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //グレースケール化
            var grayImage = _image.CvtColor(ColorConversionCodes.BGR2GRAY);
            //PictureBoxに表示　MatをBitMapに変換
            pictureBox2.Image = BitmapConverter.ToBitmap(grayImage);

            //2値化(100を閾値として2値化)
            var thresholdImege = grayImage.Threshold(int.Parse(textBox1.Text), 255, ThresholdTypes.Binary);
            pictureBox3.Image = BitmapConverter.ToBitmap(thresholdImege);
        }
    }
}