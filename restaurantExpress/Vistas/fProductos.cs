using ComponentFactory.Krypton.Toolkit;
using restaurantExpress.App;
using restaurantExpress.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantExpress.Vistas
{
    public partial class fProductos : KryptonForm
    {
        #region VARIABLES
        private int id = 0;
        private int category_id = 0;

        private readonly Producto pr = new Producto();
        private readonly Categoria ca = new Categoria();

        private DataTable data = new DataTable();
        private DataTable cat = new DataTable(); //tipo de var. donde se almacenaran las categorias

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private KryptonForm kform;

        #endregion
        //Constructor
        public fProductos(/*KryptonForm kform*/)
        {
            InitializeComponent();
            //this.kform = kform;
            this.Data();
            this.CategoryList();

        }

        private void CategoryList() //Llenar combobox y listbox
        {
            this.cat = ca.List();
            cmbCategory.DisplayMember = "nombre";
            cmbCategory.ValueMember = "id";
            cmbCategory.DataSource = cat;

            //cargar
            if(cat !=null && cat.Rows.Count > 0)
            {
                this.klistcat.Items.Clear();
                for (int i = 0; i<= cat.Rows.Count-1; i++)
                {
                    this.klistcat.Items.Add($"{cat.Rows[1].Field<Int32>("id")} - {cat.Rows[i].Field<string>("nombre")}");
                }
            }
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void ResetUI()
        {
            this.id = 0;
            this.category_id = 0;
            this.txtName.Clear();
            this.txtBarcode.Clear();
            this.txtDescription.Clear();
            this.txtIngredients.Clear();
            this.txtPrice.Text = "0.00";
            this.txtCost.Text = "0.00";
            this.txtStock.Text = "0.00";
            this.txtSpecialPrice.Text = "0.00";
            this.txtAlerts.Text = "0.00";
            this.txtPersonas.Text = "0.00";
            this.pBox.Image = null;
            this.kryptonHeaderGroup2.BackgroundImage = null;
            this.txtName.Focus();
        }

        #region METODOS
        private void Data()
        {
            this.dtGrid.Columns.Clear();
            this.data = pr.Data();
            //mostrar informacion al usuario
            this.dtGrid.DataSource = data;
            //diseñar
            this.dtGrid.RowTemplate.Height = 40;
            this.dtGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CreateOrUpdate()
        {
            //posicionar la lista
            this.kryptonNavigator1.SelectedIndex = 1;
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                ClsCommon.Toast("Ingresa el nombre del producto");
                this.txtName.Focus();
                return;
            }
            pr.Id = this.id;
            pr.Nombre = this.txtName.Text.Trim();
            pr.Categoria_id = Convert.ToInt32(cmbCategory.SelectedValue);
            pr.Codigo = this.txtBarcode.Text.Trim();
            pr.Descripcion = this.txtDescription.Text.Trim();
            pr.Ingredientes = this.txtDescription.Text.Trim();
            pr.Precio = Decimal.Parse(this.txtPrice.Text);
            pr.Costo = Decimal.Parse(this.txtCost.Text);
            pr.Promocion_precio = Decimal.Parse(this.txtSpecialPrice.Text);
            pr.Stock = Decimal.Parse(this.txtStock.Text);
            pr.Inventario= Decimal.Parse(this.txtAlerts.Text);
            pr.Personas = Decimal.Parse(this.txtPersonas.Text);
            if(this.pBox.Image != null)
            {
                string PicName = this.txtName.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pBox.Image.Save(ClsUI.ImagesProductsPath + PicName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                pr.Imagen = PicName + ".jpg";
            }
            ClsCommon.Toast(this.id > 0 ? pr.Update() : pr.Create());
            this.Data();
            //regresar posicion
            this.kryptonNavigator1.SelectedIndex = 0;

            this.ResetUI();

        }

        private void Destroy()
        {
            pr.Id = this.id;
            ClsCommon.Toast(pr.Destroy());
            this.ResetUI();
            this.Data();
            ClsCommon.flag = 0;
            this.kryptonNavigator1.SelectedIndex = 0;
        }

        private void CreateOrUpdate_Categories()
        {
            if (string.IsNullOrEmpty(this.txtCategory.Text))
            {
                ClsCommon.Toast("Ingresa el nombre de la categoría");
                this.txtCategory.Focus();
                return;
            }
            ca.Id = this.category_id;
            ca.Nombre = this.txtCategory.Text.Trim();

            if (this.pCategory.Image != null)
            {
                string PicName = this.txtCategory.Text.Trim().Replace(" ", "_").ToLower() + DateTime.Now.Ticks.ToString();
                pCategory.Image.Save(ClsUI.ImagesCategoriesPath + PicName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                ca.Imagen = PicName + ".jpg";
            }
            ClsCommon.Toast(this.id > 0 ? ca.Update() : ca.Create());
            this.CategoryList();
            this.ResetUI();
        }

        private void DestroyCategories()
        {
            ca.Id = this.category_id;
            ClsCommon.Toast(ca.Destroy());
            this.ResetUI();
            this.CategoryList();
        }

        #endregion
        private void fProductos_Load(object sender, EventArgs e)
        {

        }

        private void buttonSpecAny1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kpEdit_Click(object sender, EventArgs e)
        {

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtSpecialPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtAlerts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtPersonas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClsUI.OnlyDecimal(sender, e);
        }

        private void txtCost_Validated(object sender, EventArgs e)
        {
            txtCost.Text = ClsUI.Currency(txtCost.Text.Trim());
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            txtPrice.Text = ClsUI.Currency(txtPrice.Text.Trim());
        }

        private void txtSpecialPrice_Validated(object sender, EventArgs e)
        {
            txtSpecialPrice.Text = ClsUI.Currency(txtSpecialPrice.Text.Trim());
        }

        private void txtStock_Validated(object sender, EventArgs e)
        {
            txtStock.Text = ClsUI.Currency(txtStock.Text.Trim());
        }

        private void txtAlerts_Validated(object sender, EventArgs e)
        {
            txtAlerts.Text = ClsUI.Currency(txtAlerts.Text.Trim());
        }

        private void txtPersonas_Validated(object sender, EventArgs e)
        {
            txtPersonas.Text = ClsUI.Currency(txtPersonas.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ResetUI();
            this.kryptonNavigator1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CreateOrUpdate();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            if(this.id <= 0)
            {
                ClsCommon.Toast("Selecciona el registro a eliminar");
                this.kryptonNavigator1.SelectedIndex = 0;
                this.dtGrid.Focus();
                return;
            }
            this.kryptonNavigator1.SelectedIndex = 1;
            fConfirm f = new fConfirm();
            f.ShowDialog();
            if(ClsCommon.flag == 1)
            {
                this.Destroy();
                ClsCommon.flag = 0;
            }
        }

        private void dtGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.pBox.Image = null;
                this.id = Convert.ToInt32(this.dtGrid.CurrentRow.Cells["id"].Value);
                this.txtName.Text = this.dtGrid.CurrentRow.Cells["nombre"].Value.ToString();
                this.txtCategory.Text = this.dtGrid.CurrentRow.Cells["categoria"].Value.ToString();
                this.txtBarcode.Text = this.dtGrid.CurrentRow.Cells["codigo"].Value.ToString();
                this.txtDescription.Text = this.dtGrid.CurrentRow.Cells["descripcion"].Value.ToString();
                this.txtIngredients.Text = this.dtGrid.CurrentRow.Cells["ingredientes"].Value.ToString();
                this.txtCost.Text = this.dtGrid.CurrentRow.Cells["costo"].Value.ToString();
                this.txtPrice.Text = this.dtGrid.CurrentRow.Cells["precio"].Value.ToString();
                this.txtSpecialPrice.Text = this.dtGrid.CurrentRow.Cells["promocion_precio"].Value.ToString();
                this.txtStock.Text = this.dtGrid.CurrentRow.Cells["stock"].Value.ToString();
                this.txtAlerts.Text = this.dtGrid.CurrentRow.Cells["alertas"].Value.ToString();
                this.txtName.Text = this.dtGrid.CurrentRow.Cells["personas"].Value.ToString();

                if (string.IsNullOrEmpty(this.dtGrid.CurrentRow.Cells["imagen"].Value.ToString()))
                {
                    if(File.Exists(ClsUI.ImagesProductsPath + this.dtGrid.CurrentRow.Cells["imagen"].Value.ToString()))
                    {
                        Image image = Image.FromFile(ClsUI.ImagesProductsPath + this.dtGrid.CurrentRow.Cells["imagen"].Value.ToString());
                        this.pBox.Image = image;
                        this.pBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }

                this.kryptonNavigator1.SelectedIndex = 1;
            }
            catch(Exception)
            {
                //archivo log
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                if (string.IsNullOrEmpty(txtSearch.TextBox.Text))
                {
                    this.Data();
                    this.kryptonNavigator1.SelectedIndex = 0;
                } 
                else
                {
                    this.dtGrid.DataSource = pr.Search(txtSearch.Text.Trim());
                    txtSearch.Clear();
                    txtSearch.Focus();
                    this.kryptonNavigator1.SelectedIndex = 0;
                }
            }
        }

        private void btnFindImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Elegir imagen(*.jpg; *.png)|*.jpg; *.png";
            if(opf.ShowDialog()== DialogResult.OK)
            {
                pBox.Image = Image.FromFile(opf.FileName);
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void kryptonHeader1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void kryptonHeader1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void kryptonHeader1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            if (ca.CategoryExists(txtCategory.Text.Trim()))
            {
                ClsCommon.Toast("Ya existe la categoría");
            }
            else
                this.CreateOrUpdate_Categories();
        }

        private void btnDelCat_Click(object sender, EventArgs e)
        {
            if (this.category_id > 0)
            {
                if (ca.HasProduct(this.category_id))
                {
                    ClsCommon.Toast("La categoría tiene productos relacionados, no es posible eliminarla");
                    return;
                }
                fConfirm f = new fConfirm();
                f.ShowDialog();
                if(ClsCommon.flag == 1)
                {
                    this.DestroyCategories();
                    ClsCommon.flag = 0;
                }
                else
                {
                    ClsCommon.Toast("Selecciona la categoría");
                }
            }
        }

        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Elegir imagen(*.jpg; *.png)|*.jpg; *.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pCategory.Image = Image.FromFile(opf.FileName);
                pCategory.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void klistcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] data = klistcat.SelectedItem.ToString().Split();
                DataRow[] result = cat.Select($"id = {data[0]}");
                this.category_id = Convert.ToInt32(result[0].Field<string>("nombre").ToString());
                if (!string.IsNullOrEmpty(result[0].Field<string>("imagen")))
                {
                    if(File.Exists(ClsUI.ImagesCategoriesPath +result[0].Field<string>("imagen").ToString()))
                    {
                        Image image = Image.FromFile(ClsUI.ImagesCategoriesPath + result[0].Field<string>("imagen").ToString());
                        this.pCategory.Image = image;
                        this.pCategory.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
