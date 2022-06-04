using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantExpress.App
{
    class ClsUI
    {
        public static string ImagesProductsPath = Application.StartupPath + "\\images\\products";
        public static string ImagesCategoriesPath = Application.StartupPath + "\\images\\categories";
    
        public static bool OnlyDecimal(object sender, KeyPressEventArgs e)
        {
            bool valid =false;
            //validar la entrada, no aplicar cambios si no es ninguna de las condiciones
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) valid = true;
            //permitir solo un punto
            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1)) valid = true;
            return valid;
        }

        public static string Currency(string txtValue) => decimal.Parse((string.IsNullOrEmpty(txtValue.Trim()) ? "0" : txtValue.Trim())).ToString("F");
    }
}
