namespace MyFirstSnakeGame
{
    partial class SnakeGame
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
            this.components = new System.ComponentModel.Container();
            this.pbGameArea = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbGameOver = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameArea
            // 
            this.pbGameArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbGameArea.Location = new System.Drawing.Point(12, 12);
            this.pbGameArea.Name = "pbGameArea";
            this.pbGameArea.Size = new System.Drawing.Size(359, 422);
            this.pbGameArea.TabIndex = 0;
            this.pbGameArea.TabStop = false;
            this.pbGameArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameArea_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore.Location = new System.Drawing.Point(455, 12);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(38, 25);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "00";
            // 
            // lbGameOver
            // 
            this.lbGameOver.AutoSize = true;
            this.lbGameOver.BackColor = System.Drawing.Color.LemonChiffon;
            this.lbGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGameOver.Location = new System.Drawing.Point(110, 245);
            this.lbGameOver.Name = "lbGameOver";
            this.lbGameOver.Size = new System.Drawing.Size(123, 25);
            this.lbGameOver.TabIndex = 3;
            this.lbGameOver.Text = "GameOver";
            this.lbGameOver.Visible = false;
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbGameOver);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGameArea);
            this.Name = "SnakeGame";
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IsKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbGameOver;
        private System.Windows.Forms.Timer gameTimer;
    }
}

