using ComponentFactory.Krypton.Toolkit;
using restaurantExpress.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantExpress.Vistas
{
    public partial class fConfirm : KryptonForm
    {
        public fConfirm(string title_ = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(title_)) this.lblmsg.Text = title_;
        }

        private void fConfirm_Load(object sender, EventArgs e)
        {
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = Color.Maroon };
            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = Color.Maroon };
            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = Color.Maroon };
            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = Color.Maroon };

            this.Controls.Add(pnlTop);
            this.Controls.Add(pnlRight);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlLeft);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ClsCommon.flag = 1;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
