using System.Drawing.Imaging;

namespace WinFormsRotateImage
{
    public class ImageHelper
    {
        private const int exifOrientationID = 0x0112; // 274 (16進数)

        public static Image RotateImage(Image img)
        {
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            img.Save(new MemoryStream(), ImageFormat.Jpeg);
            return img;
        }

        public static Image ResetRotationImage(Image img)
        {
            if (!img.PropertyIdList.Contains(exifOrientationID))
            {
                return img;
            }

            var prop = img.GetPropertyItem(exifOrientationID);
            int orientation = BitConverter.ToUInt16(prop.Value, 0);            

            switch(orientation)
            {
                case 3:                     
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 6: 
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break; 
                case 8: 
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;                 
            }

            img.Save(new MemoryStream(), ImageFormat.Jpeg);
            return img;
         }

    }
}
