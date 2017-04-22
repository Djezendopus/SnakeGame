using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLibrary
{
    /// <summary>
    /// Перечисление, задающее направления движения.
    /// </summary>
    public enum Direction
    { Up, Down, Left, Right };

    /// <summary>
    /// Класс, описывающий змейку.
    /// </summary>
    public class Snake
    {
        #region Поля и свойства.
        /// <summary>
        /// Коллекция элементов змейки.
        /// </summary>
        public List<SnakeGameElement> elements;
        /// <summary>
        /// Свойство, возвращающее коллекцию элементов змейки.
        /// </summary>
        public List<SnakeGameElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        /// <summary>
        /// Направление движения змейки.
        /// </summary>
        Direction direction;
        /// <summary>
        /// Свойство, возвращающее/задающее направление движения змейки.
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// Свойство-индексатор, позволяющее обратится к элементу змейки по индексу.
        /// </summary>
        /// <param name="i">Индекс элемета.</param>
        /// <returns>Элемент змейки.</returns>
        public SnakeGameElement this[int i]
        {
            get
            { return elements[i]; }
            set
            { elements[i] = value; }
        }

        /// <summary>
        /// Свойство, возвращающее количество элементов в змейке.
        /// </summary>
        public int Count
        { get { return elements.Count; } }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает пустой объект класса <see cref="Snake"/> с направлением движения вниз.
        /// </summary>
        public Snake()
        {
            elements = new List<SnakeGameElement>();
            direction = Direction.Down;
        }

        /// <summary>
        /// Создает новый объект класса <see cref="Snake"/> с заданными координатами головы змейки и направлением (по умолчанию - вниз).
        /// </summary>
        /// /// <param name="head_X">Координата X головы змейки.</param>
        /// <param name="head_Y">Координата Y головы змейки.</param>
        /// <param name="direction">Направление движения змейки (по умолчанию - вниз).</param>
        public Snake(int head_X, int head_Y, Direction direction = Direction.Down)
        {
            elements = new List<SnakeGameElement>();
            elements.Add(new SnakeGameElement(head_X, head_Y));
            this.direction = direction;
        }
        #endregion

        #region Методы.
        public void Move()
        {
            switch (direction)
            {
                case Direction.Up:
                    elements.Insert(0, new SnakeGameElement(elements[0].X, elements[0].Y - 1));
                    break;
                case Direction.Down:
                    elements.Insert(0, new SnakeGameElement(elements[0].X, elements[0].Y + 1));
                    break;
                case Direction.Left:
                    elements.Insert(0, new SnakeGameElement(elements[0].X - 1, elements[0].Y));
                    break;
                case Direction.Right:
                    elements.Insert(0, new SnakeGameElement(elements[0].X + 1, elements[0].Y));
                    break;
            }
            elements.RemoveAt(Count - 1);
        }

        /// <summary>
        /// Увеличить змейку на 1 элемент.
        /// </summary>
        public void Increase()
        {
            elements.Add(new SnakeGameElement(elements[Count - 1].X, elements[Count - 1].Y));
        }
        #endregion
    }
}
