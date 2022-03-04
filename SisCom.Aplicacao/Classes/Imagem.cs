using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class Imagem
    {
        public static bool CarregarFoto(PictureBox pictureFoto)
        {
            bool ret = false;

            try
            {
                pictureFoto.SizeMode = PictureBoxSizeMode.StretchImage;

                var fileContent = string.Empty;
                var filePath = string.Empty;

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

            return ret;
        }

        public static byte[]? ImageToByteArray(Image imageIn)
        {
            try
            {
                var ms = new MemoryStream();
                imageIn.Save(ms, ImageFormat.Png);
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
