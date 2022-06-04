using ComponentFactory.Krypton.Toolkit;
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
    public partial class fToast : KryptonForm
    {
        private int time2Exit = 5;
        private string msg = "";
        public fToast(string msg_)
        {
            InitializeComponent();
            this.msg = msg_;
        }

        private void fToast_Load(object sender, EventArgs e)
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

        private void fToast_Shown(object sender, EventArgs e)
        {
            this.lblmsg.Text = this.msg;
            trmTime.Enabled = true;
            this.lbltime.Values.ExtraText = $"Autocierre en: {this.time2Exit}";
        }
        private void trmTime_Tick(object sender, EventArgs e)
        {
            if (this.time2Exit == 0) this.Close();
            this.time2Exit--;
            this.lbltime.Values.ExtraText = $"Autocierre en: {this.time2Exit}";
        }

        private void fToast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

    }
}
