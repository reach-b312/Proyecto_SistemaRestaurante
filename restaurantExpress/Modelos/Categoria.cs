using restaurantExpress.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantExpress.Modelos
{
    public class Categoria
    {
        //propiedades
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.connectionString, CommandType.StoredProcedure);
        private readonly string Entity = "Categorías";

        private int id;
        private string nombre;
        private string imagen;

        //getters & setters
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        //metodos
        public DataTable Data() => DB.GetDataTable("sp_category_data");
        public DataTable List() => DB.GetDataTable("sp_category_list");

        //CRUD
        public string Create()
        {
            DB.AddParameters("nombre_", this.Nombre);
            DB.AddParameters("imagen_", this.Imagen);
            int res = DB.CRUD("sp_category_create");

            return (res == 1 ? $"{App.ClsCommon.RowCreated}{Entity}" : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.AddParameters("id_", this.Id);
            DB.AddParameters("nombre_", this.Nombre);
            DB.AddParameters("imagen_", this.Imagen);
            int res = DB.CRUD("sp_category_update");

            return (res == 1 ? $"{App.ClsCommon.RowUpdated}{Entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.AddParameters("id_", this.Id);
            int res = DB.CRUD("sp_category_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted}{Entity}" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchText)
        {
            DB.AddParameters("txt", searchText);
            return DB.GetDataTable("sp_category_search");
        }

        public bool HasProduct(int category_id)
        {
            DB.AddParameters("id_", category_id);
            DataTable info = DB.GetDataTable("sp_category_search");
            return (info != null && info.Rows.Count > 0 ? true : false);
        }
        public bool CategoryExists(string nombre)
        {
            DB.AddParameters("nombre_", nombre);
            DataTable info = DB.GetDataTable("sp_category_exists");
            return (info != null && info.Rows.Count > 0 ? true : false);
        }
    }

}
