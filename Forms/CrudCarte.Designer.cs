namespace Biblioteca.Forms { 
    partial class CrudCarte
    {
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTitlu;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox listBoxBooks;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtId = new TextBox();
            txtTitlu = new TextBox();
            txtDescriere = new TextBox();
            txtAutor = new TextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            listBoxBooks = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(583, 13);
            txtId.Name = "txtId";
            txtId.Size = new Size(228, 27);
            txtId.TabIndex = 0;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtTitlu
            // 
            txtTitlu.Location = new Point(583, 46);
            txtTitlu.Name = "txtTitlu";
            txtTitlu.Size = new Size(228, 27);
            txtTitlu.TabIndex = 1;
            // 
            // txtDescriere
            // 
            txtDescriere.Location = new Point(583, 79);
            txtDescriere.Name = "txtDescriere";
            txtDescriere.Size = new Size(228, 27);
            txtDescriere.TabIndex = 2;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(583, 112);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(228, 27);
            txtAutor.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(583, 145);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(228, 36);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Adauga Carte";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(583, 187);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(228, 36);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Sterge Carte";
            btnRemove.Click += btnRemove_Click;
            // 
            // listBoxBooks
            // 
            listBoxBooks.Location = new Point(0, 1);
            listBoxBooks.Name = "listBoxBooks";
            listBoxBooks.Size = new Size(490, 484);
            listBoxBooks.TabIndex = 11;
            listBoxBooks.SelectedIndexChanged += listBoxBooks_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(506, 16);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 7;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 49);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 8;
            label2.Text = "Titlu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(506, 82);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 9;
            label3.Text = "Descriere";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(506, 115);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 10;
            label4.Text = "Autor";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CrudCarte
            // 
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(txtTitlu);
            Controls.Add(txtDescriere);
            Controls.Add(txtAutor);
            Controls.Add(btnAdd);
            Controls.Add(btnRemove);
            Controls.Add(listBoxBooks);
            Name = "CrudCarte";
            Size = new Size(840, 474);
            Load += CrudCarte_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.ComponentModel.IContainer components;
        private ErrorProvider errorProvider1;
    }
}