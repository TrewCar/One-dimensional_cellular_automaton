using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    List<int> Row = new List<int>();

    int Rule = 110;
    string RuleBinary;

    int SizeRect = 3;

    int rowN;
    int col;

    int ColN;

    Graphics g;

    private void Form1_Load(object sender, EventArgs e)
    {
        _GroupBox.Location = new Point(0, 0);// Width / 2 - _GroupBox.Size.Width / 2, Height / 2 - _GroupBox.Size.Height / 2);

        Random rand = new Random();
        pictureBox1.Image = new Bitmap(Width, Height);
        g = Graphics.FromImage(pictureBox1.Image);

        rowN = Width / SizeRect;
        col = Height / SizeRect;

        for (int i = 0; i < rowN; i++)
        {
            Row.Add(0);// rand.Next(2));
        }
        Row[Row.Count/2] = 1;
    }
    private void SetRule() => RuleBinary = Rule.ToBinary();

    private void Draw(int x, int y) => g.FillRectangle(new SolidBrush(Color.Black), x * SizeRect, y * SizeRect, SizeRect, SizeRect);

    private int SubstractToInt(int Binary) => int.Parse(RuleBinary[Binary].ToString());

    private void timer1_Tick(object sender, EventArgs e)
    {

        for (int i = 0; i < Row.Count; i++)
        {
            if (Row[i] == 1)
                Draw(i, ColN);
        }
        ColN++;
        List<int> temp = new List<int>();
        for (int i = 0; i < Row.Count; i++)
        {
            int first = i == 0 ? Row[Row.Count - 1] : Row[i - 1];
            int second = Row[i];
            int three = i == Row.Count - 1 ? Row[0] : Row[i + 1];

            int Binary = -$"{first}{second}{three}".ToDecimal() + 7;
            temp.Add(SubstractToInt(Binary));
        }
        Row = temp;
        if (ColN >= col)
        {
            pictureBox1.Image = new Bitmap(Width, Height);
            g = Graphics.FromImage(pictureBox1.Image);
            ColN = 0;
        }
        pictureBox1.Refresh();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Rule = int.Parse(textBox1.Text);
        if (Rule >= 255)
        {
            Rule = 255;
            textBox1.Text = 255.ToString();
        }
        else if (Rule <= 0)
        {
            Rule = 0;
            textBox1.Text = 0.ToString();
        }
        SetRule();
        timer1.Start();
    }
}

