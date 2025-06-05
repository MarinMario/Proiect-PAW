using Biblioteca.Data;

namespace Biblioteca.Forms
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            crudCarte1 = new CrudCarte();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            crudCititor1 = new CrudCititor();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(958, 638);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(crudCarte1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(950, 605);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Carti";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // crudCarte1
            // 
            crudCarte1.Location = new Point(0, 0);
            crudCarte1.Name = "crudCarte1";
            crudCarte1.Size = new Size(944, 496);
            crudCarte1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(crudCititor1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(950, 605);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cititori";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(950, 605);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Imprumuturi";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // crudCititor1
            // 
            crudCititor1.Location = new Point(0, 0);
            crudCititor1.Name = "crudCititor1";
            crudCititor1.Size = new Size(855, 505);
            crudCititor1.TabIndex = 0;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 638);
            Controls.Add(tabControl1);
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CrudCarte crudCarte1;
        private TabPage tabPage3;
        private CrudCititor crudCititor1;
    }
}