namespace MainPrototype
{
    partial class GameScreen
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.hpLabel = new System.Windows.Forms.Label();
            this.AtkLabel = new System.Windows.Forms.Label();
            this.DefLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.LuckLabel = new System.Windows.Forms.Label();
            this.HpModLbl = new System.Windows.Forms.Label();
            this.AtkModLbl = new System.Windows.Forms.Label();
            this.DefModLbl = new System.Windows.Forms.Label();
            this.SpeedModLbl = new System.Windows.Forms.Label();
            this.LuckModLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.PointLabel = new System.Windows.Forms.Label();
            this.UpdatePlayer = new System.Windows.Forms.Timer(this.components);
            this.passTurn = new System.Windows.Forms.Button();
            this.LblItemAtual = new System.Windows.Forms.Label();
            this.LblDescAtual = new System.Windows.Forms.Label();
            this.LblDurabilty = new System.Windows.Forms.Label();
            this.LblPoolItem = new System.Windows.Forms.Label();
            this.lblPoolHp = new System.Windows.Forms.Label();
            this.lblPoolSpeed = new System.Windows.Forms.Label();
            this.lblPoolAtk = new System.Windows.Forms.Label();
            this.lblPoolRange = new System.Windows.Forms.Label();
            this.lblPoolDef = new System.Windows.Forms.Label();
            this.lblPoolLuck = new System.Windows.Forms.Label();
            this.poolSpeed = new System.Windows.Forms.PictureBox();
            this.poolHp = new System.Windows.Forms.PictureBox();
            this.poolLuck = new System.Windows.Forms.PictureBox();
            this.poolDef = new System.Windows.Forms.PictureBox();
            this.poolRange = new System.Windows.Forms.PictureBox();
            this.poolAtk = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.PoolItemPic = new System.Windows.Forms.PictureBox();
            this.ItemAtualPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.patricioPic = new System.Windows.Forms.PictureBox();
            this.LuckIcon = new System.Windows.Forms.PictureBox();
            this.RangeIcon = new System.Windows.Forms.PictureBox();
            this.SpeedIcon = new System.Windows.Forms.PictureBox();
            this.defIcon = new System.Windows.Forms.PictureBox();
            this.AtkIcon = new System.Windows.Forms.PictureBox();
            this.hpIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.poolSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolAtk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoolItemPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAtualPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patricioPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuckIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtkIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_TickAsync);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(793, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 562);
            this.panel1.TabIndex = 0;
            // 
            // hpLabel
            // 
            this.hpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpLabel.Location = new System.Drawing.Point(857, 101);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(97, 33);
            this.hpLabel.TabIndex = 7;
            this.hpLabel.Text = "0/0";
            this.hpLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // AtkLabel
            // 
            this.AtkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtkLabel.Location = new System.Drawing.Point(858, 138);
            this.AtkLabel.Name = "AtkLabel";
            this.AtkLabel.Size = new System.Drawing.Size(97, 33);
            this.AtkLabel.TabIndex = 7;
            this.AtkLabel.Text = "0";
            this.AtkLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DefLabel
            // 
            this.DefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefLabel.Location = new System.Drawing.Point(858, 177);
            this.DefLabel.Name = "DefLabel";
            this.DefLabel.Size = new System.Drawing.Size(97, 33);
            this.DefLabel.TabIndex = 7;
            this.DefLabel.Text = "0";
            this.DefLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedLabel.Location = new System.Drawing.Point(858, 216);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(97, 33);
            this.SpeedLabel.TabIndex = 7;
            this.SpeedLabel.Text = "0/0";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RangeLabel
            // 
            this.RangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeLabel.Location = new System.Drawing.Point(858, 255);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(97, 33);
            this.RangeLabel.TabIndex = 7;
            this.RangeLabel.Text = "0";
            this.RangeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LuckLabel
            // 
            this.LuckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LuckLabel.Location = new System.Drawing.Point(858, 294);
            this.LuckLabel.Name = "LuckLabel";
            this.LuckLabel.Size = new System.Drawing.Size(97, 33);
            this.LuckLabel.TabIndex = 7;
            this.LuckLabel.Text = "0%";
            this.LuckLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // HpModLbl
            // 
            this.HpModLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HpModLbl.Location = new System.Drawing.Point(973, 103);
            this.HpModLbl.Name = "HpModLbl";
            this.HpModLbl.Size = new System.Drawing.Size(53, 31);
            this.HpModLbl.TabIndex = 7;
            this.HpModLbl.Text = "+ 0";
            this.HpModLbl.Visible = false;
            // 
            // AtkModLbl
            // 
            this.AtkModLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtkModLbl.Location = new System.Drawing.Point(973, 148);
            this.AtkModLbl.Name = "AtkModLbl";
            this.AtkModLbl.Size = new System.Drawing.Size(53, 25);
            this.AtkModLbl.TabIndex = 7;
            this.AtkModLbl.Text = "+ 0";
            this.AtkModLbl.Visible = false;
            // 
            // DefModLbl
            // 
            this.DefModLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefModLbl.Location = new System.Drawing.Point(973, 187);
            this.DefModLbl.Name = "DefModLbl";
            this.DefModLbl.Size = new System.Drawing.Size(53, 25);
            this.DefModLbl.TabIndex = 7;
            this.DefModLbl.Text = "+ 0";
            this.DefModLbl.Visible = false;
            // 
            // SpeedModLbl
            // 
            this.SpeedModLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedModLbl.Location = new System.Drawing.Point(973, 226);
            this.SpeedModLbl.Name = "SpeedModLbl";
            this.SpeedModLbl.Size = new System.Drawing.Size(53, 25);
            this.SpeedModLbl.TabIndex = 7;
            this.SpeedModLbl.Text = "+ 0";
            this.SpeedModLbl.Visible = false;
            // 
            // LuckModLbl
            // 
            this.LuckModLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LuckModLbl.Location = new System.Drawing.Point(973, 304);
            this.LuckModLbl.Name = "LuckModLbl";
            this.LuckModLbl.Size = new System.Drawing.Size(53, 25);
            this.LuckModLbl.TabIndex = 7;
            this.LuckModLbl.Text = "+ 0";
            this.LuckModLbl.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(833, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(833, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(833, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(833, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(833, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(833, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = ":";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.Location = new System.Drawing.Point(1080, 40);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(75, 20);
            this.turnLabel.TabIndex = 9;
            this.turnLabel.Text = "Turno: 0";
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLabel.Location = new System.Drawing.Point(1080, 65);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(85, 20);
            this.PointLabel.TabIndex = 9;
            this.PointLabel.Text = "Pontos: 0";
            // 
            // UpdatePlayer
            // 
            this.UpdatePlayer.Enabled = true;
            this.UpdatePlayer.Interval = 2000;
            this.UpdatePlayer.Tick += new System.EventHandler(this.UpdatePlayer_Tick);
            // 
            // passTurn
            // 
            this.passTurn.BackColor = System.Drawing.Color.White;
            this.passTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passTurn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTurn.Location = new System.Drawing.Point(1003, 40);
            this.passTurn.Name = "passTurn";
            this.passTurn.Size = new System.Drawing.Size(62, 45);
            this.passTurn.TabIndex = 11;
            this.passTurn.Text = "Passar turno";
            this.passTurn.UseVisualStyleBackColor = false;
            this.passTurn.Click += new System.EventHandler(this.passTurn_Click);
            // 
            // LblItemAtual
            // 
            this.LblItemAtual.AutoSize = true;
            this.LblItemAtual.BackColor = System.Drawing.Color.Transparent;
            this.LblItemAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblItemAtual.Location = new System.Drawing.Point(927, 344);
            this.LblItemAtual.Name = "LblItemAtual";
            this.LblItemAtual.Size = new System.Drawing.Size(24, 20);
            this.LblItemAtual.TabIndex = 12;
            this.LblItemAtual.Text = "   ";
            // 
            // LblDescAtual
            // 
            this.LblDescAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescAtual.Location = new System.Drawing.Point(927, 376);
            this.LblDescAtual.Name = "LblDescAtual";
            this.LblDescAtual.Size = new System.Drawing.Size(260, 70);
            this.LblDescAtual.TabIndex = 13;
            // 
            // LblDurabilty
            // 
            this.LblDurabilty.AutoSize = true;
            this.LblDurabilty.BackColor = System.Drawing.Color.Transparent;
            this.LblDurabilty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDurabilty.Location = new System.Drawing.Point(1163, 344);
            this.LblDurabilty.Name = "LblDurabilty";
            this.LblDurabilty.Size = new System.Drawing.Size(24, 20);
            this.LblDurabilty.TabIndex = 14;
            this.LblDurabilty.Text = "   ";
            // 
            // LblPoolItem
            // 
            this.LblPoolItem.AutoSize = true;
            this.LblPoolItem.BackColor = System.Drawing.Color.Transparent;
            this.LblPoolItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPoolItem.Location = new System.Drawing.Point(893, 467);
            this.LblPoolItem.Name = "LblPoolItem";
            this.LblPoolItem.Size = new System.Drawing.Size(24, 20);
            this.LblPoolItem.TabIndex = 15;
            this.LblPoolItem.Text = "   ";
            // 
            // lblPoolHp
            // 
            this.lblPoolHp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolHp.Location = new System.Drawing.Point(922, 495);
            this.lblPoolHp.Name = "lblPoolHp";
            this.lblPoolHp.Size = new System.Drawing.Size(32, 24);
            this.lblPoolHp.TabIndex = 7;
            this.lblPoolHp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolHp.Visible = false;
            // 
            // lblPoolSpeed
            // 
            this.lblPoolSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolSpeed.Location = new System.Drawing.Point(923, 522);
            this.lblPoolSpeed.Name = "lblPoolSpeed";
            this.lblPoolSpeed.Size = new System.Drawing.Size(32, 24);
            this.lblPoolSpeed.TabIndex = 7;
            this.lblPoolSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolSpeed.Visible = false;
            // 
            // lblPoolAtk
            // 
            this.lblPoolAtk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolAtk.Location = new System.Drawing.Point(1025, 495);
            this.lblPoolAtk.Name = "lblPoolAtk";
            this.lblPoolAtk.Size = new System.Drawing.Size(32, 24);
            this.lblPoolAtk.TabIndex = 7;
            this.lblPoolAtk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolAtk.Visible = false;
            // 
            // lblPoolRange
            // 
            this.lblPoolRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolRange.Location = new System.Drawing.Point(1025, 522);
            this.lblPoolRange.Name = "lblPoolRange";
            this.lblPoolRange.Size = new System.Drawing.Size(32, 24);
            this.lblPoolRange.TabIndex = 7;
            this.lblPoolRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolRange.Visible = false;
            // 
            // lblPoolDef
            // 
            this.lblPoolDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolDef.Location = new System.Drawing.Point(1123, 495);
            this.lblPoolDef.Name = "lblPoolDef";
            this.lblPoolDef.Size = new System.Drawing.Size(32, 24);
            this.lblPoolDef.TabIndex = 7;
            this.lblPoolDef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolDef.Visible = false;
            // 
            // lblPoolLuck
            // 
            this.lblPoolLuck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoolLuck.Location = new System.Drawing.Point(1123, 522);
            this.lblPoolLuck.Name = "lblPoolLuck";
            this.lblPoolLuck.Size = new System.Drawing.Size(32, 24);
            this.lblPoolLuck.TabIndex = 7;
            this.lblPoolLuck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPoolLuck.Visible = false;
            // 
            // poolSpeed
            // 
            this.poolSpeed.BackColor = System.Drawing.Color.Transparent;
            this.poolSpeed.BackgroundImage = global::MainPrototype.Properties.Resources.Speed;
            this.poolSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolSpeed.Location = new System.Drawing.Point(895, 522);
            this.poolSpeed.Name = "poolSpeed";
            this.poolSpeed.Size = new System.Drawing.Size(24, 24);
            this.poolSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolSpeed.TabIndex = 16;
            this.poolSpeed.TabStop = false;
            // 
            // poolHp
            // 
            this.poolHp.BackColor = System.Drawing.Color.Transparent;
            this.poolHp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolHp.Image = global::MainPrototype.Properties.Resources.Vida;
            this.poolHp.Location = new System.Drawing.Point(895, 495);
            this.poolHp.Name = "poolHp";
            this.poolHp.Size = new System.Drawing.Size(24, 24);
            this.poolHp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolHp.TabIndex = 16;
            this.poolHp.TabStop = false;
            // 
            // poolLuck
            // 
            this.poolLuck.BackColor = System.Drawing.Color.Transparent;
            this.poolLuck.BackgroundImage = global::MainPrototype.Properties.Resources.Lucky;
            this.poolLuck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolLuck.Location = new System.Drawing.Point(1095, 522);
            this.poolLuck.Name = "poolLuck";
            this.poolLuck.Size = new System.Drawing.Size(24, 24);
            this.poolLuck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolLuck.TabIndex = 16;
            this.poolLuck.TabStop = false;
            // 
            // poolDef
            // 
            this.poolDef.BackColor = System.Drawing.Color.Transparent;
            this.poolDef.BackgroundImage = global::MainPrototype.Properties.Resources.Def;
            this.poolDef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolDef.Location = new System.Drawing.Point(1095, 495);
            this.poolDef.Name = "poolDef";
            this.poolDef.Size = new System.Drawing.Size(24, 24);
            this.poolDef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolDef.TabIndex = 16;
            this.poolDef.TabStop = false;
            // 
            // poolRange
            // 
            this.poolRange.BackColor = System.Drawing.Color.Transparent;
            this.poolRange.BackgroundImage = global::MainPrototype.Properties.Resources.Range;
            this.poolRange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolRange.Location = new System.Drawing.Point(995, 522);
            this.poolRange.Name = "poolRange";
            this.poolRange.Size = new System.Drawing.Size(24, 24);
            this.poolRange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolRange.TabIndex = 16;
            this.poolRange.TabStop = false;
            // 
            // poolAtk
            // 
            this.poolAtk.BackColor = System.Drawing.Color.Transparent;
            this.poolAtk.BackgroundImage = global::MainPrototype.Properties.Resources.Atk;
            this.poolAtk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.poolAtk.Location = new System.Drawing.Point(995, 495);
            this.poolAtk.Name = "poolAtk";
            this.poolAtk.Size = new System.Drawing.Size(24, 24);
            this.poolAtk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poolAtk.TabIndex = 16;
            this.poolAtk.TabStop = false;
            // 
            // close
            // 
            this.close.Image = global::MainPrototype.Properties.Resources.multiply;
            this.close.Location = new System.Drawing.Point(1163, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(36, 31);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close.TabIndex = 10;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // PoolItemPic
            // 
            this.PoolItemPic.BackColor = System.Drawing.Color.Transparent;
            this.PoolItemPic.Location = new System.Drawing.Point(805, 467);
            this.PoolItemPic.Name = "PoolItemPic";
            this.PoolItemPic.Size = new System.Drawing.Size(82, 76);
            this.PoolItemPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PoolItemPic.TabIndex = 8;
            this.PoolItemPic.TabStop = false;
            this.PoolItemPic.Click += new System.EventHandler(this.PoolItemPic_Click);
            // 
            // ItemAtualPic
            // 
            this.ItemAtualPic.BackColor = System.Drawing.Color.Transparent;
            this.ItemAtualPic.Location = new System.Drawing.Point(804, 344);
            this.ItemAtualPic.Name = "ItemAtualPic";
            this.ItemAtualPic.Size = new System.Drawing.Size(102, 102);
            this.ItemAtualPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ItemAtualPic.TabIndex = 8;
            this.ItemAtualPic.TabStop = false;
            this.ItemAtualPic.Click += new System.EventHandler(this.ItemAtualPic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(804, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // patricioPic
            // 
            this.patricioPic.BackColor = System.Drawing.Color.Transparent;
            this.patricioPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.patricioPic.Image = ((System.Drawing.Image)(resources.GetObject("patricioPic.Image")));
            this.patricioPic.Location = new System.Drawing.Point(1021, 101);
            this.patricioPic.Name = "patricioPic";
            this.patricioPic.Size = new System.Drawing.Size(178, 228);
            this.patricioPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.patricioPic.TabIndex = 8;
            this.patricioPic.TabStop = false;
            // 
            // LuckIcon
            // 
            this.LuckIcon.BackColor = System.Drawing.Color.Transparent;
            this.LuckIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Lucky;
            this.LuckIcon.Location = new System.Drawing.Point(804, 296);
            this.LuckIcon.Name = "LuckIcon";
            this.LuckIcon.Size = new System.Drawing.Size(32, 32);
            this.LuckIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LuckIcon.TabIndex = 6;
            this.LuckIcon.TabStop = false;
            // 
            // RangeIcon
            // 
            this.RangeIcon.BackColor = System.Drawing.Color.Transparent;
            this.RangeIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Range;
            this.RangeIcon.Location = new System.Drawing.Point(804, 257);
            this.RangeIcon.Name = "RangeIcon";
            this.RangeIcon.Size = new System.Drawing.Size(32, 32);
            this.RangeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RangeIcon.TabIndex = 5;
            this.RangeIcon.TabStop = false;
            // 
            // SpeedIcon
            // 
            this.SpeedIcon.BackColor = System.Drawing.Color.Transparent;
            this.SpeedIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Speed;
            this.SpeedIcon.Location = new System.Drawing.Point(804, 218);
            this.SpeedIcon.Name = "SpeedIcon";
            this.SpeedIcon.Size = new System.Drawing.Size(32, 32);
            this.SpeedIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpeedIcon.TabIndex = 4;
            this.SpeedIcon.TabStop = false;
            // 
            // defIcon
            // 
            this.defIcon.BackColor = System.Drawing.Color.Transparent;
            this.defIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Def;
            this.defIcon.Location = new System.Drawing.Point(804, 179);
            this.defIcon.Name = "defIcon";
            this.defIcon.Size = new System.Drawing.Size(32, 32);
            this.defIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.defIcon.TabIndex = 3;
            this.defIcon.TabStop = false;
            // 
            // AtkIcon
            // 
            this.AtkIcon.BackColor = System.Drawing.Color.Transparent;
            this.AtkIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Atk;
            this.AtkIcon.Location = new System.Drawing.Point(804, 140);
            this.AtkIcon.Name = "AtkIcon";
            this.AtkIcon.Size = new System.Drawing.Size(32, 32);
            this.AtkIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AtkIcon.TabIndex = 2;
            this.AtkIcon.TabStop = false;
            // 
            // hpIcon
            // 
            this.hpIcon.BackColor = System.Drawing.Color.Transparent;
            this.hpIcon.BackgroundImage = global::MainPrototype.Properties.Resources.Vida;
            this.hpIcon.Location = new System.Drawing.Point(804, 101);
            this.hpIcon.Name = "hpIcon";
            this.hpIcon.Size = new System.Drawing.Size(32, 32);
            this.hpIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hpIcon.TabIndex = 1;
            this.hpIcon.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 561);
            this.Controls.Add(this.poolSpeed);
            this.Controls.Add(this.poolHp);
            this.Controls.Add(this.poolLuck);
            this.Controls.Add(this.poolDef);
            this.Controls.Add(this.poolRange);
            this.Controls.Add(this.poolAtk);
            this.Controls.Add(this.LblPoolItem);
            this.Controls.Add(this.LblDurabilty);
            this.Controls.Add(this.LblDescAtual);
            this.Controls.Add(this.LblItemAtual);
            this.Controls.Add(this.passTurn);
            this.Controls.Add(this.hpLabel);
            this.Controls.Add(this.close);
            this.Controls.Add(this.PointLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.PoolItemPic);
            this.Controls.Add(this.ItemAtualPic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.patricioPic);
            this.Controls.Add(this.LuckLabel);
            this.Controls.Add(this.RangeLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.DefLabel);
            this.Controls.Add(this.lblPoolLuck);
            this.Controls.Add(this.lblPoolDef);
            this.Controls.Add(this.lblPoolRange);
            this.Controls.Add(this.lblPoolAtk);
            this.Controls.Add(this.lblPoolSpeed);
            this.Controls.Add(this.lblPoolHp);
            this.Controls.Add(this.LuckModLbl);
            this.Controls.Add(this.SpeedModLbl);
            this.Controls.Add(this.DefModLbl);
            this.Controls.Add(this.AtkModLbl);
            this.Controls.Add(this.HpModLbl);
            this.Controls.Add(this.AtkLabel);
            this.Controls.Add(this.LuckIcon);
            this.Controls.Add(this.RangeIcon);
            this.Controls.Add(this.SpeedIcon);
            this.Controls.Add(this.defIcon);
            this.Controls.Add(this.AtkIcon);
            this.Controls.Add(this.hpIcon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameScreen_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.poolSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poolAtk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoolItemPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAtualPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patricioPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuckIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtkIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox hpIcon;
        private System.Windows.Forms.PictureBox AtkIcon;
        private System.Windows.Forms.PictureBox defIcon;
        private System.Windows.Forms.PictureBox SpeedIcon;
        private System.Windows.Forms.PictureBox RangeIcon;
        private System.Windows.Forms.PictureBox LuckIcon;
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.Label AtkLabel;
        private System.Windows.Forms.Label DefLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label LuckLabel;
        private System.Windows.Forms.Label HpModLbl;
        private System.Windows.Forms.Label AtkModLbl;
        private System.Windows.Forms.Label DefModLbl;
        private System.Windows.Forms.Label SpeedModLbl;
        private System.Windows.Forms.Label LuckModLbl;
        private System.Windows.Forms.PictureBox patricioPic;
        private System.Windows.Forms.PictureBox ItemAtualPic;
        private System.Windows.Forms.PictureBox PoolItemPic;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label PointLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer UpdatePlayer;
        private System.Windows.Forms.Button passTurn;
        private System.Windows.Forms.Label LblItemAtual;
        private System.Windows.Forms.Label LblDescAtual;
        private System.Windows.Forms.Label LblDurabilty;
        private System.Windows.Forms.Label LblPoolItem;
        private System.Windows.Forms.PictureBox poolAtk;
        private System.Windows.Forms.PictureBox poolHp;
        private System.Windows.Forms.PictureBox poolSpeed;
        private System.Windows.Forms.PictureBox poolRange;
        private System.Windows.Forms.PictureBox poolDef;
        private System.Windows.Forms.PictureBox poolLuck;
        private System.Windows.Forms.Label lblPoolHp;
        private System.Windows.Forms.Label lblPoolSpeed;
        private System.Windows.Forms.Label lblPoolAtk;
        private System.Windows.Forms.Label lblPoolRange;
        private System.Windows.Forms.Label lblPoolDef;
        private System.Windows.Forms.Label lblPoolLuck;
    }
}

