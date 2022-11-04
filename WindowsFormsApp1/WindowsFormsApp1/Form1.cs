using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        Bitmap ima;
        Bitmap tempa;
        Bitmap comp;
        int scrollvalue = 0;
        int edgevalue = 0;
        Color black = Color.FromArgb(0, 0, 0);
        Color White = Color.FromArgb(255, 255, 255);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);
                    Color redPxl = Color.FromArgb(pxl.R, pxl.R, pxl.R);

                    ima.SetPixel(x, y, redPxl);
                }
            }
            pictureBox2.Image = ima;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ima == null) return;
            tempa = new Bitmap(ima);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);
                    Color redPxl = Color.FromArgb(pxl.B, pxl.B, pxl.B);

                    ima.SetPixel(x, y, redPxl);
                }
            }
            pictureBox2.Image = ima;
            
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                ima = new Bitmap(openFileDialog1.FileName);
            
                tempa = ima;
                pictureBox1.Image = ima;
                pictureBox2.Image = ima;

            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ima.Save(sfd.FileName);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);
                    Color redPxl = Color.FromArgb(pxl.G, pxl.G, pxl.G);

                    ima.SetPixel(x, y, redPxl);
                }
            }
            pictureBox2.Image = ima;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);
                    
                    int avg = (pxl.R + pxl.G + pxl.B) / 3;
                    Color redPxl = Color.FromArgb(avg, avg, avg);
                    ima.SetPixel(x, y, redPxl);
                }
            }
            pictureBox2.Image = ima;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (tempa == null) return;
            pictureBox2.Image = tempa;
            ima = new Bitmap(tempa);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            int[,,] buffer = new int[3, ima.Height, ima.Width];
            
            for (int row = 0; row < ima.Height; row++)
                for (int col = 0; col < ima.Width; col++)
                {
                    Color pixle = ima.GetPixel(col, row);
                    buffer[0, row, col] = pixle.R;
                    buffer[1, row, col] = pixle.G;
                    buffer[2, row, col] = pixle.B;
                }
            for (int row = 1; row < ima.Height-1; row++)
                for (int col = 1; col < ima.Width-1; col++)
                {
                    int Red = buffer[0, row - 1, col - 1] + buffer[0, row - 1, col] + buffer[0, row - 1, col + 1] +
                        buffer[0, row, col - 1] + buffer[0, row, col] + buffer[0, row, col + 1] +
                        buffer[0, row+1, col - 1] + buffer[0, row+1, col] + buffer[0, row+1, col + 1];
                    int Green = buffer[1, row - 1, col - 1] + buffer[1, row - 1, col] + buffer[1, row - 1, col + 1] +
                        buffer[1, row, col - 1] + buffer[1, row, col] + buffer[1, row, col + 1] +
                        buffer[1, row + 1, col - 1] + buffer[1, row + 1, col] + buffer[1, row + 1, col + 1];
                    int Blue = buffer[2, row - 1, col - 1] + buffer[2, row - 1, col] + buffer[2, row - 1, col + 1] +
                        buffer[2, row, col - 1] + buffer[2, row, col] + buffer[2, row, col + 1] +
                        buffer[2, row + 1, col - 1] + buffer[2, row + 1, col] + buffer[2, row + 1, col + 1];
                    Color target = Color.FromArgb(Red / 9, Green / 9, Blue / 9);
                    ima.SetPixel(col, row, target);
                }
            pictureBox2.Image = ima;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            int[,,] buffer = new int[3, ima.Height, ima.Width];
            
            for (int row = 0; row < ima.Height; row++)
                for (int col = 0; col < ima.Width; col++)
                {
                    Color pixle = ima.GetPixel(col, row);
                    buffer[0, row, col] = pixle.R;
                    buffer[1, row, col] = pixle.G;
                    buffer[2, row, col] = pixle.B;
                }
            for (int row = 1; row < ima.Height - 1; row++)
                for (int col = 1; col < ima.Width - 1; col++)
                {


                    int[] buffert = {buffer[0, row - 1, col - 1] , buffer[0, row - 1, col] , buffer[0, row - 1, col + 1] ,
                        buffer[0, row, col - 1] , buffer[0, row, col] , buffer[0, row, col + 1] ,
                        buffer[0, row + 1, col - 1] , buffer[0, row + 1, col] , buffer[0, row + 1, col + 1] };
                    Array.Sort(buffert);

                    int Red = buffert[4];
                    int[] buffert1 = {buffer[1, row - 1, col - 1] , buffer[1, row - 1, col] , buffer[1, row - 1, col + 1] ,
                        buffer[1, row, col - 1] , buffer[1, row, col] , buffer[1, row, col + 1] ,
                        buffer[1, row + 1, col - 1] , buffer[1, row + 1, col] , buffer[1, row + 1, col + 1] };
                    Array.Sort(buffert1);
                    int Green = buffert1[4];

                    int[] buffert2 = {buffer[2, row - 1, col - 1] , buffer[2, row - 1, col] , buffer[2, row - 1, col + 1] ,
                        buffer[2, row, col - 1] , buffer[2, row, col] , buffer[2, row, col + 1] ,
                        buffer[2, row + 1, col - 1] , buffer[2, row + 1, col] , buffer[2, row + 1, col + 1] };
                    Array.Sort(buffert2);
                    int Blue = buffert2[4];

                    Color target = Color.FromArgb(Red, Green, Blue);
                    ima.SetPixel(col, row, target);
                }
            pictureBox2.Image = ima;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);

                    if(pxl.R>= scrollvalue) { 
                        Color redPxl = Color.FromArgb(255, 255, 255);
                        ima.SetPixel(x, y, redPxl);
                    }
                    else
                    {
                        Color redPxl = Color.FromArgb(0, 0, 0);
                        ima.SetPixel(x, y, redPxl);
                    }
                }
            }
            pictureBox2.Image = ima;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "" + trackBar1.Value; 
             scrollvalue = trackBar1.Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            Bitmap tempsob = new Bitmap(ima.Width, ima.Height);
            int[][] vertical = {new int[] {-1, 0, 1},
                          new int[] {-2, 0, 2},
                          new int[] {-1, 0, 1}};
            for (int i = 1; i < ima.Width - 1; i++)
            {
                for (int j = 1; j < ima.Height - 1; j++)
                {
                    int dx = ima.GetPixel(i - 1, j - 1).R * vertical[0][0] + ima.GetPixel(i, j - 1).R * vertical[0][1] + ima.GetPixel(i + 1, j - 1).R * vertical[0][2]
                              + ima.GetPixel(i - 1, j).R * vertical[1][0] + ima.GetPixel(i, j).R * vertical[1][1] + ima.GetPixel(i + 1, j).R * vertical[1][2]
                              + ima.GetPixel(i - 1, j + 1).R * vertical[2][0] + ima.GetPixel(i, j + 1).R * vertical[2][1] + ima.GetPixel(i + 1, j + 1).R * vertical[2][2];

                    double tvalue = Math.Sqrt((dx * dx));

                    if (tvalue > 255)
                    {
                        tempsob.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        tempsob.SetPixel(i, j, Color.FromArgb((int)tvalue, (int)tvalue, (int)tvalue));
                    }
                }
            }
            ima = new Bitmap(tempsob);
            pictureBox2.Image = ima;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            Bitmap tempsob = new Bitmap(ima.Width, ima.Height);
            int[][] horizon = {new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};

            for (int i = 1; i < ima.Width - 1; i++)
            {
                for (int j = 1; j < ima.Height - 1; j++)
                {
                    int dy = ima.GetPixel(i - 1, j - 1).R * horizon[0][0] + ima.GetPixel(i, j - 1).R * horizon[0][1] + ima.GetPixel(i + 1, j - 1).R * horizon[0][2]
                              + ima.GetPixel(i - 1, j).R * horizon[1][0] + ima.GetPixel(i, j).R * horizon[1][1] + ima.GetPixel(i + 1, j).R * horizon[1][2]
                              + ima.GetPixel(i - 1, j + 1).R * horizon[2][0] + ima.GetPixel(i, j + 1).R * horizon[2][1] + ima.GetPixel(i + 1, j + 1).R * horizon[2][2];

                    double tvalue = Math.Sqrt((dy * dy));

                    if (tvalue > 255)
                    {
                        tempsob.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        tempsob.SetPixel(i, j, Color.FromArgb((int)tvalue, (int)tvalue, (int)tvalue));
                    }
                }
            }
            ima = new Bitmap(tempsob);
            pictureBox2.Image = ima;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            Bitmap tempsob = new Bitmap(ima.Width, ima.Height);
            int[][] vertical = {new int[] {-1, 0, 1},
                          new int[] {-2, 0, 2},
                          new int[] {-1, 0, 1}};
            int[][] horizon = {new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};

            for (int i = 1; i < ima.Width - 1; i++)
            {
                for (int j = 1; j < ima.Height - 1; j++)
                {
                    int dx = ima.GetPixel(i - 1, j - 1).R * vertical[0][0] + ima.GetPixel(i, j - 1).R * vertical[0][1] + ima.GetPixel(i + 1, j - 1).R * vertical[0][2]
                              + ima.GetPixel(i - 1, j).R * vertical[1][0] + ima.GetPixel(i, j).R * vertical[1][1] + ima.GetPixel(i + 1, j).R * vertical[1][2]
                              + ima.GetPixel(i - 1, j + 1).R * vertical[2][0] + ima.GetPixel(i, j + 1).R * vertical[2][1] + ima.GetPixel(i + 1, j + 1).R * vertical[2][2];
                    int dy = ima.GetPixel(i - 1, j - 1).R * horizon[0][0] + ima.GetPixel(i, j - 1).R * horizon[0][1] + ima.GetPixel(i + 1, j - 1).R * horizon[0][2]
                              + ima.GetPixel(i - 1, j).R * horizon[1][0] + ima.GetPixel(i, j).R * horizon[1][1] + ima.GetPixel(i + 1, j).R * horizon[1][2]
                              + ima.GetPixel(i - 1, j + 1).R * horizon[2][0] + ima.GetPixel(i, j + 1).R * horizon[2][1] + ima.GetPixel(i + 1, j + 1).R * horizon[2][2];

                    double tvalue = Math.Sqrt((dy * dy)+(dx*dx));

                    if (tvalue > 255)
                    {
                        tempsob.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        tempsob.SetPixel(i, j, Color.FromArgb((int)tvalue, (int)tvalue, (int)tvalue));
                    }
                }
            }
            ima = new Bitmap(tempsob);
            pictureBox2.Image = ima;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "" + trackBar2.Value;
            edgevalue = trackBar2.Value;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (ima == null) return;
            tempa = new Bitmap(ima);
            Bitmap getso = new Bitmap(pictureBox1.Image);
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);

                    if (pxl.R >= edgevalue)
                    {
                        Color thre = Color.FromArgb(255, 255, 255);
                        ima.SetPixel(x, y, thre);
                    }
                    else
                    {
                        Color thre = Color.FromArgb(0, 0, 0);
                        ima.SetPixel(x, y, thre);
                    }
                }
            }
            for (int x = 0; x < ima.Width; x++)
            {
                for (int y = 0; y < ima.Height; y++)
                {
                    Color pxl = ima.GetPixel(x, y);
                    Color soc = getso.GetPixel(x, y);
                    if (pxl.R >= edgevalue && pxl.G >= edgevalue && pxl.B >= edgevalue)
                    {
                        Color gree = Color.FromArgb(0, 255, 0);
                        ima.SetPixel(x, y, gree);
                    }
                    else
                    {

                        Color ori = Color.FromArgb(soc.R, soc.G, soc.B);
                        ima.SetPixel(x, y, ori);
                    }
                }
            }
            pictureBox2.Image = ima;

        }

        private void button17_Click(object sender, EventArgs e)
        {

            Color[] label = new Color[255];


            int chex = 0;
            int chey = 0;
            Random rnd = new Random(4);
            Random rnd1 = new Random(56);
            Random rnd2 = new Random(65);

            if (ima == null) return;
            tempa = new Bitmap(ima);
            Color pxl  ;
            Bitmap tempdraw = new Bitmap(ima);
            Color rightupper ;
            Color leftupper ;
            int codex = 0;

            for (int y = 0; y < tempdraw.Height; y++)
            {
                for (int x = 0; x < tempdraw.Width; x++)
                {
                    
                    pxl = tempdraw.GetPixel(x, y);
                    

                    if (pxl.R==0 && pxl.G == 0&& pxl.B == 0)
                    {
                        for (int pos = 1; pos < 10; pos++)
                        {
                            if (pos == 5) continue;

                            if (pos % 3 != 0)
                            { chey = ((pos % 3) - 2); }
                            else
                            {
                                chey = 1;
                            }
                            chex = (pos) / 3 - 1;
                            if ((x + chex) < 0 || (x + chex) >= tempdraw.Width || (y + chey) < 0|| (y + chey) >= tempdraw.Height) continue;
                            Color nearp=tempdraw.GetPixel(x + chex,y + chey);
                            if(nearp!=White&&nearp!=black&&pos<7)
                            {
                                Color gree = Color.FromArgb(nearp.R, nearp.G, nearp.B);
                                tempdraw.SetPixel(x, y, gree);
                                break;
                            }
                            if(pos==9)
                            {
                                
                                Color randcolor = Color.FromArgb(rnd.Next(1,254), rnd1.Next(1, 254), rnd2.Next(1, 254)); 
                                

                                codex++;
                                Boolean key =false;
                                if(codex!=0)
                                    while (key==false)
                                    {
                                        key = true;
                                        for (int co = 0; co < codex; co++)
                                        {
                                            if (randcolor == label[co]) key = false;
                                        }
                                        randcolor = Color.FromArgb(rnd1.Next(1, 254), rnd.Next(1, 254), rnd2.Next(1, 254));
                                    }
                                tempdraw.SetPixel( x, y,randcolor);
                            }
                        }

                    }
                    int a1 = 1;
                    
                    pxl = tempdraw.GetPixel(x, y);
                    if (x != 0 && x != tempdraw.Width - 1 && y != 0 && y != tempdraw.Height - 1 && pxl != White)
                    {

                        if (pxl != tempdraw.GetPixel(x + 1, y - 1) && tempdraw.GetPixel(x + 1, y - 1) != White && tempdraw.GetPixel(x + 1, y - 1) != black)
                        {
                            leftupper = tempdraw.GetPixel(x + 1, y - 1);
                            for (int i = 0; i < tempdraw.Height; i++)
                            {
                                for (int j = 0; j < tempdraw.Width; j++)
                                {
                                    if (tempdraw.GetPixel(j, i) == leftupper)
                                    {
                                        tempdraw.SetPixel(j, i, pxl);
                                        if (a1 > 0)
                                        {
                                           
                                            a1--;                                           
                                            codex--;
                                        }

                                    }

                                }
                            }
                            continue;
                        }


                    }

                }
            }



            label12.Text = $"Number of connected regions: { codex}";
            pictureBox2.Image = tempdraw;
            ima= new Bitmap(tempdraw);
        }
        int cou=0;
        int cou1 = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            if (cou == 0)
                cou++;
            else
                chart1.Series[0].Points.Clear();
            if (cou1 == 0)
                cou1++;
            else
                chart2.Series[0].Points.Clear();

            chart1.Visible = true;
            chart2.Visible = true;
            if (ima == null) return;
            tempa = new Bitmap(ima);
            Bitmap getso = new Bitmap(ima);
            int[] grayorin = new int[256];
            double[] grayposs = new double[256];
            int[] grayaffte = new int[256];
            for (int i = 0; i < 256; i++)
            {
                grayorin[i] = 0;
                grayaffte[i] = 0;
            }
            for (int i = 0; i < ima.Height;i++)
            {
                for(int j=0;j<ima.Width;j++)
                {
                        grayorin[getso.GetPixel(j, i).R]++;
                }
            }
            chart1.ChartAreas[0].AxisX.Interval = 50;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.BorderlineWidth = 1;
            chart2.ChartAreas[0].AxisX.Interval = 50;
            chart2.ChartAreas[0].AxisX.Maximum = 255;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.BorderlineWidth = 1;
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[0].Points.AddXY(i, grayorin[i]);
                double rate = grayorin[i] / (ima.Height * ima.Width * 1.0);
                grayposs[i] = rate;
            }
            for(int j=0;j<ima.Height;j++)
                for(int i=0;i<ima.Width;i++)
                {
                    double densum = 0;
                    Color val = ima.GetPixel(i, j);
                    for(int k = 0; k <= val.R; k++)
                    {
                        densum += grayposs[k];
                    }
                    byte s = (byte)Math.Round(255 * densum);
                    grayaffte[s]++;
                    Color newval = Color.FromArgb(s, s, s);
                    getso.SetPixel(i, j, newval);
                }
            for (int i = 0; i < 256; i++)
                chart2.Series[0].Points.AddXY(i, grayaffte[i]);
            ima = new Bitmap(getso);
            pictureBox2.Image = ima;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                comp = new Bitmap(openFileDialog1.FileName);
                pictureBox3.Image = comp;

            }


        }
        private void Mousemovef(object sender, MouseEventArgs e)
        {

            if (ima != null)
                if ((e.X < ima.Width) && (e.Y < ima.Height))
                {
                    label7.Text = $"x:  {e.X}";
                    label8.Text = $"y:  {e.Y}";
                }
        }
        int[,] mou1 =new int[4,2];
        private void Mousemove1(object sender, MouseEventArgs e)
        {
            
            if(ima!=null)
            if ((e.X < ima.Width) && (e.Y < ima.Height))
            {
                label3.Text = $"x:  {e.X}";
                label4.Text = $"y:  {e.Y}";
            }
        }
        int pic1count = 1;
        private void Mouseclick1(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            if (ima != null)
                if ((e.X < ima.Width) && (e.Y < ima.Height) && pic1count < 5)
                {

                    string outpu= $"PIC1 point {pic1count}: x:  {e.X}, y:  {e.Y} .";

                    outpu = outpu.Replace(".", "." + Environment.NewLine);
                    textBox1.AppendText(outpu);
                    mou1[pic1count - 1, 0] = e.X;
                    mou1[pic1count - 1, 1] = e.Y;
                    pic1count++;
                }
        }
        int[,] mou2 = new int[4, 2];
        private void Mousemove2(object sender, MouseEventArgs e)
        {

            if (ima != null&&comp!=null)
                if ((e.X < comp.Width) && (e.Y < comp.Height))
                {
                    label5.Text = $"x:  {e.X}";
                    label6.Text = $"y:  {e.Y}";
                }
        }
        int pic2count = 1;
        private void Mouseclick2(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            if (ima != null)
                if ((e.X < comp.Width) && (e.Y < comp.Height) && pic2count < 5)
                {

                    string outpu = $"PIC2 point {pic2count}: x:  {e.X}, y:  {e.Y} .";

                    outpu = outpu.Replace(".", "." + Environment.NewLine);
                    textBox1.AppendText(outpu);
                    mou2[pic2count - 1, 0] = e.X;
                    mou2[pic2count - 1, 1] = e.Y;
                    pic2count++;
                }
        }

        public static Bitmap resizeImage(Image imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }
        public Bitmap RotateImage(Bitmap b, float angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            returnBitmap.SetResolution(b.HorizontalResolution, b.VerticalResolution);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            

            if (ima == null||comp==null) return;
            tempa = new Bitmap(ima);
            Point A = new Point(mou1[0,0], mou1[0, 1]);
            Point B = new Point(mou1[1, 0], mou1[1, 1]);
            Point C = new Point(mou2[0, 0], mou2[0, 1]);
            Point D = new Point(mou2[1, 0], mou2[1, 1]);
            int Orinwidth = ima.Width;
            int Orinhigh = ima.Height;
            A = new Point(0,0 );
            B = new Point(mou1[1, 0]- mou1[0, 0], mou1[1, 1]- mou1[0, 1]);
            C = new Point(mou2[0, 0], mou2[0, 1]);
            D = new Point(mou2[1, 0], mou2[1, 1]);
            double ABDis = Convert.ToInt32((Math.Pow(Math.Pow(A.X - B.X, 2.0) + Math.Pow(A.Y - B.Y, 2.0), 0.5)));
            double CDDis = Convert.ToInt32((Math.Pow(Math.Pow(C.X - D.X, 2.0) + Math.Pow(C.Y - D.Y, 2.0), 0.5)));
            double scale = (double)(CDDis / ABDis);

            D.X = D.X - (C.X - A.X);
            D.Y = D.Y - (C.Y - A.Y);
            C.X = C.X - (C.X - A.X);
            C.Y = C.Y - (C.Y - A.Y);
            double rotation = 0, l1 = 0, l2 = 0;
            l1 = Math.Sqrt(B.X * B.X + B.Y * B.Y);

            l2 = Math.Sqrt(D.X * D.X + D.Y * D.Y);
            rotation = Math.Acos((B.X * D.X + B.Y * D.Y) / (l1 * l2));

            int angle = (int)(Math.Round((180 / Math.PI) * rotation));
            double orinvecx = 0 - ima.Width/2 ; 
            double orinvecy = 0 - ima.Height/2 ;
            double radi = angle * Math.PI / 180;
            double tempo = orinvecx;
            orinvecx = (double)(orinvecx * Math.Cos(radi) + orinvecy * Math.Sin(radi));
            
            orinvecy = (double)(orinvecy * Math.Cos(radi) - tempo * Math.Sin(radi));

            orinvecx = orinvecx * scale;
            orinvecy = orinvecy * scale;
            tempo = orinvecx;
            orinvecx = (double)(orinvecx * Math.Cos(0-radi) + orinvecy * Math.Sin(0-radi));

            orinvecy = (double)(orinvecy * Math.Cos(0-radi) - tempo * Math.Sin(0-radi));

            Bitmap newnew = RotateImage(comp, 0 - angle);

            Point newpoint = new Point((int) (newnew.Width / 2 + orinvecx), (int)(newnew.Height / 2 + orinvecy));

            Size sizz = new Size((int)(Orinwidth * scale), (int)(Orinhigh * scale)); 

            Rectangle Area = new Rectangle(newpoint, sizz);
            


            Bitmap nonsc = new Bitmap(newnew.Clone(Area, newnew.PixelFormat));
            Bitmap sc = new Bitmap(nonsc, Orinwidth, Orinhigh);
            double sum = 0;
            for (int i = 0; i < ima.Height; i++)
            {
                for (int j = 0; j < ima.Width; j++)
                {
                    sum += Math.Abs(ima.GetPixel(j, i).R - sc.GetPixel(j, i).R);
                }
            }
            sum= sum / (ima.Height * ima.Width);
            label9.Text =$"Scale factor : {scale}";
            label10.Text = $"rotation angle : {angle}";
            label11.Text = $"Intensity difference : {sum}";
            pictureBox2.Image = sc;
            ima = new Bitmap(sc);


        }
        public static Bitmap Resize1(Image image, int width, int height)
        {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            pic2count = 1;
            pic1count = 1;
            textBox1.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
