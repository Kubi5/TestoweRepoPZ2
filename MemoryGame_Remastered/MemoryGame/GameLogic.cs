using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    internal class GameLogic
    {
        static Form4 form4;
        static Label firstCardSelected = null;
        static Label secondCardSelected = null;
        static Stopwatch stopwatch = new Stopwatch();
        static Boolean ifCardsAreCovered = false;
        static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        static Form form = new Form();
        static TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

        static Random random = new Random();

        static List<String> icons = new List<string>();
        static List<String> wholeSet = new List<String>()
        {
            "z","z","w","w","G","G","y","y","Z","Z","Y","Y",
            "X","X","v","v","V","V","t","t","T","T","p","p",
            "P","P","R","R","r","r","W","W","L","L","l","l",
            "?","?","!","!","i","i","J","J","j","j","I","I",
            "N","N","n","n","k","k","K","K","M","M","g","g",
            "O","O","o","o"
        };


        public static void PauseTheGame(KeyPressEventArgs e)
        {
            if (ifCardsAreCovered)
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    stopwatch.Stop();
                    timer3.Stop();
                    MessageBox.Show("Press OK to return to game", "Timer was stopped!");
                    stopwatch.Start();
                    timer3.Start();
                }
            }
        }

        public static void SettingFormAndLayout(Form form_,TableLayoutPanel tableLayoutPanel_)
        {
            form = form_;
            tableLayoutPanel = tableLayoutPanel_;
        }

        private static void TimerEventProcessor1(Object myObject,
                                            EventArgs myEventArgs)
        {
            timer1.Stop();
            ifCardsAreCovered = true;
            Player.WrongAnswers++;

            firstCardSelected.ForeColor = firstCardSelected.BackColor;
            secondCardSelected.ForeColor = secondCardSelected.BackColor;

            firstCardSelected = null;
            secondCardSelected = null;
        }
        private static void TimerEventProcessor2(Object myObject,
                                            EventArgs myEventArgs)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = iconLabel.BackColor;
            }
            timer2.Stop();

            //patrzymy ile czasu zajmuje graczowi odgadniecie pól
            stopwatch.Start();
            timer3.Start();

            ifCardsAreCovered = true;
        }

        private static void TimerEventProcessor3(Object myObject,
                                            EventArgs myEventArgs)
        {
            timer3.Stop();
            form.Text = form.Text.Substring(0, 61);
            form.Text += "     ## " + (int)stopwatch.ElapsedMilliseconds / 1000 + " s ##";

            timer3.Start();
        }


        public static void InitiatingTimers()
        {
            timer1.Tick += new EventHandler(TimerEventProcessor1);
            timer2.Tick += new EventHandler(TimerEventProcessor2);
            timer3.Tick += new EventHandler(TimerEventProcessor3);

        }

        public static void ChecksIfTheGameEnds(TableLayoutPanel tableLayoutPanel,Form form)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            //koniec czasu zgadywania
            stopwatch.Stop();


            PlayerResults();
            Ranking.PlacingPlayerInRanking();
            if(Player.postionInRanking != "")
            {
                DialogResult dialogResult = new DialogResult();
             dialogResult = MessageBox.Show("YOU ARE PLACED " + Player.postionInRanking + " in TOP10!!!","Press OK to see TOP 10");
                if(dialogResult == DialogResult.OK)
                {
                    form4 = new Form4();
                    form4.ShowDialog();
                }
                
            }

            form.Close();
            
            
        }

        public static void PlayerResults()
        {
            Player.TimeSpentOnGame = (int)stopwatch.ElapsedMilliseconds / 1000;
            Player.CalculatePoints();
            MessageBox.Show(Player.PlayerName + " you matched all the icons in " + Player.TimeSpentOnGame + " s!\n" + "Wrong answers number: " + Player.WrongAnswers + "\nYour points:  " + Player.NumberOfPoints, "Well done");  
            Player.WrongAnswers = 0;
        }
        

        public static void SettingTheTimetoDisplayPair(int value)
        {
            timer1.Interval = value * 1000;
        }


        public static void TimeToLearnImages(int value, TableLayoutPanel tableLayoutPanel)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = Color.White;
            }
            timer2.Interval = value * 1000;

            timer2.Start();
        }


        public static void addingImagestoTiles(TableLayoutPanel tableLayoutPanel,int tilesnumber)
        {
            fillingTheIcons(tilesnumber);

            ShufflingTheList();
            int i = 0;
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.Text = icons[i++];
            }
        }
        public static void fillingTheIcons(int number)
        {
            foreach (string icon in wholeSet.Take(number))
            {
                icons.Add(icon);
            }
        }

        public static void ShufflingTheList()
        {
            //icons = icons.OrderBy(i => Guid.NewGuid()).ToList();
        }


        public static void LabelClickedLogic(object sender)
        {
            if (timer1.Enabled == true)
            {
                return;
            }

            ifCardsAreCovered = false;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.White)
                    return;
            }

            if (firstCardSelected == null)
            {
                firstCardSelected = clickedLabel;
                firstCardSelected.ForeColor = Color.White;
                return;
            }

            secondCardSelected = clickedLabel;
            secondCardSelected.ForeColor = Color.White;

            ChecksIfTheGameEnds(tableLayoutPanel,form);

            if (firstCardSelected.Text == secondCardSelected.Text)
            {
                firstCardSelected = null;
                secondCardSelected = null;
                ifCardsAreCovered = true;
                return;
            }

            timer1.Start();
        }



    }
}
