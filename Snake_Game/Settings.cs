﻿using System;
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
    class Settings
    {
        #region Поля и свойства.
        /// <summary>
        /// Установки клавиш управления для игры.
        /// </summary>
        GameControls controls;
        /// <summary>
        /// Свойство, возвращающее/задающее установки клавиш управления для игры.
        /// </summary>
        public GameControls Controls
        {
            get { return controls; }
            set { controls = value; }
        }

        /// <summary>
        /// Логическое значение, нужно ли отрисовывать сетку на игровой зоне
        /// </summary>
        bool grid;
        /// <summary>
        /// Свойство, возвращающее/задающее значение необходимости отрисовывать сетку на игровой зоне.
        /// </summary>
        public bool Grid
        {
            get { return grid; }
            set { grid = value; }
        }

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
        /// Свойство, возвращающее/задающее значение скорости змейки.
        /// Значение скорости находится в пределах от 1 до 10.
        /// </summary>
        public int Speed
        {
            get { return speed / 4; }
            set
            {
                if (value >= 1 && value <= 10)
                    speed = value * 4;
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
        int points;
        /// <summary>
        /// Свойство, возвращающее/задающее значение параметра <see cref="points"/>.
        /// </summary>
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает экземпляр класса <see cref="Settings"/> со значениями настроек по умолчанию.
        /// </summary>
        public Settings()
        {
            Grid = true;
            Size = 2;
            Speed = 5;
            Points = 100;
            controls = new GameControls();
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
                speed += 4;
        }

        /// <summary>
        /// Уменьшить скорость на 1, если возможно.
        /// </summary>
        public void ReduceSpeed()
        {
            if (Speed > 1)
                speed -= 4;
        }
        #endregion
    }
}