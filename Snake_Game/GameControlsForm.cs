using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class GameControlsForm : Form
    {
        #region Поля и свойства.
        GameControls newControls = new GameControls();
        #endregion

        public GameControlsForm(GameControls controls)
        {
            InitializeComponent();

            newControls.Copy(controls);

        }
    }
}
