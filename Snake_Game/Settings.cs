using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Класс, описывающий параметры игры.
    /// </summary>
    [Serializable]
    public class Settings
    {
        #region Поля и свойства.
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Установки клавиш управления для игры.
        /// </summary>
        public GameControls Controls { get; set; }

        /// <summary>
        /// Логическое значение, нужно ли отрисовывать сетку на игровой зоне
        /// </summary>
        public bool Grid { get; set; }

        /// <summary>
        /// Размер стороны квадрата сетки игровой зоны в пикселях.
        /// </summary>
        int size;
        /// <summary>
        /// Свойство, возвращающее/задающее размер игрового поля.
        /// Размер принимает значения 1, 2 или 3.
        /// </summary>
        public int Size
        {
            get
            {
                switch (size)
                {
                    case 32:
                        return 1;                        
                    case 16:
                        return 2;
                    case 8:
                        return 3;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 1:
                        size = 32;
                        break;
                    case 2:
                        size = 16;
                        break;
                    case 3:
                        size = 8;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Размер должен принимать значения 1, 2 или 3");
                }
            }
        }
        /// <summary>
        /// Свойство, возвращающее размер стороны квадрата сетки игровой зоны в пикселях.
        /// </summary>        
        public int GetSquareSize
        { get { return size; } }

        /// <summary>
        /// Количество квадратов игровой зоны, которое змейка пройдет за 1 секунду.
        /// </summary>
        int speed;
        /// <summary>
        /// Свойство, возвращающее значение скорости змейки.
        /// Значение скорости находится в пределах от 1 до 10.
        /// </summary>
        public int Speed
        {
            get { return speed / 4; }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    speed = value * 4;
                    Points = Speed * 10;
                }
                else
                    throw new ArgumentOutOfRangeException("Значение скорости должно находится в пределах от 1 до 10");
            }
        }
        /// <summary>
        /// Свойство, возвращающее количество квадратов игровой зоны, которое змейка пройдет за 1 секунду.
        /// </summary>        
        public int GetSnakeSpeed
        { get { return speed; } }

        /// <summary>
        /// Количество очков за одну съеденную еду.
        /// </summary>
        public int Points { get; set; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает экземпляр класса <see cref="Settings"/> со значениями настроек по умолчанию.
        /// </summary>
        public Settings()
        {
            PlayerName = "Player";
            Grid = false;
            Size = 2;
            Speed = 5;            
            Controls = new GameControls();
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представление параметров игры.
        /// </summary>
        /// <returns>Строковое представление параметров игры.</returns>
        public override string ToString()
        {
            return "Показывать сетку: " + (Grid ? "Да" : "Нет") +
                   "\nРазмер поля: " + Size +
                   "\nСкорость змейки: " + Speed +
                   "\nОкчов за еду: " + Points;
        }

        /// <summary>
        /// Увеличить скорость на 1, если возможно.
        /// </summary>
        public void IncreaceSpeed()
        {
            if (Speed < 10)
                Speed++;
        }

        /// <summary>
        /// Уменьшить скорость на 1, если возможно.
        /// </summary>
        public void ReduceSpeed()
        {
            if (Speed > 1)
                Speed--;
        }
        #endregion
    }
}
