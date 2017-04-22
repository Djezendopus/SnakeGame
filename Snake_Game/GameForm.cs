﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using SnakeLibrary;

namespace Snake_Game
{
    public partial class GameForm : Form
    {
        #region Поля и свойства.
        /// <summary>
        /// Змейка.
        /// </summary>
        Snake snake;
        /// <summary>
        /// Еда змейки.
        /// </summary>
        SnakeGameElement food;
        /// <summary>
        /// Текущий счет игры.
        /// </summary>
        int score;
        /// <summary>
        /// Настройки игры.
        /// </summary>
        Settings settings;
        /// <summary>
        /// Запоминаем нажатую клавишу направления для ограничения смены направлений одним тиком таймера.
        /// </summary>
        Keys nextDirectionKey;
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Загрузка формы игры при запуске.
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            
            if (File.Exists("settings.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                FileStream fStream = new FileStream("settings.xml", FileMode.Open);
                settings = (Settings)serializer.Deserialize(fStream);
                fStream.Close();
            }
            else
                settings = new Settings();
            gameTimer.Interval = 1000 / settings.GetSnakeSpeed;

            lbl_pause.Text = "Игра приостановлена." +
                             "\nНажмите \"" + settings.Controls.PauseKey.ToString() + "\"" +
                             "\nчтобы продолжить.";
            lbl_pause.Visible = false;

            lbl_params.Text = settings.ToString();
            lbl_controls.Text = settings.Controls.ToString();

            lbl_gameOver.Text = "Чтобы начать игру,\nнажмите \"" + settings.Controls.RestartKey.ToString() + "\"";
            lbl_gameOver.Visible = true;
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Событие при нажатии кнопки на клавиатуре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == settings.Controls.UpKey ||
                e.KeyCode == settings.Controls.DownKey ||
                e.KeyCode == settings.Controls.LeftKey ||
                e.KeyCode == settings.Controls.RightKey && snake.Direction != Direction.Left)
            {
                nextDirectionKey = e.KeyCode;
            }
            else if (e.KeyCode == settings.Controls.IncreaseSpeedKey)
            {
                settings.IncreaceSpeed();
                gameTimer.Interval = 1000 / settings.GetSnakeSpeed;
                lbl_params.Text = settings.ToString();
            }
            else if (e.KeyCode == settings.Controls.ReduceSpeedKey)
            {
                settings.ReduceSpeed();
                gameTimer.Interval = 1000 / settings.GetSnakeSpeed;
                lbl_params.Text = settings.ToString();
            }
            else if (e.KeyCode == settings.Controls.PauseKey)
            {
                PauseGame();
            }
            else if (e.KeyCode == settings.Controls.RestartKey)
            {
                if (!lbl_gameOver.Visible)
                {
                    if (!lbl_pause.Visible)
                        PauseGame();
                    if (MessageBox.Show("Вы уверены, что хотите начать игру заново?", "Заново", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        RestartGame();
                }
                else
                    RestartGame();
            }
        }

        /// <summary>
        /// Запуск игры с начала.
        /// </summary>
        void RestartGame()
        {
            lbl_gameOver.Visible = false;
            gameTimer.Start();
            
            score = 0;
            snake = new Snake(pb_GameField.Size.Width / settings.GetSquareSize / 2, pb_GameField.Size.Height / settings.GetSquareSize / 2);
            GenerateFood();
            lbl_score.Text = "Счет: " + score;
        }

        /// <summary>
        /// Прерывание/возобновление игры.
        /// </summary>
        void PauseGame()
        {
            if (!lbl_gameOver.Visible)
            {
                lbl_pause.Visible = !lbl_pause.Visible;
                gameTimer.Enabled = !gameTimer.Enabled;
            }
        }

        /// <summary>
        /// Окончание игры.
        /// </summary>
        void GameOver()
        {
            gameTimer.Stop();

            lbl_gameOver.Text = "Игра окончена!" +
                "\nЧтобы начать заново," +
                "\nнажмите \"" + settings.Controls.RestartKey.ToString() + "\".";

            lbl_gameOver.Visible = true;
        }

        /// <summary>
        /// Перемещение змейки по игровому полю.
        /// </summary>
        void MovePlayer()
        {
            CheckDirection();
            snake.Move();
            //Проверяем змейку на столкновение с границами.
            if (snake[0].X < 0 ||
                snake[0].Y < 0 ||
                snake[0].X >= pb_GameField.Size.Width / settings.GetSquareSize ||
                snake[0].Y >= pb_GameField.Size.Height / settings.GetSquareSize)
            { GameOver(); }
            else
            {
                //Проверем змейку на столкновение с собой.
                for (int i = 1; i < snake.Count; i++)
                    if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                    {
                        GameOver();
                        break;
                    }
            }

            //Если игра не окончена - перерисовываем игровое поле
            if (!lbl_gameOver.Visible)
                pb_GameField.Invalidate();

            //Проверяем, съела ли змейка еду в этой клетке.
            if (snake[0].X == food.X && snake[0].Y == food.Y)
                Eat();
        }

        /// <summary>
        /// Проверка совпадение текущего направления с последней нажатой клавишей и его изменение при возможности и необходимости.
        /// </summary>
        void CheckDirection()
        {
            if (nextDirectionKey == settings.Controls.UpKey && snake.Direction != Direction.Down)
            {
                snake.Direction = Direction.Up;
            }
            else if (nextDirectionKey == settings.Controls.DownKey && snake.Direction != Direction.Up)
            {
                snake.Direction = Direction.Down;
            }
            else if (nextDirectionKey == settings.Controls.LeftKey && snake.Direction != Direction.Right)
            {
                snake.Direction = Direction.Left;
            }
            else if (nextDirectionKey == settings.Controls.RightKey && snake.Direction != Direction.Left)
            {
                snake.Direction = Direction.Right;
            }
        }

        /// <summary>
        /// Поставить новую еду на игровое поле.
        /// </summary>
        void GenerateFood()
        {
            //Проверяем, не заполнила ли змейка все игровое поле.
            if (snake.Count == (pb_GameField.Size.Width / settings.GetSquareSize) * (pb_GameField.Size.Height / settings.GetSquareSize))
            {
                lbl_score.Text = "Счет: " + score;
                lbl_gameOver.Text = "Поздравляем! Вы прошли игру!" +
                "\nЧтобы начать заново," +
                "\nнажмите \"" + settings.Controls.RestartKey.ToString() + "\".";
                lbl_gameOver.Visible = true;
            }
            else
            {
                int X, Y,
                    //Устанавливаем границы для генерации еды.
                    maxX = pb_GameField.Size.Width / settings.GetSquareSize,
                    maxY = pb_GameField.Size.Height / settings.GetSquareSize;

                Random rnd = new Random();

                //Задаем координаты еды, проверяя, не попадает ли еда на саму змейку.
                bool X_ok, Y_ok;
                do
                {
                    X_ok = true;
                    X = rnd.Next(0, maxX);
                    foreach (var v in snake.Elements)
                        if (X == v.X)
                        {
                            X_ok = false;
                            break;
                        }
                }
                while (!X_ok);
                do
                {
                    Y_ok = true;
                    Y = rnd.Next(0, maxY);
                    foreach (var v in snake.Elements)
                        if (Y == v.X)
                        {
                            X_ok = false;
                            break;
                        }
                }
                while (!Y_ok);

                //Создаем новую еду.
                food = new SnakeGameElement(X, Y);
            }
        }

        /// <summary>
        /// Событие, возникающее при достижении змейкой еды.
        /// </summary>
        private void Eat()
        {
            snake.Increase();
            score += settings.Points;
            lbl_score.Text = "Счет: " + score;

            GenerateFood();
        }

        /// <summary>
        /// Событие, происходящее при тике таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!lbl_gameOver.Visible)
                MovePlayer();
        }

