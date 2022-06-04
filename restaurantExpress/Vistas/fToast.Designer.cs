
namespace restaurantExpress.Vistas
{
    partial class fToast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fToast));
            this.lblmsg = new System.Windows.Forms.Label();
            this.lbltime = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.trmTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.BackColor = System.Drawing.Color.Transparent;
            this.lblmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmsg.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblmsg.Location = new System.Drawing.Point(0, 0);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(243, 40);
            this.lblmsg.TabIndex = 0;
            this.lblmsg.Text = "Mensaje Toast";
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltime
            // 
            this.lbltime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbltime.Location = new System.Drawing.Point(0, 121);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(711, 29);
            this.lbltime.StateNormal.LongText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.StateNormal.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbltime.StateNormal.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbltime.StateNormal.ShortText.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.TabIndex = 1;
            this.lbltime.Values.ExtraText = "Cerrando en:";
            this.lbltime.Values.Image = ((System.Drawing.Image)(resources.GetObject("lbltime.Values.Image")));
            this.lbltime.Values.Text = "";
            // 
            // trmTime
            // 
            this.trmTime.Interval = 500;
            this.trmTime.Tick += new System.EventHandler(this.trmTime_Tick);
            // 
            // fToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(711, 150);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lblmsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "fToast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fToast";
            this.Load += new System.EventHandler(this.fToast_Load);
            this.Shown += new System.EventHandler(this.fToast_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fToast_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmsg;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbltime;
        private System.Windows.Forms.Timer trmTime;
    }
}