using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Snake_Game
{
    /// <summary>
    /// Форма отображения таблицы рекордов.
    /// </summary>
    public partial class ScoreTableForm : Form
    {
        List<string[]> scores;

        public ScoreTableForm()
        {
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(List<string[]>));

            if (File.Exists("scores.xml"))
            {   
                FileStream stream = new FileStream("scores.xml", FileMode.Open);
                try
                {
                    //Попытка чтения таблицы рекордов
                    scores = (List<string[]>)serializer.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    stream.Close();
                    MessageBox.Show("Ошибка загркузки файла рекордов:\n\"" + ex.Message + "\"\nБудет создан пустой файл рекордов.");

                    //Создание пустой таблицы рекордов
                    scores = new List<string[]>();
                    for (int i = 0; i < 10; i++)
                        scores.Add(new string[2]);

                    //Создание нового файла с пустой таблицей рекордов
                    stream = new FileStream("scores.xml", FileMode.Create);
                    serializer.Serialize(stream, scores);
                    stream.Close();
                }
            }
            else
            {
                //Создание пустой таблицы рекордов
                scores = new List<string[]>();
                for (int i = 0; i < 10; i++)
                    scores.Add(new string[2]);

                //Создание нового файла с пустой таблицей рекордов
                FileStream stream = new FileStream("scores.xml", FileMode.Create);
                serializer.Serialize(stream, scores);
                stream.Close();

                MessageBox.Show("Файл рекордов не найден.\nСоздан пустой файл рекордов.");
            }

            CreateTable(scores);
        }

        /// <summary>
        /// Заполнение таблицы рекордов на основе файла рекордов.
        /// </summary>
        /// <param name="scores">Таблица рекордов.</param>
        void CreateTable(List<string[]> scores)
        {
            lbl_name1.Text = scores[0][0] ?? "";
            lbl_score1.Text = scores[0][1] ?? "";

            lbl_name2.Text = scores[1][0] ?? "";
            lbl_score2.Text = scores[1][1] ?? "";

            lbl_name3.Text = scores[2][0] ?? "";
            lbl_score3.Text = scores[2][1] ?? "";

            lbl_name4.Text = scores[3][0] ?? "";
            lbl_score4.Text = scores[3][1] ?? "";

            lbl_name5.Text = scores[4][0] ?? "";
            lbl_score5.Text = scores[4][1] ?? "";

            lbl_name6.Text = scores[5][0] ?? "";
            lbl_score6.Text = scores[5][1] ?? "";

            lbl_name7.Text = scores[6][0] ?? "";
            lbl_score7.Text = scores[6][1] ?? "";

            lbl_name8.Text = scores[7][0] ?? "";
            lbl_score8.Text = scores[7][1] ?? "";

            lbl_name9.Text = scores[8][0] ?? "";
            lbl_score9.Text = scores[8][1] ?? "";

            lbl_name10.Text = scores[9][0] ?? "";
            lbl_score10.Text = scores[9][1] ?? "";
        }
    }
}