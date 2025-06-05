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
            crudCititor1 = new CrudCititor();
            tabPage3 = new TabPage();
            crudImprumut1 = new CrudImprumut();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            printDocumentToolStripMenuItem = new ToolStripMenuItem();
            exportTXTFileToolStripMenuItem = new ToolStripMenuItem();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 36);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(918, 532);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(crudCarte1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(910, 499);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Carti";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // crudCarte1
            // 
            crudCarte1.Location = new Point(0, 0);
            crudCarte1.Name = "crudCarte1";
            crudCarte1.Size = new Size(931, 491);
            crudCarte1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(crudCititor1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(910, 499);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cititori";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // crudCititor1
            // 
            crudCititor1.Location = new Point(0, 0);
            crudCititor1.Name = "crudCititor1";
            crudCititor1.Size = new Size(855, 505);
            crudCititor1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(crudImprumut1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(910, 499);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Imprumuturi";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // crudImprumut1
            // 
            crudImprumut1.Location = new Point(0, 0);
            crudImprumut1.Name = "crudImprumut1";
            crudImprumut1.Size = new Size(927, 517);
            crudImprumut1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 612);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(961, 26);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(961, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { printDocumentToolStripMenuItem, exportTXTFileToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(66, 24);
            toolStripMenuItem1.Text = "Export";
            // 
            // printDocumentToolStripMenuItem
            // 
            printDocumentToolStripMenuItem.Name = "printDocumentToolStripMenuItem";
            printDocumentToolStripMenuItem.Size = new Size(224, 26);
            printDocumentToolStripMenuItem.Text = "Print Document";
            printDocumentToolStripMenuItem.Click += printDocumentToolStripMenuItem_Click;
            // 
            // exportTXTFileToolStripMenuItem
            // 
            exportTXTFileToolStripMenuItem.Name = "exportTXTFileToolStripMenuItem";
            exportTXTFileToolStripMenuItem.Size = new Size(224, 26);
            exportTXTFileToolStripMenuItem.Text = "Export TXT File";
            exportTXTFileToolStripMenuItem.Click += exportTXTFileToolStripMenuItem_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 638);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            MainMenuStrip = menuStrip1;
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CrudCarte crudCarte1;
        private TabPage tabPage3;
        private CrudCititor crudCititor1;
        private CrudImprumut crudImprumut1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem printDocumentToolStripMenuItem;
        private ToolStripMenuItem exportTXTFileToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}