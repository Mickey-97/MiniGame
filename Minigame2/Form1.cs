using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigame2
{
    public class CHero
    {
        public int X, Y;
        public int yDir = -45;
        public Color cl;
        public int taken;
    }
    public class CEnemy
    {
        public int X, Y;
        public int yDir, xDir;
        public Color cl;
        public int taken;
    }
    public class CEnemy2
    {
        public int X, Y;
        public int W, H;
        public int yDir, xDir;
        public int wDir, hDir;
        public Color cl;
        public int taken;
        public bool move = true;
        public bool move2 = true;
        public bool move3 = true;

    }
    public partial class Form1 : Form
    {
        Bitmap off;
        Bitmap img;
        int imgx, imgy;
        int fail = 0;
        int val;
        int k = 0;
        Timer t = new Timer();
        int countick = 1;
        int countimer =0;
        int Score =0;
        int flagmove = 0;
        int flagnew = 0;
        List<CHero> L = new List<CHero>();
        List<CEnemy> L2 = new List<CEnemy>();// lvl 1
        List<CEnemy> L3 = new List<CEnemy>();// lvl 1
        List<CEnemy> L4 = new List<CEnemy>();// lvl 2
        List<CEnemy2> L5 = new List<CEnemy2>();// lvl 3
        List<CEnemy2> L6 = new List<CEnemy2>();// lvl 4
        int index = 0;
        Color[] Z = { Color.Green, Color.Yellow, Color.Blue, Color.Red, Color.Black};
        Color[] Z2 = { Color.Green, Color.Yellow, Color.Blue, Color.Red, Color.Black, Color.Green, Color.Yellow, Color.Blue, Color.Red, Color.Black,Color.Yellow,Color.Blue};
        Random R = new Random();
        int XS = 720;
        int YS = 300;
        int Spacing = 100;
        int flaglvl = 0;
        int levelcounter = 0;
        int levelcounter2 = 0;
        int levelcounter3 = 0;
        int levelcounter4 = 0;
        int levelcounter5 = 0;
        int flagdraw = 0;
        int i = 0;
        int zft = 1;
        int zft2 = 1;
        int zft3 = 1;
        int flagcloud = 0;
        int[] pos2 = { -1, -1, -1, -1, -1 , -1, -1, -1, -1, -1,-1,-1 };
        int[] pos3 = { -1, -1, -1, -1, -1 };
        int sc = 1;
        public Form1()
        {
            this.Load +=Form1_Load;
            this.Paint += Form1_Paint;
            FormBorderStyle = FormBorderStyle.None;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            WindowState = FormWindowState.Maximized;
            t.Tick += t_Tick;
            t.Start();
            t.Interval = 1;
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            //MessageBox.Show("e.x---->  " + e.X + "e.y----->     " + e.Y);
        }

        void t_Tick(object sender, EventArgs e)
        {
          

           if (sc == 1 && flagcloud == 1)
           {
               System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MiniGame2\MiniGame2\bin\Debug\2.wav");
               player2.Play();
               sc = 0;
           }
            /*new ball*/
            if (flagnew == 1 && flagdraw !=5)
            {
                CHero pnn = new CHero();
                pnn.X = 930;
                pnn.Y = 800;
                pnn.cl = Z[index];
                L.Add(pnn);
                flagnew = 0;
            }

            /* Timer*/
          
                if (flaglvl==1)
                {
                    countimer = 1;
                }

                if (flaglvl == 2)
                {
                    countimer = 2;
                }
                if (flaglvl == 3)
                {
                    countimer = 3;
                }
                if (flaglvl == 4)
                {
                    countimer = 4;
                }
                if (flaglvl == 5)
                {
                    countimer = 0;
                }

            /* Ball hit checks*/
           
                if (countick % 1 == 0)
                {
                    if (flagmove == 1)
                    {
                        for (int i = 0; i < L.Count; i++)
                        {
                            CHero pnn = L[i];
                            for (int k = 0; k < L2.Count; k++)
                            {
                                CEnemy ptrav = L2[k];
                                val = 50;
                                if (isHit(pnn.X, pnn.Y, ptrav,val))
                                {
                                    if (pnn.cl == ptrav.cl)
                                    {
                                        L2.RemoveAt(k);
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        Score++;
                                    }
                                    else
                                    {
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        fail++;
                                    }

                                }

                            }
                            for (int k = 0; k < L3.Count; k++)
                            {
                                CEnemy ptrav = L3[k];
                                val = 50;
                                if (isHit(pnn.X, pnn.Y, ptrav,val))
                                {
                                    if (pnn.cl == ptrav.cl)
                                    {
                                        L3.RemoveAt(k);
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        Score++;
                                    }
                                    else
                                    {
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        fail++;
                                    }

                                }

                            }
                            for (int k = 0; k < L4.Count; k++)
                            {

                                CEnemy ptrav = L4[k];
                                val = 150;
                                if (isHit(pnn.X, pnn.Y, ptrav, val))
                                {
                                    if (pnn.cl == ptrav.cl)
                                    {
                                        L4.RemoveAt(k);
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        Score++;
                                    }
                                    else
                                    {
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        fail++;
                                    }

                                }
                            }
                            for (int k = 0; k < L5.Count; k++)
                            {

                                CEnemy2 ptrav = L5[k];
                                val = 50;
                                if (isHit2(pnn.X, pnn.Y, ptrav, val))
                                {
                                    if (pnn.cl == ptrav.cl)
                                    {
                                        L5.RemoveAt(k);
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        Score++;
                                    }
                                    else
                                    {
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        fail++;
                                    }

                                }
                            }
                            for (int k = 0; k < L6.Count; k++)
                            {
                                CEnemy2 ptrav = L6[k];
                                val = 50;
                                if (isHit2(pnn.X, pnn.Y, ptrav, val))
                                {
                                    if (pnn.cl == ptrav.cl)
                                    {
                                        L6.RemoveAt(k);
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        Score++;
                                    }
                                    else
                                    {
                                        flagnew = 1;
                                        L.RemoveAt(i);
                                        index = R.Next(5);
                                        flagmove = 0;
                                        fail++;
                                    }

                                }
                          
                            
                            }


                                if (pnn.Y < 0)
                                {
                                    flagnew = 1;
                                    L.RemoveAt(i);
                                    index = R.Next(5);
                                    flagmove = 0;
                                    fail++;

                                }
                            pnn.Y += pnn.yDir;
                        }


                    }
                }

            /* lvl 2*/
            if(zft ==1 && countimer ==2)
            {
            
                int currX ;
                int currY = YS - 200;
                CEnemy pnn2 = null;
                int v2;
                for (int r = 0; r < 3; r++)
                {

                    currX = XS -50;
                    int[] pos = { -1, -1, -1, -1, -1};
               
                    for (int c = 0 ; c < 3  ; c++)
                    {

                        pnn2 = new CEnemy();


                        while (true)
                        {
                            v2 = R.Next(5);
                            if (!isExist(v2, pos))
                            {
                                pos[c] = v2;
                                break;
                            }
                        }

                        if (true)
                        { 
                        pnn2.cl = Z[v2];
                        pnn2.X = currX;
                        pnn2.Y = currY;
                        currX += Spacing + 100;

                        L4.Add(pnn2);
                        }
                    }
                    currY += Spacing + 100;
                }
                zft = 0;
                L4.RemoveAt(4);
            }
            /* lvl 3*/
            if (countick % 10 == 0)
            {

                if (zft2 <=13 && countimer ==3)
                {

                    int currX;
                    int currY = YS;
                 
                    int v2;
               
                    currX = XS;
             

                            CEnemy2 pnn = new CEnemy2();
                            
                            while (true)
                            {
                                v2 = R.Next(12);
                                if (!isExist(v2, pos2))
                                {
                                    pos2[i] = v2;
                                    break;
                                }
                            }

                       
                            pnn.xDir = 10;
                            pnn.yDir = 0;
                            pnn.cl = Z2[v2];
                            pnn.W = 50;
                            pnn.H = 50;
                            pnn.X = currX +510;
                            pnn.Y = 400;

                            currX += Spacing +50;

                            L5.Add(pnn);
                        

        
                    zft2++;
                    if(zft2 >=13)
                    {
                        zft2 = 14;
                    }
                    i++;
                }

            }
            if (countick % 1 == 0)
            { 
                if (flaglvl == 4)
                {
                    if (imgy < 10)
                    { imgy += 5; }
                    else
                    {
                        flagcloud = 1;
               
                    }
              
                }

            }

            if (flagcloud == 1)
            {
                if (countick %50 == 0)
                {
                  
                    if (zft3 <= 6 && countimer == 4)
                    {

                        int currX;
                        int currY = YS;

                        int v2;

                        currX = XS;


                        CEnemy2 pnn = new CEnemy2();

                        while (true)
                        {
                            v2 = R.Next(5);
                            if (!isExist(v2, pos3))
                            {
                                pos3[k] = v2;
                                break;
                            }
                        }


                        pnn.xDir = 0;
                        pnn.yDir = 0;
                        pnn.cl = Z[v2];
                        pnn.W = 50;
                        pnn.H = 50;
                        pnn.X = currX + 200;
                        pnn.Y = 100;

                        currX += Spacing + 50;

                        L6.Add(pnn);



                        zft3++;
                        if(zft3 >= 6)
                        {
                            zft3 = 7;
                        }
                        k++;
                    }

                }

            }
            if (flaglvl == 5)
            {
                this.Close();
            }
           

                /*Movments*/
                for (int i = 0; i < L2.Count; i++)
                {
                    CEnemy ptrav = L2[i];
                    if (ptrav.X > 1220)
                    {
                        ptrav.X = 600;
                    }
                    ptrav.X += ptrav.xDir;
                }
                for (int i = 0; i < L3.Count; i++)
                {
                    CEnemy ptrav = L3[i];
                    if (ptrav.X < 600)
                    {
                        ptrav.X = 1220;
                    }
                    ptrav.X += ptrav.xDir;
                }
                for (int i = 0; i < L4.Count; i++)
                {
                    CEnemy ptrav = L4[i];

                    if(ptrav.X == 670 && ptrav.Y==100||ptrav.X == 870 &&ptrav.Y == 100)
                    {
                        ptrav.xDir = 40;
                        ptrav.yDir = 0;
                    }

                    if (ptrav.X == 670 && ptrav.Y == 500||ptrav.X == 670 &&ptrav.Y == 300)
                    {
                        ptrav.xDir = 0;
                        ptrav.yDir = -40;
                    }

                    if (ptrav.X == 1070 && ptrav.Y == 100||ptrav.X == 1070 &&ptrav.Y == 300)
                    {
                        ptrav.xDir = 0;
                        ptrav.yDir = 40;
                    }

                    if (ptrav.X == 1070 && ptrav.Y == 500 || ptrav.X == 870 && ptrav.Y == 500)
                    {
                        ptrav.xDir = -40;
                        ptrav.yDir = 0;
                    }
         

                    L4[i].X += L4[i].xDir;
                    L4[i].Y += L4[i].yDir;
                }
                for (int i = 0; i < L5.Count; i++)
                {
                    CEnemy2 ptrav = L5[i];
                    if (ptrav.X == 1150 && ptrav.Y == 200)
                    {
                        ptrav.W = 50;
                        ptrav.H = 50;
                        ptrav.hDir = 0;
                        ptrav.wDir = 0;
                        ptrav.X = 1230;
                        ptrav.Y = 400;
                    }


                    if(ptrav.X== 1230 && ptrav.Y ==400)
                    {
                        ptrav.xDir = -10;
                    }
  

                    if(ptrav.X == 700 && ptrav.Y == 400)
                    {
                        ptrav.xDir = 0;
                        ptrav.yDir = -10;
                    }
                    if(ptrav.X ==700 && ptrav.Y == 200)
                    {
                        ptrav.xDir = 10;
                        ptrav.yDir = 0;
                        ptrav.wDir -= 1;
                        ptrav.hDir -= 1;
                    }

                    ptrav.X += ptrav.xDir;
                    ptrav.Y += ptrav.yDir;
                    ptrav.W += ptrav.wDir;
                    ptrav.H += ptrav.hDir;
                }
                for (int i = 0; i < L6.Count; i++)
                {
                    CEnemy2 ptrav = L6[i];
                    if (ptrav.Y + 50 > 145 && ptrav.Y + 50 < 355)
                    {
                        if (ptrav.move == true)
                        { ptrav.yDir = 20; }
                        
                    }
                    else
                    {
                        if (ptrav.move == true)
                        { ptrav.yDir = 0; ptrav.xDir = 20; }
                        

                        if (ptrav.X >= 1000)
                        {
                            if (ptrav.move == true)
                            { 
                                ptrav.yDir = 20;
                                ptrav.xDir = 5;
                            }
                        }
                        if (ptrav.Y + 50 == 510)
                        {
                            if (ptrav.move == true)
                            { 
                                ptrav.xDir = 20;
                                ptrav.yDir = 0;
                            }
                        }
                        if (ptrav.X + 50 >= 1290)
                        {
                            ptrav.xDir = -20;
                            ptrav.move = false;

                        }
                       
                        if (ptrav.X +50 < 800)
                        {
                            if (ptrav.move2 == true)
                            {
                                ptrav.yDir = 20;
                                ptrav.xDir = -5;
                            }
                            
                        }
                        if (ptrav.move3 == true)
                        { 
                            if (ptrav.X == 690)
                            {
                            
                                    ptrav.xDir = -20;
                                    ptrav.yDir = 0;
                                    ptrav.move2 = false; 
                            
                            }
                        }
                        if (ptrav.Y + 50 > 600)
                        { 
                            if (ptrav.X <= 602)
                            {
                                ptrav.xDir = 20;
                                ptrav.move3 = false;
                            }
                            if (ptrav.X+50 > 880)
                            {
                                //Doctor
                                ptrav.yDir = 5;
                                ptrav.xDir = 7;
                            }
                        }
                        

                    }
                    if (ptrav.Y + 50 > 800)
                    {
                       // this.Close();
                    }
                
                    ptrav.X += ptrav.xDir;
                    ptrav.Y += ptrav.yDir;
                
                }


                    if (flagdraw == 1)
                    {
                        levelcounter++;
                    }

                if (flagdraw == 2)
                {
                    levelcounter2++;
                }

                if (flagdraw == 3)
                {
                    levelcounter3++;
                }
                if (flagdraw == 4)
                {
                    levelcounter4++;
                }
                if (flagdraw == 5)
                {
                    levelcounter5++;
                }

                /* Show lvls on screen*/
                if (levelcounter > 50)
                {
                    flagdraw = 0;
                    flaglvl = 1;
                }

                if (levelcounter2 > 50)
                {
                    flagdraw = 0;
                    flaglvl = 2;

                }

                if (levelcounter3 > 50)
                {
                    flagdraw = 0;
                    flaglvl = 3;

                }
                if (levelcounter4 > 50)
                {
                    flagdraw = 0;
                    flaglvl = 4;
                }
                if (levelcounter5>30)
                {
                    flagdraw = 0;
                    flaglvl = 5;
                }
 


                /* drawing for levels*/
                if (L2.Count != 0 && L3.Count != 0 && levelcounter < 50)
                {

                    flagdraw = 1;

                }
                if (Score==10 && flaglvl != 2)
                {
                    flagdraw = 2;
                }
                if (Score == 18 && flaglvl != 3)
                {
                    flagdraw = 3;
                }
                if(Score == 30 && flaglvl != 4)
                {
                    flagdraw = 4;
                }
                if (Score == 35 && flaglvl !=5)
                {
                    flagdraw = 5;
                }

          

                    countick++;
                DrawDubb(this.CreateGraphics());
            }
        
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyCode == Keys.NumPad2)
            {
                L2.Clear();
                L3.Clear();
                Score = 10;
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                L4.Clear();
                Score = 18;
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                L5.Clear();
                Score = 30;
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                L6.Clear();
                Score = 35;
            }
            if(e.KeyCode == Keys.Right)
            {
                if (flagmove == 0)
                {
                    if (index < 4)
                        index++;
                }
            }
            if(e.KeyCode == Keys.Left)
            {
                if (flagmove == 0)
                { 
                    if (index > 0)
                        index--;
                }
            }
            if(e.KeyCode== Keys.Space)
            {
                flagmove = 1;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MiniGame2\MiniGame2\bin\Debug\1.wav");
                player.Play();
            }
          
           
            for(int i =0; i<L.Count;i++)
            {  
                CHero pnn = L[i];
                pnn.cl = Z[index];
            }
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }
        bool isHit(int X, int Y, CEnemy ptrav2, int val)
        {
            if (X > ptrav2.X
                && X < ptrav2.X + val
                && Y > ptrav2.Y
                && Y < ptrav2.Y + val
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool isHit2(int X, int Y, CEnemy2 ptrav2, int val)
        {
            if (X > ptrav2.X
                && X < ptrav2.X + val
                && Y > ptrav2.Y
                && Y < ptrav2.Y + val
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            img = new Bitmap("1.png");
            imgx = 600;
            imgy = -img.Height;

            CHero pnn = new CHero();
            pnn.X = 930;
            pnn.Y = 850;
            pnn.cl = Z[0];
            L.Add(pnn);

            


                int currX;
                int currY = YS;
                CEnemy pnn2 = null;
                int v2;
                for (int r = 0; r < 2; r++)
                {

                    currX = XS;
                    int[] pos = { -1, -1, -1, -1, -1 };
                   
                    for (int c = 0; c < 5; c++)
                    {
                        pnn2 = new CEnemy();


                        while (true)
                        {
                            v2 = R.Next(5);
                            if (!isExist(v2, pos))
                            {
                                pos[c] = v2;
                                break;
                            }
                        }
               
                        if (r == 0)
                        { pnn2.xDir = 10; }
                        else
                        { pnn2.xDir = -10; }
                        
                        pnn2.cl = Z[v2];
                        pnn2.X = currX;
                        pnn2.Y = currY;
                        currX += Spacing;
                        if (r == 0)
                        { L2.Add(pnn2); }
                        else
                        { L3.Add(pnn2); }
          
                    }

                    currY += Spacing + 50;
                }
        }
        bool isExist(int v, int[] pos)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (v == pos[i])
                    return true;
            }
            return false;
        }

        void DrawScene(Graphics g)
        {
           
            g.Clear(Color.GhostWhite);
            /* hero*/
            for(int i =0;i<L.Count;i++)
            {
                CHero ptrav = L[i];
                SolidBrush lol = new SolidBrush(L[i].cl);
                g.FillEllipse(lol, L[i].X, L[i].Y, 30, 30);
            }


            /* enemy*/
            if (flaglvl == 1)
            { 
                for (int i = 0; i < L2.Count; i++)
                {
                    CEnemy ptrav = L2[i];
                    SolidBrush lol = new SolidBrush(L2[i].cl);
                    g.FillEllipse(lol, L2[i].X, L2[i].Y, 50, 50);
            
                }
                for (int i = 0; i < L3.Count; i++)
                {
                    CEnemy ptrav = L3[i];
                    SolidBrush lol = new SolidBrush(L3[i].cl);
                    g.FillEllipse(lol, L3[i].X, L3[i].Y, 50, 50);

                }
            }


            if (flaglvl == 2)
            { 
                for (int i = 0; i < L4.Count; i++)
                {
                    CEnemy ptrav = L4[i];
                    SolidBrush lol = new SolidBrush(L4[i].cl);
                    g.FillRectangle(lol, L4[i].X, L4[i].Y, 150, 150);

                }
            }
            if(flaglvl == 3)
            {
                for (int i = 0; i < L5.Count; i++)
                {
                    CEnemy2 ptrav = L5[i];
                    SolidBrush lol = new SolidBrush(L5[i].cl);
                    g.FillEllipse(lol, L5[i].X, L5[i].Y, L5[i].W, L5[i].H);
                
                }
            }
            if (flaglvl == 4  && flagdraw !=5)
            {
                Pen P2 = new Pen (Color.Black,10);
                g.DrawImage(img, imgx, imgy, img.Width, img.Height);
                for(int i=0;i<L6.Count;i++)
                {
                    CEnemy2 ptrav = L6[i];
                    SolidBrush lol = new SolidBrush(L6[i].cl);
                    g.FillEllipse(lol, L6[i].X, L6[i].Y, 50, 50);
                }
                g.DrawLine(P2, 600, 370, 1000, 370);
                g.DrawLine(P2, 600, 680, 860, 680);
                g.DrawLine(P2, 800, 515, 1295, 515);
            }




            /* line */
            Pen P = new Pen(Color.Black, 10);
            SolidBrush B = new SolidBrush(Color.Red);
            g.DrawLine(P, 596, 0, 596, this.ClientSize.Height);
            g.DrawLine(P, 1296, 0, 1296, this.ClientSize.Height);

            
            /* time and score */
            SolidBrush BB1 = new SolidBrush(Color.Black);
            SolidBrush BB2 = new SolidBrush(Color.Red);
            SolidBrush BB3 = new SolidBrush(Color.Black);
           
            String s = "Level: " + countimer;
            Font f = new Font(FontFamily.GenericSansSerif, 50);
            Font f2 = new Font(FontFamily.GenericSansSerif, 50);
            g.DrawString(s, f, BB1, 50, 50);
            String s2 = "Score:" + Score;
            g.DrawString(s2, f, BB2, 1400, 50);
            String s3 = "Fail Shots:" + fail;
            g.DrawString(s3, f, BB2, 50, 350);
            
            if(fail >= 10)
            {
                String s10 = "IF FAIL SHOTS = 15";
                g.DrawString(s10, f2, BB1, 1290, 350);
                String s11 = "YOU LOSE :(";
                g.DrawString(s11, f2, BB1, 1290, 450);
            }
            if (fail == 15)
            { 
               this.Close();
            }
            if (flagdraw == 1)
            {
                String s4 = "Level   1";
                g.DrawString(s4, f, BB3, 800, 200);
            }
            if(flagdraw == 2)
            {
                String s4 = "Level   2";
                g.DrawString(s4, f, BB3, 800, 200);
                 
            }
            if (flagdraw == 3)
            {
                String s4 = "Level   3";
                g.DrawString(s4, f, BB3, 800, 200);

            }
            if (flagdraw == 4)
            {
                String s4 = "Level   4";
                g.DrawString(s4, f, BB3, 800, 200);

            }
            if (flagdraw == 5)
            {
                Font f3 = new Font(FontFamily.GenericSansSerif, 100);
                String s4 = "YOU WIN!!";
                g.DrawString(s4, f3, Brushes.Yellow, 590, 200);
            }
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

    }
}
