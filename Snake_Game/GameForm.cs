using System;
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
    /// <summary>
    /// Основная форма игры.
    /// </summary>
    public partial class GameForm : Form
    {
        #region Поля и свойства.
        /// <summary>
        /// Переменная для передачи данных из дочерних форм.
        /// </summary>
        public object tmp;

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
        int score = 0;
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
                FileStream stream = new FileStream("settings.xml", FileMode.Open);
                try
                {
                    settings = (Settings)serializer.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    stream.Close();
                    File.Delete("settings.xml");
                    MessageBox.Show("Ошибка загркузки файла настроек:\n\"" + ex.Message + "\"\nВосстановлены настройки по умолчанию.");
                    settings = new Settings();
                    ChangeName();
                }
            }
            else
            {
                settings = new Settings();
                ChangeName();
            }

            gameTimer.Interval = 1000 / settings.GetSnakeSpeed;

            lbl_name.Text = settings.PlayerName;
            lbl_score.Text = "" + score;
            lbl_params.Text = settings.ToString();
            lbl_controls.Text = settings.Controls.ToString();
            lbl_pause.Text = "Игра приостановлена." +
                             "\nНажмите \"" + settings.Controls.Pause.Key.ToString() + "\"" +
                             "\nчтобы продолжить.";
            lbl_gameOver.Text = "Чтобы начать игру," +
                                "\nнажмите \"" + settings.Controls.Restart.Key.ToString() + "\"";
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
            if (e.KeyCode == settings.Controls.Up.Key ||
                e.KeyCode == settings.Controls.Down.Key ||
                e.KeyCode == settings.Controls.Left.Key ||
                e.KeyCode == settings.Controls.Right.Key && snake.Direction != Direction.Left)
            {
                nextDirectionKey = e.KeyCode;
            }
            else if (e.KeyCode == settings.Controls.IncreaseSpeed.Key)
            {
                settings.IncreaceSpeed();
                gameTimer.Interval = 1000 / settings.GetSnakeSpeed;
                lbl_params.Text = settings.ToString();
            }
            else if (e.KeyCode == settings.Controls.ReduceSpeed.Key)
            {
                settings.ReduceSpeed();
                gameTimer.Interval = 1000 / settings.GetSnakeSpeed;
                lbl_params.Text = settings.ToString();
            }
            else if (e.KeyCode == settings.Controls.GridDraw.Key)
            {
                ChangeGrid();
            }
            else if (e.KeyCode == settings.Controls.Pause.Key)
            {
                PauseGame();
            }
            else if (e.KeyCode == settings.Controls.Restart.Key)
            {
                //Если игра не остановлена.
                if (!lbl_gameOver.Visible)
                {
                    //Если игра не на паузе - ставим на паузу.
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
            nextDirectionKey = settings.Controls.Down.Key;
            //Если игра была поставлена на паузу - убираем паузу.
            if (lbl_pause.Visible)
                PauseGame();

            lbl_gameOver.Visible = false;
            gameTimer.Start();

            score = 0;
            snake = new Snake(pb_GameField.Size.Width / settings.GetSquareSize / 2, pb_GameField.Size.Height / settings.GetSquareSize / 2);
            for (int i = 1; i < 5; i++)
            {
                snake.Elements.Add(new SnakeGameElement(snake[snake.Count - 1].X, snake[snake.Count - 1].Y - 1));
                pb_GameField.Invalidate();
            }

            GenerateFood();
            pb_GameField.Invalidate();
            lbl_score.Text = "" + score;
        }

        /// <summary>
        /// Прерывание/возобновление игры.
        /// </summary>
        void PauseGame()
        {
            //Если игра не остановлена.
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
                "\nнажмите \"" + settings.Controls.Restart.Key.ToString() + "\".";

            lbl_gameOver.Visible = true;

            if (score != 0)
                AddToScoreList();
        }

        /// <summary>
        /// Добавить результат игрока в таблицу рекордов.
        /// </summary>
        void AddToScoreList()
        {
            List<string[]> scores;
            XmlSerializer serializer = new XmlSerializer(typeof(List<string[]>));

            //Попытка чтения таблицы рекордов
            if (File.Exists("scores.xml"))
            {
                FileStream stream = new FileStream("scores.xml", FileMode.Open);
                try
                {
                    scores = (List<string[]>)serializer.Deserialize(stream);
                    stream.Close();
                }
                catch
                {
                    stream.Close();

                    //Создание пустой таблицы рекордов
                    scores = new List<string[]>();
                    for (int i = 0; i < 10; i++)
                        scores.Add(new string[2]);
                }
            }
            else
            {
                //Создание пустой таблицы рекордов
                scores = new List<string[]>();
                for (int i = 0; i < 10; i++)
                    scores.Add(new string[2]);
            }

            //При необходимости - записываем текущий результат в таблицу рекордов
            bool recorded = false;//Записано ли значение в таблицу

            foreach (var v in scores)
            {
                if (v[0] == null)
                {
                    v[0] = settings.PlayerName;
                    v[1] = "" + score;
                    recorded = true;
                    break;
                }

                if (v[0] == settings.PlayerName)
                {
                    if (score > int.Parse(v[1]))
                        v[1] = "" + score;
                    recorded = true;
                    break;
                }
            }

            if (!recorded)
            {
                for (int i = scores.Count - 1; i >= 0; i--)
                    if (scores[i][0] != null && score > int.Parse(scores[i][0]))
                    {
                        scores.RemoveAt(scores.Count - 1);
                        scores.Insert(i, new string[] { settings.PlayerName, "" + score });
                        recorded = true;
                    }
            }

            //Если запись была произведена - сериализуем таблицу
            if (recorded)
            {
                //Сортируем полученную таблицу по результату
                string tmp1, tmp2;
                for (int i = 0; i < scores.Count - 1; i++)
                {
                    for (int j = i + 1; j < scores.Count; j++)
                    {
                        if (scores[i][1] != null &&
                            scores[j][1] != null &&
                            int.Parse(scores[i][1]) < int.Parse(scores[j][1]))
                        {
                            tmp1 = scores[i][0];
                            tmp2 = scores[i][1];
                            scores[i][0] = scores[j][0];
                            scores[i][1] = scores[j][1];
                            scores[j][0] = tmp1;
                            scores[j][1] = tmp2;
                        }
                    }
                }
                File.Delete("scores.xml");
                FileStream stream = new FileStream("scores.xml", FileMode.Create);
                serializer.Serialize(stream, scores);
                stream.Close();
            }
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
            if (nextDirectionKey == settings.Controls.Up.Key && snake.Direction != Direction.Down)
            {
                snake.Direction = Direction.Up;
            }
            else if (nextDirectionKey == settings.Controls.Down.Key && snake.Direction != Direction.Up)
            {
                snake.Direction = Direction.Down;
            }
            else if (nextDirectionKey == settings.Controls.Left.Key && snake.Direction != Direction.Right)
            {
                snake.Direction = Direction.Left;
            }
            else if (nextDirectionKey == settings.Controls.Right.Key && snake.Direction != Direction.Left)
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
                lbl_score.Text = "" + score;
                lbl_gameOver.Text = "Поздравляем! Вы прошли игру!" +
                "\nЧтобы начать заново," +
                "\nнажмите \"" + settings.Controls.Restart.Key.ToString() + "\".";
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
                bool coords_ok;
                do
                {
                    coords_ok = true;
                    
                    X = rnd.Next(0, maxX);
                    Y = rnd.Next(0, maxY);

                    foreach (var v in snake.Elements)
                        if (X == v.X && Y == v.Y)
                        {
                            coords_ok = false;
                            break;
                        }
                }
                while (!coords_ok);

                //Создаем новую еду.
                food = new SnakeGameElement(X, Y);
            }
        }

        /// <summary>
        /// Событие, возникающее при достижении змейкой еды.
        /// </summary>
        void Eat()
        {
            snake.Increase();
            score += settings.Points;
            lbl_score.Text = "" + score;

            GenerateFood();
        }

        /// <summary>
        /// Включить/отключить сетку на игровом поле.
        /// </summary>
        void ChangeGrid()
        {
            settings.Grid = !settings.Grid;
            pb_GameField.Invalidate();
            lbl_params.Text = settings.ToString();
        }

        /// <summary>
        /// Сменить имя игрока.
        /// </summary>
        void ChangeName()
        {
            InputNameForm inputName = new InputNameForm();
            inputName.Owner = this;
            if (inputName.ShowDialog() == DialogResult.OK)
            {
                settings.PlayerName = (string)tmp;
                lbl_name.Text = settings.PlayerName;
                tmp = null;
            }
        }

        /// <summary>
        /// Событие, происходящее при тике таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Если игра не остановлена.
            if (!lbl_gameOver.Visible)
                MovePlayer();
        }

        /// <summary>
        /// Перерисовка игрового поля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_GameField_Paint(object sender, PaintEventArgs e)
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
                graphics.FillEllipse(Brushes.Black,
                    new Rectangle(snake[0].X * settings.GetSquareSize,
                                  snake[0].Y * settings.GetSquareSize,
                                  settings.GetSquareSize, settings.GetSquareSize));

                //Рисуем остальную змейку.
                for (int i = 1; i < snake.Count; i++)
                {
                    graphics.FillEllipse(Brushes.Green,
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
        /// <summary>
        /// Поставить игру на паузу при открытии меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnMenuItem(object sender, EventArgs e)
        {
            //Если игра не на паузе - ставим на паузу.
            if (!lbl_pause.Visible)
                PauseGame();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Игра - Начать заново".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Игра - Сменить имя".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сменитьИмяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeName();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Игра - Рекорды".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreTableForm scoreTable = new ScoreTableForm();
            scoreTable.Owner = this;
            scoreTable.ShowDialog();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Игра - Выход".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Настройки - Сбросить настройки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сброситьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите сбросить настройки игры?", "Сбросить настройки", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                settings = new Settings();
                lbl_name.Text = settings.PlayerName;
                lbl_params.Text = settings.ToString();
                pb_GameField.Invalidate();
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки в меню "Настройки - Размер поля".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSizeOfGameField_Click(object sender, EventArgs e)
        {
            //Если игра не остановлена.
            if (!lbl_gameOver.Visible)
            {
                if (MessageBox.Show("Для изменения размера поля необходимо начать игру сначала. Вы уверены?", "Изменение размер поля", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    switch (sender.ToString())
                    {
                        case "Маленькое":
                            settings.Size = 1;
                            break;
                        case "Среднее":
                            settings.Size = 2;
                            break;
                        case "Большое":
                            settings.Size = 3;
                            break;
                    }

                    gameTimer.Stop();
                    lbl_gameOver.Text = "Чтобы начать игру," +
                                        "\nнажмите \"" + settings.Controls.Restart.Key.ToString() + "\"";
                    lbl_gameOver.Visible = true;
                    lbl_pause.Visible = false;
                    snake = null;
                }
            }
            else
            {
                switch (sender.ToString())
                {
                    case "Маленькое":
                        settings.Size = 1;
                        break;
                    case "Среднее":
                        settings.Size = 2;
                        break;
                    case "Большое":
                        settings.Size = 3;
                        break;
                }
            }
            pb_GameField.Invalidate();
            lbl_params.Text = settings.ToString();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Настройки - Вкл/выкл сетку".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вклвыклСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeGrid();
        }
        
        /// <summary>
        /// Событие при нажатии кнопки "Помощь - О приложении".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTextForm showText = new ShowTextForm(Properties.Resources.README);
            showText.ShowDialog();
        }
        #endregion

        /// <summary>
        /// Событие перед закрытием формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из игры?", "Выход", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
            {
                //Сохраняем текущие настройки
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                File.Delete("settings.xml");
                FileStream stream = new FileStream("settings.xml", FileMode.Create);
                serializer.Serialize(stream, settings);
                stream.Close();
            }
        }
        #endregion
    }
}
