namespace TANKS.src.views.options
{
    partial class Score_option
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_inicio = new System.Windows.Forms.Label();
            this.tabla_estadisticas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.disparosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadisticaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ganadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contricanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jugadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabla_partida = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_estadisticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_partida)).BeginInit();
            this.SuspendLayout();
            // 
            // label_inicio
            // 
            this.label_inicio.AutoSize = true;
            this.label_inicio.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_inicio.ForeColor = System.Drawing.Color.White;
            this.label_inicio.Location = new System.Drawing.Point(13, 0);
            this.label_inicio.Name = "label_inicio";
            this.label_inicio.Size = new System.Drawing.Size(59, 19);
            this.label_inicio.TabIndex = 2;
            this.label_inicio.Text = "label1";
            // 
            // tabla_estadisticas
            // 
            this.tabla_estadisticas.AutoGenerateColumns = false;
            this.tabla_estadisticas.BackgroundColor = System.Drawing.Color.Black;
            this.tabla_estadisticas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabla_estadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_estadisticas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disparosDataGridViewTextBoxColumn,
            this.vidaDataGridViewTextBoxColumn,
            this.tiempoDataGridViewTextBoxColumn});
            this.tabla_estadisticas.DataSource = this.estadisticaBindingSource;
            this.tabla_estadisticas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tabla_estadisticas.Location = new System.Drawing.Point(150, 81);
            this.tabla_estadisticas.Name = "tabla_estadisticas";
            this.tabla_estadisticas.Size = new System.Drawing.Size(348, 150);
            this.tabla_estadisticas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estadistica por partida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Partidas";
            // 
            // disparosDataGridViewTextBoxColumn
            // 
            this.disparosDataGridViewTextBoxColumn.DataPropertyName = "Disparos";
            this.disparosDataGridViewTextBoxColumn.HeaderText = "Disparos";
            this.disparosDataGridViewTextBoxColumn.Name = "disparosDataGridViewTextBoxColumn";
            // 
            // vidaDataGridViewTextBoxColumn
            // 
            this.vidaDataGridViewTextBoxColumn.DataPropertyName = "Vida";
            this.vidaDataGridViewTextBoxColumn.HeaderText = "Vida";
            this.vidaDataGridViewTextBoxColumn.Name = "vidaDataGridViewTextBoxColumn";
            // 
            // tiempoDataGridViewTextBoxColumn
            // 
            this.tiempoDataGridViewTextBoxColumn.DataPropertyName = "Tiempo";
            this.tiempoDataGridViewTextBoxColumn.HeaderText = "Tiempo";
            this.tiempoDataGridViewTextBoxColumn.Name = "tiempoDataGridViewTextBoxColumn";
            // 
            // estadisticaBindingSource
            // 
            this.estadisticaBindingSource.DataSource = typeof(TANKS.src.tools.objects.Estadistica);
            // 
            // partidaBindingSource
            // 
            this.partidaBindingSource.DataSource = typeof(TANKS.src.tools.objects.Partida);
            // 
            // ganadorDataGridViewTextBoxColumn
            // 
            this.ganadorDataGridViewTextBoxColumn.DataPropertyName = "Ganador";
            this.ganadorDataGridViewTextBoxColumn.HeaderText = "Ganador";
            this.ganadorDataGridViewTextBoxColumn.Name = "ganadorDataGridViewTextBoxColumn";
            // 
            // contricanteDataGridViewTextBoxColumn
            // 
            this.contricanteDataGridViewTextBoxColumn.DataPropertyName = "Contricante";
            this.contricanteDataGridViewTextBoxColumn.HeaderText = "Contricante";
            this.contricanteDataGridViewTextBoxColumn.Name = "contricanteDataGridViewTextBoxColumn";
            // 
            // jugadorDataGridViewTextBoxColumn
            // 
            this.jugadorDataGridViewTextBoxColumn.DataPropertyName = "Jugador";
            this.jugadorDataGridViewTextBoxColumn.HeaderText = "Jugador";
            this.jugadorDataGridViewTextBoxColumn.Name = "jugadorDataGridViewTextBoxColumn";
            // 
            // tabla_partida
            // 
            this.tabla_partida.AutoGenerateColumns = false;
            this.tabla_partida.BackgroundColor = System.Drawing.Color.Black;
            this.tabla_partida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabla_partida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_partida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jugadorDataGridViewTextBoxColumn,
            this.contricanteDataGridViewTextBoxColumn,
            this.ganadorDataGridViewTextBoxColumn});
            this.tabla_partida.DataSource = this.partidaBindingSource;
            this.tabla_partida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tabla_partida.Location = new System.Drawing.Point(111, 298);
            this.tabla_partida.Name = "tabla_partida";
            this.tabla_partida.Size = new System.Drawing.Size(360, 150);
            this.tabla_partida.TabIndex = 6;
            // 
            // Score_option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tabla_partida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabla_estadisticas);
            this.Controls.Add(this.label_inicio);
            this.Name = "Score_option";
            this.Size = new System.Drawing.Size(598, 477);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_estadisticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_partida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_inicio;
        private System.Windows.Forms.DataGridView tabla_estadisticas;
        private System.Windows.Forms.BindingSource estadisticaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn disparosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource partidaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ganadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contricanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jugadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView tabla_partida;
    }
}
