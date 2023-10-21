using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class Imagem
    {
        public static string CarregarFoto(PictureBox pictureFoto)
        {
            var filePath = string.Empty;

            try
            {
                pictureFoto.SizeMode = PictureBoxSizeMode.StretchImage;

                var fileContent = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Application.StartupPath;
                    openFileDialog.Title = "Selecionar Fotos";
                    openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        //Read the contents of the file into a stream
                        pictureFoto.Image = Image.FromFile(filePath);
                    }
                }
            }
            catch (Exception)
            {
            }

            return filePath;
        }

        public static byte[]? ImageToByteArray(Image imageIn)
        {
            try
            {
                var ms = new MemoryStream();
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static Stream ByteArrayToSteam(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            return ms;
        }
        public static Stream FilePathToStream(string pathLogomarca, int newWidth = 0, int newHeight = 0)
        {
            try
            {
                if (newWidth == 0 || newHeight == 0)
                {
                    System.IO.FileStream stream = new FileStream(pathLogomarca, System.IO.FileMode.Open);
                    return stream;
                }
                else
                {
                    using (Image originalImage = Image.FromFile(pathLogomarca))
                    {
                        using (Image resizedImage = new Bitmap(newWidth, newHeight))
                        {
                            using (Graphics graphics = Graphics.FromImage(resizedImage))
                            {
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;

                                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);

                                EncoderParameters encoderParameters = new(1);
                                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100);

                                ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);

                                var ms = new MemoryStream();
                                resizedImage.Save(ms, jpegCodec, encoderParameters);
                                return ms;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FilePathToStream - {ex.Message}");
                return null;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static bool NuloImagem(byte[] byteArrayIn)
        {
            try
            {
                var ms = new MemoryStream(byteArrayIn);
                var returnImage = Image.FromStream(ms);

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
