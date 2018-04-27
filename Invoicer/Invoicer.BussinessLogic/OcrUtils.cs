using System;
using System.IO;

namespace Invoicer.BussinessLogic
{
    public static class OcrUtils
    {
        public static string GetStringDataFromFile(string path)
        {
            string fileExtension = Path.GetExtension(path);
            string fileName = Path.GetFileName(path); // Convert.ToString(files.Current).Replace(fileExtension, string.Empty);

            //Check for JPG File Format 
            if (fileExtension != ".jpg" && fileExtension != ".JPG")
                throw new Exception("Nieobsługiwany typ pliku.");
            // or // ImageFormat.Jpeg.ToString()
            //{
            //try
            //{
            //OCR Operations ... 
            MODI.Document md = new MODI.Document();
            md.Create(path);
            md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH);
            MODI.Image image = (MODI.Image)md.Images[0];

            return image.Layout.Text;
            ////create text file with the same Image file name 
            //File.Delete(fileName + ".txt");
            //FileStream createFile =
            //  new FileStream(fileName + ".txt", FileMode.CreateNew);
            ////save the image text in the text file 
            //StreamWriter writeFile = new StreamWriter(createFile);
            //writeFile.Write(image.Layout.Text);
            //writeFile.Close();
            //}            
        }
    }
}
