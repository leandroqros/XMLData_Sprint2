
namespace XMLData_Sprint2
{
    partial class frmSelect
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bntLinq = new System.Windows.Forms.Button();
            this.bntXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntLinq
            // 
            this.bntLinq.Location = new System.Drawing.Point(13, 12);
            this.bntLinq.Name = "bntLinq";
            this.bntLinq.Size = new System.Drawing.Size(162, 78);
            this.bntLinq.TabIndex = 0;
            this.bntLinq.Text = "LINQ to XML";
            this.bntLinq.UseVisualStyleBackColor = true;
            this.bntLinq.Click += new System.EventHandler(this.bntLinq_Click);
            // 
            // bntXML
            // 
            this.bntXML.Location = new System.Drawing.Point(176, 12);
            this.bntXML.Name = "bntXML";
            this.bntXML.Size = new System.Drawing.Size(162, 78);
            this.bntXML.TabIndex = 1;
            this.bntXML.Text = "XMLDocument";
            this.bntXML.UseVisualStyleBackColor = true;
            this.bntXML.Click += new System.EventHandler(this.bntXML_Click);
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 106);
            this.Controls.Add(this.bntXML);
            this.Controls.Add(this.bntLinq);
            this.Name = "frmSelect";
            this.Text = "Seleccionador de programa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntLinq;
        private System.Windows.Forms.Button bntXML;
    }
}

