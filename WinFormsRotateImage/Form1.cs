namespace WinFormsRotateImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"D:\03_user\pg\img\square_size_cat.jpg";
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            pictureBox.Image =  ImageHelper.RotateImage(pictureBox.Image);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            pictureBox.Image = ImageHelper.ResetRotationImage(pictureBox.Image);
        }
    }
}