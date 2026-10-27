namespace Deber3
{
    partial class MenuDeb3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hexagonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.margaritaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poligonosestrelladosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexagonoToolStripMenuItem,
            this.margaritaToolStripMenuItem,
            this.poligonosestrelladosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hexagonoToolStripMenuItem
            // 
            this.hexagonoToolStripMenuItem.Name = "hexagonoToolStripMenuItem";
            this.hexagonoToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.hexagonoToolStripMenuItem.Text = "Hexagono";
            this.hexagonoToolStripMenuItem.Click += new System.EventHandler(this.hexagonoToolStripMenuItem_Click);
            // 
            // margaritaToolStripMenuItem
            // 
            this.margaritaToolStripMenuItem.Name = "margaritaToolStripMenuItem";
            this.margaritaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.margaritaToolStripMenuItem.Text = "Margarita";
            this.margaritaToolStripMenuItem.Click += new System.EventHandler(this.margaritaToolStripMenuItem_Click);
            // 
            // poligonosestrelladosToolStripMenuItem
            // 
            this.poligonosestrelladosToolStripMenuItem.Name = "poligonosestrelladosToolStripMenuItem";
            this.poligonosestrelladosToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.poligonosestrelladosToolStripMenuItem.Text = "Poligonos_estrellados";
            this.poligonosestrelladosToolStripMenuItem.Click += new System.EventHandler(this.poligonosestrelladosToolStripMenuItem_Click);
            // 
            // MenuDeb3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuDeb3";
            this.Text = "MenuDeb3";
            this.Load += new System.EventHandler(this.MenuDeb3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hexagonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem margaritaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poligonosestrelladosToolStripMenuItem;
    }
}