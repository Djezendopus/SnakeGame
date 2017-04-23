using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Класс, описывающий управление действиями игры.
    /// </summary>
    [Serializable]
    public class GameControls
    {
        #region Поля и свойства.
        /// <summary>
        /// Изменение направления движения змейки вверх.        
        /// </summary>
        public GameAction Up { get; }

        /// <summary>
        /// Изменение направления движения змейки вниз.
        /// </summary>
        public GameAction Down { get; }

        /// <summary>
        /// Изменение направления движения змейки влево.
        /// </summary>
        public GameAction Left { get; }

        /// <summary>
        /// Кортеж, описывающий задание направления змейки вправо.
        /// </summary>
        public GameAction Right { get; }

        /// <summary>
        /// Включение/выключение сетки на игровом поле.
        /// </summary>
        public GameAction GridDraw { get; }

        /// <summary>
        /// Прерывание/продолжение игры.
        /// </summary>
        public GameAction Pause { get; }

        /// <summary>
        /// Перезапуск игры.
        /// </summary>
        public GameAction Restart { get; }

        /// <summary>
        /// Увеличение скорости змейки.
        /// </summary>
        public GameAction IncreaseSpeed { get; }

        /// <summary>
        /// Уменьшение скорости змейки.
        /// </summary>
        public GameAction ReduceSpeed { get; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает экземпляр класса <see cref="GameControls"/> со значениями клавиш по умолчанию.
        /// </summary>
        public GameControls()
        {
            Up = new GameAction("Вверх", Keys.Up);
            Down = new GameAction("Вниз", Keys.Down);
            Left = new GameAction("Влево", Keys.Left);
            Right = new GameAction("Вправо", Keys.Right);
            GridDraw = new GameAction("Сетка", Keys.G);
            Pause = new GameAction("Пауза", Keys.Space);
            Restart = new GameAction("Рестарт", Keys.Enter);
            IncreaseSpeed = new GameAction("Быстрее", Keys.ShiftKey);
            ReduceSpeed = new GameAction("Медленнее", Keys.ControlKey);
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представление клавиш управления игрой.
        /// </summary>
        /// <returns>Строковое представление клавиш управления игрой.</returns>
        public override string ToString()
        {
            return Up.ToString()            + "\n" +
                   Down.ToString()          + "\n" +
                   Left.ToString()          + "\n" +
                   Right.ToString()         + "\n" +
                   GridDraw.ToString()      + "\n" +
                   Pause.ToString()         + "\n" +
                   Restart.ToString()       + "\n" +
                   IncreaseSpeed.ToString() + "\n" +
                   ReduceSpeed.ToString();
        }

        /// <summary>
        /// Копирует все значения управляющих клавиш sourceControls в текущий экземпляр класса <see cref="GameControls"/>.
        /// </summary>
        /// <param name="sourceControls">Копируемый экземпляр класса <see cref="GameControls"/>.</param>
        public void Copy(GameControls sourceControls)
        {
            Up.ChangeKey            (sourceControls.Up.Key);
            Down.ChangeKey          (sourceControls.Down.Key);
            Left.ChangeKey          (sourceControls.Left.Key);
            Right.ChangeKey         (sourceControls.Right.Key);
            GridDraw.ChangeKey      (sourceControls.GridDraw.Key);
            Pause.ChangeKey         (sourceControls.Pause.Key);
            Restart.ChangeKey       (sourceControls.Restart.Key);
            IncreaseSpeed.ChangeKey (sourceControls.IncreaseSpeed.Key);
            ReduceSpeed.ChangeKey   (sourceControls.ReduceSpeed.Key);
        }
        #endregion
    }
}
