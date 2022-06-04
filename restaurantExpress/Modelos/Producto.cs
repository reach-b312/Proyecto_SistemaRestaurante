using restaurantExpress.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantExpress.Modelos
{
    public class Producto
    {
        //propiedades
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.connectionString, CommandType.StoredProcedure);
        private readonly string Entity = "Producto";

        private int id;
        private int categoria_id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private string ingredientes;
        private decimal costo;
        private decimal precio;
        private decimal promocion_precio;
        private decimal stock;
        private decimal inventario;
        private string imagen;
        private decimal personas;

        public int Id { get => id; set => id = value; }
        public int Categoria_id { get => categoria_id; set => categoria_id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Ingredientes { get => ingredientes; set => ingredientes = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Promocion_precio { get => promocion_precio; set => promocion_precio = value; }
        public decimal Stock { get => stock; set => stock = value; }
        public decimal Inventario { get => inventario; set => inventario = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public decimal Personas { get => personas; set => personas = value; }

        //Metodos
        public DataTable Data() => DB.GetDataTable("sp_product_data");
        public DataTable DataOrders()
        {
            DB.AddParameters("categoriaid", this.Categoria_id);
            return DB.GetDataTable("sp_product_data_touch");
        }
        public string Create()
        {
            DB.AddParameters("nombre_", this.Nombre);
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("descripcion_", this.Descripcion);
            DB.AddParameters("ingredientes_", this.Ingredientes);
            DB.AddParameters("costo_", this.Costo);
            DB.AddParameters("precio_", this.Precio);
            DB.AddParameters("promocion_precio_", this.Promocion_precio);
            DB.AddParameters("stock_", this.Stock);
            DB.AddParameters("inventario_", this.Inventario);
            DB.AddParameters("imagen_", this.Imagen);
            DB.AddParameters("personas_", this.Personas);
            DB.AddParameters("categoriaid_", this.Categoria_id);
            int res = DB.CRUD("sp_product_create");
            return (res == 1 ? $"{App.ClsCommon.RowCreated}{Entity}" : App.ClsCommon.NoRowsAdded);
        }
        public string Update()
        {
            DB.AddParameters("nombre_", this.Nombre);
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("descripcion_", this.Descripcion);
            DB.AddParameters("ingredientes_", this.Ingredientes);
            DB.AddParameters("costo_", this.Costo);
            DB.AddParameters("precio_", this.Precio);
            DB.AddParameters("promocion_precio_", this.Promocion_precio);
            DB.AddParameters("stock_", this.Stock);
            DB.AddParameters("inventario_", this.Inventario);
            DB.AddParameters("imagen_", this.Imagen);
            DB.AddParameters("personas_", this.Personas);
            DB.AddParameters("categoriaid_", this.Categoria_id);
            int res = DB.CRUD("sp_product_update");
            return (res == 1 ? $"{App.ClsCommon.RowUpdated}{Entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.AddParameters("id_", this.Id);
            int res = DB.CRUD("sp_product_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted}{Entity}" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchText)
        {
            DB.AddParameters("txt", searchText);
            return DB.GetDataTable("sp_product_search");
        }
        public DataTable SearchByCode(string barcode)
        {
            DB.AddParameters("txt", barcode);
            return DB.GetDataTable("sp_product_search_bycode");
        }

        public string GetBarcode()
        {
            DB.AddParameters("db_", "syspedidos");
            DB.AddParameters("table_", "productos");
            DataTable code = DB.GetDataTable("sp_barcode_next");

            if(code !=null && code.Rows.Count >0)
            {
                return code.Rows[0].Field<ulong>("id").ToString("D10");
            }
            else
            {
                return 0.ToString("D10");
            }
        }

    }
}
