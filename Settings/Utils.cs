using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Settings
{
    public static class Utils
    {


        private static List<string> lstExtensions = new List<string>
        {
           "txt","jpg","docx","pdf","application/pdf","csv","xls","xlsx","ppt","pptx","jpeg","jpg","png","bmp","mbox","msg"
        };

        public static bool ValidateFilesIncludes(string extension)
        {
            return lstExtensions.Contains(extension);
        }

        public static bool ListFilesValidate(List<IFormFile> files)
        {
            bool validate = true;
            foreach (IFormFile file in files)
            {
                string filename = file.FileName.Split('.')[1];
                validate = ValidateFilesIncludes(filename);
                if(!validate)
                {
                    break;
                }
            }
            return validate;
        }
    }
}
