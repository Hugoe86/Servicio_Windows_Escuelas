namespace Forma_Escuelas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Probar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Probar
            // 
            this.Btn_Probar.Location = new System.Drawing.Point(98, 21);
            this.Btn_Probar.Name = "Btn_Probar";
            this.Btn_Probar.Size = new System.Drawing.Size(103, 23);
            this.Btn_Probar.TabIndex = 0;
            this.Btn_Probar.Text = "Prueba";
            this.Btn_Probar.UseVisualStyleBackColor = true;
            this.Btn_Probar.Click += new System.EventHandler(this.Btn_Probar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 66);
            this.Controls.Add(this.Btn_Probar);
            this.Name = "Form1";
            this.Text = "Escuelas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Probar;
    }
}

