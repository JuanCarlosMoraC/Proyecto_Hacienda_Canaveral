using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public static class Utilidades
    {

        public static String Formato(String nomOriginal)
        {
            String extension= nomOriginal.Substring(nomOriginal.LastIndexOf("."));

            if(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
            {
                return extension;
            }
            else
            {
                return null;
            }
        }
 

        public static String GetUriImage(int codigo, String formato,Boolean IsIngrediente)
        {
            if (IsIngrediente)
            {
                return "Ingrediente" + codigo + formato;
            }
            else
            {
                return "Instruccion" + codigo + formato;
            }
        }
    }
}