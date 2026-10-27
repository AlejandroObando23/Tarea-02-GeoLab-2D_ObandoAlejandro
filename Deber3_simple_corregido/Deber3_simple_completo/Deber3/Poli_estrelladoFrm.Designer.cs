namespace Deber3
{
    partial class Poli_estrelladoFrm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblN = new System.Windows.Forms.Label();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.lblRadio = new System.Windows.Forms.Label();
            this.nudRadio = new System.Windows.Forms.NumericUpDown();
            this.lblRazon = new System.Windows.Forms.Label();
            this.nudRazon = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.lblAngulo = new System.Windows.Forms.Label();
            this.nudAngulo = new System.Windows.Forms.NumericUpDown();
            this.lblEscala = new System.Windows.Forms.Label();
            this.nudEscala = new System.Windows.Forms.NumericUpDown();
            this.lblParte = new System.Windows.Forms.Label();
            this.cmbParte = new System.Windows.Forms.ComboBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.picLienzo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEscala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(820, 23);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(56, 13);
            this.lblN.TabIndex = 1;
            this.lblN.Text = "N (puntas)";
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(960, 20);
            this.nudN.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudN.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(120, 20);
            this.nudN.TabIndex = 2;
            this.nudN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudN.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(820, 55);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(35, 13);
            this.lblRadio.TabIndex = 3;
            this.lblRadio.Text = "Radio";
            // 
            // nudRadio
            // 
            this.nudRadio.Location = new System.Drawing.Point(960, 52);
            this.nudRadio.Maximum = new decimal(new int[] {
            290,
            0,
            0,
            0});
            this.nudRadio.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRadio.Name = "nudRadio";
            this.nudRadio.Size = new System.Drawing.Size(120, 20);
            this.nudRadio.TabIndex = 4;
            this.nudRadio.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudRadio.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Location = new System.Drawing.Point(820, 87);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(86, 13);
            this.lblRazon.TabIndex = 5;
            this.lblRazon.Text = "Radio interior (%)";
            // 
            // nudRazon
            // 
            this.nudRazon.Location = new System.Drawing.Point(960, 84);
            this.nudRazon.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.nudRazon.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRazon.Name = "nudRazon";
            this.nudRazon.Size = new System.Drawing.Size(120, 20);
            this.nudRazon.TabIndex = 6;
            this.nudRazon.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudRazon.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(820, 119);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(57, 13);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "Posición X";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(960, 116);
            this.nudX.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(120, 20);
            this.nudX.TabIndex = 8;
            this.nudX.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(820, 151);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(57, 13);
            this.lblY.TabIndex = 9;
            this.lblY.Text = "Posición Y";
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(960, 148);
            this.nudY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(120, 20);
            this.nudY.TabIndex = 10;
            this.nudY.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblAngulo
            // 
            this.lblAngulo.AutoSize = true;
            this.lblAngulo.Location = new System.Drawing.Point(820, 183);
            this.lblAngulo.Name = "lblAngulo";
            this.lblAngulo.Size = new System.Drawing.Size(81, 13);
            this.lblAngulo.TabIndex = 11;
            this.lblAngulo.Text = "Ángulo (grados)";
            // 
            // nudAngulo
            // 
            this.nudAngulo.DecimalPlaces = 1;
            this.nudAngulo.Location = new System.Drawing.Point(960, 180);
            this.nudAngulo.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            65536});
            this.nudAngulo.Minimum = new decimal(new int[] {
            7200,
            0,
            0,
            -2147418112});
            this.nudAngulo.Name = "nudAngulo";
            this.nudAngulo.Size = new System.Drawing.Size(120, 20);
            this.nudAngulo.TabIndex = 12;
            this.nudAngulo.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblEscala
            // 
            this.lblEscala.AutoSize = true;
            this.lblEscala.Location = new System.Drawing.Point(820, 215);
            this.lblEscala.Name = "lblEscala";
            this.lblEscala.Size = new System.Drawing.Size(39, 13);
            this.lblEscala.TabIndex = 13;
            this.lblEscala.Text = "Escala";
            // 
            // nudEscala
            // 
            this.nudEscala.DecimalPlaces = 2;
            this.nudEscala.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.nudEscala.Location = new System.Drawing.Point(960, 212);
            this.nudEscala.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            131072});
            this.nudEscala.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.nudEscala.Name = "nudEscala";
            this.nudEscala.Size = new System.Drawing.Size(120, 20);
            this.nudEscala.TabIndex = 14;
            this.nudEscala.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.nudEscala.ValueChanged += new System.EventHandler(this.Cambio);
            // 
            // lblParte
            // 
            this.lblParte.AutoSize = true;
            this.lblParte.Location = new System.Drawing.Point(820, 257);
            this.lblParte.Name = "lblParte";
            this.lblParte.Size = new System.Drawing.Size(87, 13);
            this.lblParte.TabIndex = 15;
            this.lblParte.Text = "Color de la parte:";
            // 
            // cmbParte
            // 
            this.cmbParte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParte.Location = new System.Drawing.Point(930, 254);
            this.cmbParte.Name = "cmbParte";
            this.cmbParte.Size = new System.Drawing.Size(150, 21);
            this.cmbParte.TabIndex = 16;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(930, 284);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(150, 25);
            this.btnColor.TabIndex = 17;
            this.btnColor.Text = "Cambiar color...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(820, 322);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(280, 278);
            this.txtInfo.TabIndex = 18;
            // 
            // picLienzo
            // 
            this.picLienzo.BackColor = System.Drawing.Color.White;
            this.picLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLienzo.Location = new System.Drawing.Point(0, 0);
            this.picLienzo.Name = "picLienzo";
            this.picLienzo.Size = new System.Drawing.Size(800, 600);
            this.picLienzo.TabIndex = 0;
            this.picLienzo.TabStop = false;
            this.picLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLienzo_Paint);
            this.picLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseDown);
            // 
            // Poli_estrelladoFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1110, 620);
            this.Controls.Add(this.picLienzo);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.nudN);
            this.Controls.Add(this.lblRadio);
            this.Controls.Add(this.nudRadio);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.nudRazon);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.lblAngulo);
            this.Controls.Add(this.nudAngulo);
            this.Controls.Add(this.lblEscala);
            this.Controls.Add(this.nudEscala);
            this.Controls.Add(this.lblParte);
            this.Controls.Add(this.cmbParte);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txtInfo);
            this.Name = "Poli_estrelladoFrm";
            this.Text = "Polígono estrellado";
            this.Load += new System.EventHandler(this.Poli_estrelladoFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEscala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.NumericUpDown nudRadio;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.NumericUpDown nudRazon;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Label lblAngulo;
        private System.Windows.Forms.NumericUpDown nudAngulo;
        private System.Windows.Forms.Label lblEscala;
        private System.Windows.Forms.NumericUpDown nudEscala;
        private System.Windows.Forms.Label lblParte;
        private System.Windows.Forms.ComboBox cmbParte;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.PictureBox picLienzo;
    }
}
