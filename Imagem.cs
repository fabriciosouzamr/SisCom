using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public static class Imagem
{
    public static byte[] ImageToByteArray(Image imageIn)
    {
        var ms = new MemoryStream();
        imageIn.Save(ms, ImageFormat.Png);
        return ms.ToArray();
    }
    public static Image ByteArrayToImage(byte[] byteArrayIn)
    {
        var ms = new MemoryStream(byteArrayIn);
        var returnImage = Image.FromStream(ms);
        return returnImage;
    }
}