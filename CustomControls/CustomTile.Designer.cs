namespace CustomControls
{
    partial class CustomTile
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.monsterHp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // monsterHp
            // 
            this.monsterHp.AutoSize = true;
            this.monsterHp.BackColor = System.Drawing.Color.Transparent;
            this.monsterHp.ForeColor = System.Drawing.Color.White;
            this.monsterHp.Location = new System.Drawing.Point(0, 0);
            this.monsterHp.Name = "monsterHp";
            this.monsterHp.Size = new System.Drawing.Size(100, 23);
            this.monsterHp.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label monsterHp;
    }
}
