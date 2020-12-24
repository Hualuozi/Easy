namespace CraneVideoDisplay
{
    partial class CraneVideoDisplay
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.pic_1 = new System.Windows.Forms.PictureBox();
            this.pnl_2 = new System.Windows.Forms.Panel();
            this.pic_2 = new System.Windows.Forms.PictureBox();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.pic_main = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnl_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).BeginInit();
            this.pnl_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).BeginInit();
            this.pnl_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_1
            // 
            this.pnl_1.Controls.Add(this.pic_1);
            this.pnl_1.Location = new System.Drawing.Point(297, 175);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Size = new System.Drawing.Size(200, 100);
            this.pnl_1.TabIndex = 7;
            // 
            // pic_1
            // 
            this.pic_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_1.Location = new System.Drawing.Point(0, 0);
            this.pic_1.Name = "pic_1";
            this.pic_1.Size = new System.Drawing.Size(200, 100);
            this.pic_1.TabIndex = 1;
            this.pic_1.TabStop = false;
            // 
            // pnl_2
            // 
            this.pnl_2.Controls.Add(this.pic_2);
            this.pnl_2.Location = new System.Drawing.Point(571, 175);
            this.pnl_2.Name = "pnl_2";
            this.pnl_2.Size = new System.Drawing.Size(200, 100);
            this.pnl_2.TabIndex = 6;
            // 
            // pic_2
            // 
            this.pic_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_2.Location = new System.Drawing.Point(0, 0);
            this.pic_2.Name = "pic_2";
            this.pic_2.Size = new System.Drawing.Size(200, 100);
            this.pic_2.TabIndex = 2;
            this.pic_2.TabStop = false;
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.pic_main);
            this.pnl_main.Location = new System.Drawing.Point(29, 175);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(200, 100);
            this.pnl_main.TabIndex = 5;
            // 
            // pic_main
            // 
            this.pic_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_main.Location = new System.Drawing.Point(0, 0);
            this.pic_main.Name = "pic_main";
            this.pic_main.Size = new System.Drawing.Size(200, 100);
            this.pic_main.TabIndex = 0;
            this.pic_main.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 422);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(800, 28);
            this.textBox1.TabIndex = 8;
            // 
            // CraneVideoDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnl_1);
            this.Controls.Add(this.pnl_2);
            this.Controls.Add(this.pnl_main);
            this.Name = "CraneVideoDisplay";
            this.Text = "CraneVideoDisplay";
            this.Load += new System.EventHandler(this.CraneVideoDisplay_Load);
            this.pnl_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).EndInit();
            this.pnl_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).EndInit();
            this.pnl_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_1;
        private System.Windows.Forms.PictureBox pic_1;
        private System.Windows.Forms.Panel pnl_2;
        private System.Windows.Forms.PictureBox pic_2;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.PictureBox pic_main;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

