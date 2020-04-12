using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Utility
{
    public class ImageUploader
    {
        //  jpg-jpeg-png-gif 4 formatı kabul ediyoruz.

        // olay : Eğer gelen dosya null ise "0" , eğer dosya istenilen formatta değilse "1" , eğer dosya her isteği karşılayıp kaydedildiyse geriye dosyanın kayıt yolu döndürülecek. 


        public static string UploadImage(string serverPath,HttpPostedFileBase gelenDosya)
        {
            if(gelenDosya!=null)
            {
                var fileArray = gelenDosya.FileName.Split('.'); // asd.jpg => fileArrray[0] = asd fileArray[1] = jpg
                string resimUzantisi = fileArray[fileArray.Length - 1]; // son index dosya uzantısıdır.

                if(resimUzantisi=="jpg" || resimUzantisi=="jpeg" || resimUzantisi == "png" || resimUzantisi == "gif")
                {

                    var uniqueName = Guid.NewGuid();
                    var dosyaAdi = uniqueName + "." + resimUzantisi;
                    var filePath = HttpContext.Current.Server.MapPath(serverPath + dosyaAdi);

                    gelenDosya.SaveAs(filePath);



                    return serverPath + dosyaAdi; 

                }
                else
                {
                    return "1";
                }
            }
            else
            {
                return "0";
            }



        }




    }
}