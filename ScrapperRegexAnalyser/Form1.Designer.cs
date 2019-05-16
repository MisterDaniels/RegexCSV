namespace ScrapperRegexAnalyser {
    partial class Form1 {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.validateButton = new System.Windows.Forms.Button();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(293, 420);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 20);
            this.validateButton.TabIndex = 0;
            this.validateButton.Text = "Validar";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // resultsGridView
            // 
            this.resultsGridView.AllowDrop = true;
            this.resultsGridView.AllowUserToAddRows = false;
            this.resultsGridView.AllowUserToDeleteRows = false;
            this.resultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.regex,
            this.result,
            this.link});
            this.resultsGridView.Location = new System.Drawing.Point(12, 12);
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.ReadOnly = true;
            this.resultsGridView.Size = new System.Drawing.Size(776, 399);
            this.resultsGridView.TabIndex = 1;
            // 
            // title
            // 
            this.title.HeaderText = "Título";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // regex
            // 
            this.regex.HeaderText = "Regex";
            this.regex.Name = "regex";
            this.regex.ReadOnly = true;
            // 
            // result
            // 
            this.result.HeaderText = "Resultado";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // link
            // 
            this.link.HeaderText = "Link";
            this.link.Name = "link";
            this.link.ReadOnly = true;
            // 
            // linkInput
            // 
            this.linkInput.Location = new System.Drawing.Point(12, 420);
            this.linkInput.Name = "linkInput";
            this.linkInput.Size = new System.Drawing.Size(275, 20);
            this.linkInput.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.linkInput);
            this.Controls.Add(this.resultsGridView);
            this.Controls.Add(this.validateButton);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.DataGridView resultsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn regex;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn link;
        private System.Windows.Forms.TextBox linkInput;
    }
}

