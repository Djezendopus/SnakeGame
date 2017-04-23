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
        public List<SnakeGameElement> Elements { get; set; }

        /// <summary>
        /// Направление движения змейки.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Свойство-индексатор, позволяющее обратится к элементу змейки по индексу.
        /// </summary>
        /// <param name="i">Индекс элемета.</param>
        /// <returns>Элемент змейки.</returns>
        public SnakeGameElement this[int i]
        {
            get
            { return Elements[i]; }
            set
            { Elements[i] = value; }
        }

        /// <summary>
        /// Свойство, возвращающее количество элементов в змейке.
        /// </summary>
        public int Count
        { get { return Elements.Count; } }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает пустой объект класса <see cref="Snake"/> с направлением движения вниз.
        /// </summary>
        public Snake()
        {
            Elements = new List<SnakeGameElement>();
            Direction = Direction.Down;
        }

        /// <summary>
        /// Создает новый объект класса <see cref="Snake"/> с заданными координатами головы змейки, и направлением (по умолчанию - вниз).
        /// </summary>
        /// /// <param name="head_X">Координата X головы змейки.</param>
        /// <param name="head_Y">Координата Y головы змейки.</param>
        /// <param name="direction">Направление движения змейки (по умолчанию - вниз).</param>
        public Snake(int head_X, int head_Y, Direction direction = Direction.Down)
        {
            Elements = new List<SnakeGameElement>();
            Elements.Add(new SnakeGameElement(head_X, head_Y));
            Direction = direction;
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Переместить змейку на шаг вперед с учетом направления движения.
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Elements.Insert(0, new SnakeGameElement(Elements[0].X, Elements[0].Y - 1));
                    break;
                case Direction.Down:
                    Elements.Insert(0, new SnakeGameElement(Elements[0].X, Elements[0].Y + 1));
                    break;
                case Direction.Left:
                    Elements.Insert(0, new SnakeGameElement(Elements[0].X - 1, Elements[0].Y));
                    break;
                case Direction.Right:
                    Elements.Insert(0, new SnakeGameElement(Elements[0].X + 1, Elements[0].Y));
                    break;
            }
            Elements.RemoveAt(Count - 1);
        }

        /// <summary>
        /// Увеличить змейку на 1 элемент.
        /// </summary>
        public void Increase()
        {
            Elements.Add(new SnakeGameElement(Elements[Count - 1].X, Elements[Count - 1].Y));
        }
        #endregion
    }
}
