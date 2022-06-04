using restaurantExpress.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantExpress.App
{
    public class ClsCommon
    {
        public static int flag = 0;
        public static bool payCommited = false;
        public static string FileName_Ticket;

        public static readonly string version = "1.0.1";
        public static readonly string app = "restaurantExpress";

        public static string Server = "localhost";
        public static string Database = "syspedidos";
        public static string User = "root";
        public static string Password = "";
        public static string connectionString = $"Server={Server};Database={Database};User Id={User};";

        //CRUD
        public static readonly string NoRowsAffected = "Ningun registro eliminado";
        public static readonly string NoRowsAdded = "No se guardó el registro, intenta nuevamente";
        public static readonly string NoRowsUpdated = "No se actualizó el registro";
        public static readonly string NoRowsDeleted = "No se eliminó el registro";

        public static readonly string RowCreated = "Se agregó correctamente el registro a la tabla";
        public static readonly string RowDeleted = "Se eliminó correctamente el registro a la tabla";
        public static readonly string RowUpdated = "Se actualizó correctamente el registro a la tabla";
    
        public static void Toast(string msg)
        {
            fToast f = new fToast(msg);
            f.ShowDialog();
        }
            
    }
}