        /// <summary>
        /// Перерисовка игрового поля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //Рисуем сетку, если необходимо
            if (settings.Grid)
            {
                for (int i = settings.GetSquareSize; i < pb_GameField.Width; i += settings.GetSquareSize)
                    graphics.DrawLine(Pens.Black, new Point(i, 0), new Point(i, pb_GameField.Height));

                for (int j = settings.GetSquareSize; j < pb_GameField.Height; j += settings.GetSquareSize)
                    graphics.DrawLine(Pens.Black, new Point(0, j), new Point(pb_GameField.Width, j));
            }

            if (snake != null)
            {
                //Рисуем голову змейки.
                Brush snakeColour = Brushes.Black;
                graphics.FillEllipse(snakeColour,
                    new Rectangle(snake[0].X * settings.GetSquareSize,
                                  snake[0].Y * settings.GetSquareSize,
                                  settings.GetSquareSize, settings.GetSquareSize));

                //Рисуем остальную змейку.
                for (int i = 1; i < snake.Count; i++)
                {
                    snakeColour = Brushes.Green;

                    graphics.FillEllipse(snakeColour,
                        new Rectangle(snake[i].X * settings.GetSquareSize,
                                      snake[i].Y * settings.GetSquareSize,
                                      settings.GetSquareSize, settings.GetSquareSize));
                }

                //Рисуем еду.
                graphics.FillEllipse(Brushes.Red,
                    new Rectangle(food.X * settings.GetSquareSize,
                                  food.Y * settings.GetSquareSize,
                                  settings.GetSquareSize, settings.GetSquareSize));
            }
        }

        #region Взаимодействие с меню.
        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGame();
            RestartGame();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из игры?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Dispose();            
        }
        #endregion
        #endregion
    }
}