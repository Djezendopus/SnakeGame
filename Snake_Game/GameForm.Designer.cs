namespace Snake_Game
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьЗановоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маленькоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднееToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.большоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вклвыклСеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПриложенииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pb_GameField = new System.Windows.Forms.PictureBox();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_gameOver = new System.Windows.Forms.Label();
            this.lbl_pause = new System.Windows.Forms.Label();
            this.lbl_paramsHead = new System.Windows.Forms.Label();
            this.lbl_controlsHead = new System.Windows.Forms.Label();
            this.lbl_params = new System.Windows.Forms.Label();
            this.lbl_controls = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьЗановоToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            this.играToolStripMenuItem.Click += new System.EventHandler(this.ClickOnMenuItem);
            // 
            // начатьЗановоToolStripMenuItem
            // 
            this.начатьЗановоToolStripMenuItem.Name = "начатьЗановоToolStripMenuItem";
            this.начатьЗановоToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.начатьЗановоToolStripMenuItem.Text = "Начать заново";
            this.начатьЗановоToolStripMenuItem.Click += new System.EventHandler(this.начатьЗановоToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерПоляToolStripMenuItem,
            this.вклвыклСеткуToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.ClickOnMenuItem);
            // 
            // размерПоляToolStripMenuItem
            // 
            this.размерПоляToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маленькоеToolStripMenuItem,
            this.среднееToolStripMenuItem,
            this.большоеToolStripMenuItem});
            this.размерПоляToolStripMenuItem.Name = "размерПоляToolStripMenuItem";
            this.размерПоляToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.размерПоляToolStripMenuItem.Text = "Размер поля";
            // 
            // маленькоеToolStripMenuItem
            // 
            this.маленькоеToolStripMenuItem.Name = "маленькоеToolStripMenuItem";
            this.маленькоеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.маленькоеToolStripMenuItem.Text = "Маленькое";
            this.маленькоеToolStripMenuItem.Click += new System.EventHandler(this.ChangeSizeOfGameField_Click);
            // 
            // среднееToolStripMenuItem
            // 
            this.среднееToolStripMenuItem.Name = "среднееToolStripMenuItem";
            this.среднееToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.среднееToolStripMenuItem.Text = "Среднее";
            this.среднееToolStripMenuItem.Click += new System.EventHandler(this.ChangeSizeOfGameField_Click);
            // 
            // большоеToolStripMenuItem
            // 
            this.большоеToolStripMenuItem.Name = "большоеToolStripMenuItem";
            this.большоеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.большоеToolStripMenuItem.Text = "Большое";
            this.большоеToolStripMenuItem.Click += new System.EventHandler(this.ChangeSizeOfGameField_Click);
            // 
            // вклвыклСеткуToolStripMenuItem
            // 
            this.вклвыклСеткуToolStripMenuItem.Name = "вклвыклСеткуToolStripMenuItem";
            this.вклвыклСеткуToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.вклвыклСеткуToolStripMenuItem.Text = "Вкл/выкл сетку";
            this.вклвыклСеткуToolStripMenuItem.Click += new System.EventHandler(this.вклвыклСеткуToolStripMenuItem_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правилаToolStripMenuItem,
            this.оПриложенииToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.ClickOnMenuItem);
            // 
            // правилаToolStripMenuItem
            // 
            this.правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
            this.правилаToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.правилаToolStripMenuItem.Text = "Правила";
            // 
            // оПриложенииToolStripMenuItem
            // 
            this.оПриложенииToolStripMenuItem.Name = "оПриложенииToolStripMenuItem";
            this.оПриложенииToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.оПриложенииToolStripMenuItem.Text = "О приложении";
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // pb_GameField
            // 
            this.pb_GameField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.pb_GameField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_GameField.Location = new System.Drawing.Point(15, 41);
            this.pb_GameField.Name = "pb_GameField";
            this.pb_GameField.Size = new System.Drawing.Size(516, 516);
            this.pb_GameField.TabIndex = 1;
            this.pb_GameField.TabStop = false;
            this.pb_GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_GameField_Paint);
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_score.Location = new System.Drawing.Point(533, 41);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(91, 25);
            this.lbl_score.TabIndex = 6;
            this.lbl_score.Text = "Счет: 0";
            // 
            // lbl_gameOver
            // 
            this.lbl_gameOver.AutoSize = true;
            this.lbl_gameOver.BackColor = System.Drawing.Color.Silver;
            this.lbl_gameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_gameOver.Location = new System.Drawing.Point(533, 66);
            this.lbl_gameOver.Name = "lbl_gameOver";
            this.lbl_gameOver.Size = new System.Drawing.Size(113, 25);
            this.lbl_gameOver.TabIndex = 8;
            this.lbl_gameOver.Text = "game over";
            this.lbl_gameOver.Visible = false;
            // 
            // lbl_pause
            // 
            this.lbl_pause.AutoSize = true;
            this.lbl_pause.BackColor = System.Drawing.Color.Silver;
            this.lbl_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_pause.Location = new System.Drawing.Point(533, 66);
            this.lbl_pause.Name = "lbl_pause";
            this.lbl_pause.Size = new System.Drawing.Size(142, 25);
            this.lbl_pause.TabIndex = 9;
            this.lbl_pause.Text = "game paused";
            this.lbl_pause.Visible = false;
            // 
            // lbl_paramsHead
            // 
            this.lbl_paramsHead.AutoSize = true;
            this.lbl_paramsHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_paramsHead.Location = new System.Drawing.Point(532, 180);
            this.lbl_paramsHead.Name = "lbl_paramsHead";
            this.lbl_paramsHead.Size = new System.Drawing.Size(143, 25);
            this.lbl_paramsHead.TabIndex = 10;
            this.lbl_paramsHead.Text = "Параметры:";
            // 
            // lbl_controlsHead
            // 
            this.lbl_controlsHead.AutoSize = true;
            this.lbl_controlsHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_controlsHead.Location = new System.Drawing.Point(532, 315);
            this.lbl_controlsHead.Name = "lbl_controlsHead";
            this.lbl_controlsHead.Size = new System.Drawing.Size(149, 25);
            this.lbl_controlsHead.TabIndex = 11;
            this.lbl_controlsHead.Text = "Управление:";
            // 
            // lbl_params
            // 
            this.lbl_params.AutoSize = true;
            this.lbl_params.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_params.Location = new System.Drawing.Point(534, 205);
            this.lbl_params.Name = "lbl_params";
            this.lbl_params.Size = new System.Drawing.Size(112, 24);
            this.lbl_params.TabIndex = 12;
            this.lbl_params.Text = "Параметры";
            // 
            // lbl_controls
            // 
            this.lbl_controls.AutoSize = true;
            this.lbl_controls.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_controls.Location = new System.Drawing.Point(534, 340);
            this.lbl_controls.Name = "lbl_controls";
            this.lbl_controls.Size = new System.Drawing.Size(119, 24);
            this.lbl_controls.TabIndex = 13;
            this.lbl_controls.Text = "Управление";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbl_controls);
            this.Controls.Add(this.lbl_params);
            this.Controls.Add(this.lbl_controlsHead);
            this.Controls.Add(this.lbl_paramsHead);
            this.Controls.Add(this.lbl_pause);
            this.Controls.Add(this.lbl_gameOver);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.pb_GameField);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "GameForm";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьЗановоToolStripMenuItem;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pb_GameField;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_gameOver;
        private System.Windows.Forms.Label lbl_pause;
        private System.Windows.Forms.Label lbl_paramsHead;
        private System.Windows.Forms.Label lbl_controlsHead;
        private System.Windows.Forms.Label lbl_params;
        private System.Windows.Forms.Label lbl_controls;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вклвыклСеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерПоляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маленькоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднееToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem большоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПриложенииToolStripMenuItem;
    }
}

