namespace TANKS.src.views.pages
{
    partial class Juego
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
            this.jugador_component1 = new TANKS.src.views.components.Jugador_component();
            this.jugador_component2 = new TANKS.src.views.components.Jugador_component();
            this.SuspendLayout();
            // 
            // jugador_component1
            // 
            this.jugador_component1.BackColor = System.Drawing.Color.Transparent;
            this.jugador_component1.Location = new System.Drawing.Point(12, 358);
            this.jugador_component1.Name = "jugador_component1";
            this.jugador_component1.Size = new System.Drawing.Size(40, 40);
            this.jugador_component1.TabIndex = 0;
            this.jugador_component1.Vida = 100;
            // 
            // jugador_component2
            // 
            this.jugador_component2.BackColor = System.Drawing.Color.Transparent;
            this.jugador_component2.Location = new System.Drawing.Point(766, 358);
            this.jugador_component2.Name = "jugador_component2";
            this.jugador_component2.Size = new System.Drawing.Size(40, 40);
            this.jugador_component2.TabIndex = 1;
            this.jugador_component2.Vida = 100;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(827, 419);
            this.Controls.Add(this.jugador_component2);
            this.Controls.Add(this.jugador_component1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Juego_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private components.Jugador_component jugador_component1;
        private components.Jugador_component jugador_component2;
    }
}