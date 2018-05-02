using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Invoicer.Infrastructure.Providers
{
    public class OcrTextDataProvider : ITextDataProvider
    {
        public string GetTextData(string path)
        {
            string fileExtension = Path.GetExtension(path);
            string fileName = Path.GetFileName(path);

            if (fileExtension != ".jpg" && fileExtension != ".JPG")
                throw new Exception("Nieobsługiwany typ pliku.");

            MODI.Document md = new MODI.Document();
            md.Create(path);
            md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH);
            MODI.Image image = (MODI.Image)md.Images[0];

            return image.Layout.Text;
        }
    }
}