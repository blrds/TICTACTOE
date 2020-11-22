using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace LabCSH
{
    public partial class Form1 : Form
    {
        Game game;

        private List<Player> players;
        public Form1()
        {
            InitializeComponent();
        }
        private bool moveButton { get; set; }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            fieldY.Text = fieldX.Text;

        }
        private void drawField(Game game) {
            Bitmap pic = new Bitmap(800, 800);
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Brushes.Black, 3);
            double x = pic.Width / game.Size;
            double y = pic.Height / game.Size;
            Font f = new Font("Arial", Convert.ToInt32(x/2));
            for (int i = 1; i < game.Size; i++) {
                g.DrawLine(p, new Point(Convert.ToInt32(i * x), 0), new Point(Convert.ToInt32(i * x), pic.Width));
                g.DrawLine(p, new Point(0,Convert.ToInt32(i * x)), new Point(pic.Height,Convert.ToInt32(i * y)));
            }
            for (int i = 0; i < game.Field.Count; i++) {
                for (int j = 0; j < game.Field[i].Count; j++) {
                    g.DrawString(game.Field[i][j].ToString(), f, Brushes.Black, new Point(Convert.ToInt32(i * x), Convert.ToInt32(j * y)));
                }
            }
            pbField.Image = pic;
        }
        private void game_cycle() {
            bool flag = false;
            if (game.OrderedPlayer != null) {
                flag = true;
            }
            while (game.GetFreeCells().Count > 0)            // Если доступных ячеек нет -> выход из цикла
            {/*данный цикл я планировал вынести в отедльный поток при помощи Thread*/
                foreach (Player p in game.Players)
                {
                    actualPlayer.Text = p.Name;
                    drawField(game);
                    if (flag) {
                        if (p == game.OrderedPlayer)
                        {
                            flag = false;
                            game.OrderedPlayer = null;
                        }
                        continue;
                    }
                    string s1, s2;
                    List<Pair> free_cells = game.GetFreeCells();
                    Pair coords;
                    double time = game.Time;
                    bool moveMaked = false;
                    actualPlayer.Text = p.Name;
                    Application.DoEvents();
                    while (time > 0)
                    {
                        Application.DoEvents();
                        if (moveButton)
                        {
                            moveMaked = true;/*здесь*/
                            break;
                        }

                        time -= 0.1;
                        Thread.Sleep(100);
                    }
                    if (moveMaked)
                    {
                        game.OrderedPlayer = p;/*или здесь поток должен был ставиться на паузу*/
                        return;
                    }
                    if (!moveMaked)
                    {
                        if (game.Set(p.invent_move(game), p.Symbol))
                        {
                            drawField(game);
                            MessageBox.Show("Поздравляем игрока " + p.Name + " с победой", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterMatch();
                            
                            return;
                        }
                    }
                }

            }
            MessageBox.Show("Ничья", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            afterMatch();
        }

        private void afterMatch()
        {            
            addPlayer.Enabled = true;
            delete.Enabled = true;
            makeMove.Enabled = false;
        }

        private void START_Click(object sender, EventArgs e)
        {
            int x, y;
            try {
                x = Convert.ToInt32(fieldX.Text);
            }
            catch (Exception exc) {
                MessageBox.Show("Заданые размер не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*try
            {
                y = Convert.ToInt32(fieldX.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Wrong y index", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            y = x;
            if (x <= 2 || y <= 2) {
                MessageBox.Show("Поле с данным размером не возможно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double time=0;
            try
            {
                time = Convert.ToInt32(sleepTime.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Введенное время не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            addPlayer.Enabled = false;
            makeMove.Enabled = true;
            delete.Enabled = false;
            
            game = new Game(players, x, time, '%');
            game_cycle();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {/*здесь пользователь нажимал на картинку, поток бы продолжался ровно с того места, где закончился, но при этом поле бы уже изменилось*/
            /*но возникли некоторые вопросы и проблемы, с которыми я не понял, как разобраться
             1) Разные потоки не могут работать с одинимими переменными, в данном случае это game, была идея по адресу ее кидать, но не уверен, что сработает
            2)Толком не нашел функций Pause или Stop в Thread классе, есть такие, которые полностью выключают или останавливают на определенный срок, у меня точного времени нет*/
            if (moveButton) {
                double x = pbField.Image.Width / game.Size, y = pbField.Image.Height / game.Size;
                for (int i = 0; i < game.Field.Count; i++)
                {
                    for (int j = 0; j < game.Field[i].Count; j++)
                    {
                        if (e.X >= i * x && e.X <= (i + 1) * x)
                            if (e.Y >= j * y && e.Y <= (j + 1) * y)
                            {
                                game.Field[i][j] = game.OrderedPlayer.Symbol;
                            }
                    }
                }
                moveButton = false;
                game_cycle();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            makeMove.Enabled = true;
            START.Enabled = false;
            players = new List<Player>();
            rbMachine.Checked = true;
            pbField.Image = new Bitmap(800, 800);
            delete.Enabled = true;
            makeMove.Enabled = false;
        }

        private void addPlayer_Click(object sender, EventArgs e)
        {
            foreach (Player p in players) {
                if (p.Name == nameBox.Text) {
                    MessageBox.Show("Имя \""+ nameBox.Text + "\" уже занято", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (p.Symbol == charBox.Text[0])
                {
                    MessageBox.Show("Символ \"" + charBox.Text + "\" уже занят", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (rbMachine.Checked)
            {
                Machine m = new Machine(nameBox.Text, charBox.Text[0]);
                players.Add(m);
            }
            if (rbSmart.Checked)
            {
                SmartMachine m = new SmartMachine(nameBox.Text, charBox.Text[0]);
                players.Add(m);
            }
            nameBox.Text = "";
            charBox.Text = "";
            if (players.Count >= 2) START.Enabled = true;
            playersVL.Items.Add(players[players.Count-1].ToString());
        }

        private void makeMove_Click(object sender, EventArgs e)
        {
            moveButton = true;
        }

        private void fieldX_TextChanged(object sender, EventArgs e)
        {
            fieldY.Text = fieldX.Text;
        }

        private void charBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (charBox.TextLength==1))
            {
                e.Handled = true;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in playersVL.Items) {
                if (i.Selected)
                {
                    players.RemoveAt(i.Index);
                    playersVL.Items.Remove(i);
                }
            }
            if (players.Count < 2) START.Enabled = false;
        }
    }
}
