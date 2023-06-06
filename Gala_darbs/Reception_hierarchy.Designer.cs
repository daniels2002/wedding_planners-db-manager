namespace Gala_darbs
{
    partial class Reception_hierarchy
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
            this.reception_treeView = new System.Windows.Forms.TreeView();
            this.description = new System.Windows.Forms.Label();
            this.Save_changes = new System.Windows.Forms.Button();
            this.reception_datagridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reception_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // reception_treeView
            // 
            this.reception_treeView.Location = new System.Drawing.Point(24, 28);
            this.reception_treeView.Name = "reception_treeView";
            this.reception_treeView.Size = new System.Drawing.Size(276, 353);
            this.reception_treeView.TabIndex = 0;
            this.reception_treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.reception_treeView_AfterLabelEdit);
            this.reception_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.reception_treeView_NodeMouseClick);
            this.reception_treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.reception_treeView_NodeMouseDoubleClick);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(21, 404);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 16);
            this.description.TabIndex = 1;
            // 
            // Save_changes
            // 
            this.Save_changes.BackColor = System.Drawing.Color.GreenYellow;
            this.Save_changes.Location = new System.Drawing.Point(687, 326);
            this.Save_changes.Name = "Save_changes";
            this.Save_changes.Size = new System.Drawing.Size(155, 55);
            this.Save_changes.TabIndex = 4;
            this.Save_changes.Text = "Save";
            this.Save_changes.UseVisualStyleBackColor = false;
            this.Save_changes.Click += new System.EventHandler(this.Save_changes_Click);
            // 
            // reception_datagridview
            // 
            this.reception_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reception_datagridview.Location = new System.Drawing.Point(323, 28);
            this.reception_datagridview.Name = "reception_datagridview";
            this.reception_datagridview.RowHeadersWidth = 51;
            this.reception_datagridview.RowTemplate.Height = 24;
            this.reception_datagridview.Size = new System.Drawing.Size(820, 272);
            this.reception_datagridview.TabIndex = 6;
            this.reception_datagridview.Click += new System.EventHandler(this.reception_datagridview_Click);
            // 
            // Reception_hierarchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1155, 403);
            this.Controls.Add(this.reception_datagridview);
            this.Controls.Add(this.Save_changes);
            this.Controls.Add(this.description);
            this.Controls.Add(this.reception_treeView);
            this.Name = "Reception_hierarchy";
            this.Text = "Reception_hierarchy";
            ((System.ComponentModel.ISupportInitialize)(this.reception_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView reception_treeView;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button Save_changes;
        private System.Windows.Forms.DataGridView reception_datagridview;
    }
}