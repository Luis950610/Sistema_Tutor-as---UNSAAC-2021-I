namespace STutoria.App.Auxiliares
{
    partial class FormTutores
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTutores));
            this.gcDocente = new DevExpress.XtraGrid.GridControl();
            this.gvDocente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDocente
            // 
            this.gcDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDocente.Location = new System.Drawing.Point(3, 159);
            this.gcDocente.MainView = this.gvDocente;
            this.gcDocente.Name = "gcDocente";
            this.gcDocente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcDocente.Size = new System.Drawing.Size(936, 423);
            this.gcDocente.TabIndex = 25;
            this.gcDocente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocente});
            // 
            // gvDocente
            // 
            this.gvDocente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn7});
            this.gvDocente.GridControl = this.gcDocente;
            this.gvDocente.Name = "gvDocente";
            this.gvDocente.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cod. Docente";
            this.gridColumn1.FieldName = "CodDocente";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nombres";
            this.gridColumn2.FieldName = "Nombres";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 105;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ap. Paterno";
            this.gridColumn3.FieldName = "ApellidoPaterno";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 88;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ap. Materno";
            this.gridColumn4.FieldName = "ApellidoMaterno";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 83;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Clase";
            this.gridColumn5.FieldName = "Clase";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 63;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Categoria";
            this.gridColumn6.FieldName = "Categoria";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Regimen";
            this.gridColumn9.FieldName = "Regimen";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 47;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Carrera Profesional";
            this.gridColumn10.FieldName = "CarreraProfesional";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 91;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Seleccionar";
            this.gridColumn7.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 41;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            editorButtonImageOptions1.Location = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.Click += new System.EventHandler(this.repositoryItemButtonEdit1_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(652, 80);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(86, 50);
            this.simpleButton4.TabIndex = 24;
            this.simpleButton4.Text = "Buscar";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // textEdit7
            // 
            this.textEdit7.Location = new System.Drawing.Point(314, 111);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textEdit7.Properties.Appearance.Options.UseFont = true;
            this.textEdit7.Size = new System.Drawing.Size(307, 22);
            this.textEdit7.TabIndex = 22;
            // 
            // textEdit6
            // 
            this.textEdit6.Location = new System.Drawing.Point(314, 77);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textEdit6.Properties.Appearance.Options.UseFont = true;
            this.textEdit6.Size = new System.Drawing.Size(307, 22);
            this.textEdit6.TabIndex = 21;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(245, 114);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(63, 19);
            this.labelControl11.TabIndex = 20;
            this.labelControl11.Text = "Nombre:";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(196, 78);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(96, 19);
            this.labelControl16.TabIndex = 19;
            this.labelControl16.Text = "Cod Docente:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(366, 26);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(162, 19);
            this.labelControl10.TabIndex = 18;
            this.labelControl10.Text = "REALIZAR BÚSQUEDA";
            // 
            // FormTutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 584);
            this.Controls.Add(this.gcDocente);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.textEdit7);
            this.Controls.Add(this.textEdit6);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl10);
            this.Name = "FormTutores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tutores";
            ((System.ComponentModel.ISupportInitialize)(this.gcDocente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDocente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.TextEdit textEdit7;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}