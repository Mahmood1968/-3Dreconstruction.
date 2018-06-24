using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging; 
using System.IO;




namespace WindowsFormsApplication1
{
   

    public partial class Form1 : Form
    {
        public double[,] PointsD = new double[8, 3];
        public int [,]RightPoints=new int[8,2];
        public int[,] LeftPoints = new int[8, 2];
        public int rl = 0,rr=0; 
        public double [,]A=new double [16,12];
        public double d = 0; 
//####################  SVD VARIABLES ######################
        public double[,] a = new double[16, 12];
        public double[]  w = new double[ 12];
        public double[,] v = new double[12, 12];
        public double[,] THREDPOINTS = new double[8, 3];
        public double[,] Fmatrix = new double[3, 3];
        
//######################   SVD SVD SVD SVD SVD SVD #########
        public double[,] M1 = new double[3, 4];
        public double[,] M2 = new double[3, 4] ;
//######################                           #########
        bool EPIFAGE = false;
        public Bitmap Leftimage = null, RightImage = null; 
     
// #######################   SVD METHOD ############

        //static double at,bt,ct;
        static double PYTHAG(double a, double b)
        {
            double at = Math.Abs(a),ct;
            double bt = Math.Abs(b);
            if (at > bt) {
                     ct=bt/at; 
                     return (at * Math.Sqrt(1.0 + ct*ct));
                     }
              else 
                if (bt >= 0.0){
                   ct=at/bt; 
                    return (bt * Math.Sqrt(1.0 + ct*ct));
                     }
                else return 0.0;

        }

        //############################################################

        public double MAX(double a, double b)
        {
            if (a > b) return a;
            else return b;
        }

        //############################################################
        public double SIGN(double a, double b)
        {
            double t;
            if (b >= 0.0) t = Math.Abs(a);
            else t = -Math.Abs(a);
            return t;
        }

        //############################################################
        public int dsvd(double[,] a, int m, int n, double[] w, double[,] v)    // ( double  a, int m, int n, float w, float v)
        {
            int flag = 0, i = 0, its = 0, j = 0, jj = 0, k = 0, l=0, nm = 0,nm1=n-1,mm1=m-1;
            double c, f, h, s, x, y, z;
            double anorm = 0.0, g = 0.0, scale = 0.0;
            double[] rv1 = new double[12];  // THE SIZE MUST BE THE SAME AS NUMBER OF COLUMNS 

            if (m < n)
            {
                Console.WriteLine("#rows must be > #cols \n");
                return (0);
            }


            for (i = 0; i < n; i++)  // i=0 ,i<n 
            {
                /* left-hand reduction */
                l = i + 1;
                rv1[i] = scale * g;
                g = s = scale = 0.0;
                if (i < m)
                {
                    for (k = i; k < m; k++)
                        scale += Math.Abs((double)a[k, i]);
                    if (scale > 0)   //!=0 
                    {
                        for (k = i; k < m; k++)
                        {
                            a[k, i] = (float)((double)a[k, i] / scale);
                            s += ((double)a[k, i] * (double)a[k, i]);
                        }
                        f = (double)a[i, i];
                        g = -SIGN(Math.Sqrt(s), f);
                        h = f * g - s;
                        a[i, i] = (float)(f - g);
                        if (i != nm1)
                        {
                            for (j = l; j < n; j++)
                            {
                                for (s = 0.0, k = i; k < m; k++)
                                    s += ((double)a[k, i] * (double)a[k, j]);
                                f = s / h;
                                for (k = i; k < m; k++)
                                    a[k, j] += (float)(f * (double)a[k, i]);
                            }
                        }
                        for (k = i; k < m; k++)
                            a[k, i] = (float)((double)a[k, i] * scale);
                       }
                     }
                    w[i] = (float)(scale * g);

                    /* right-hand reduction */
                    g = s = scale = 0.0;
                    if (i < m && i != nm1)
                    {
                        for (k = l; k < n; k++)
                            scale += Math.Abs((double)a[i, k]);
                        if (scale != 0)// !=0
                        {
                            for (k = l; k < n; k++)
                            {
                                a[i, k] = (float)((double)a[i, k] / scale);
                                s += ((double)a[i, k] * (double)a[i, k]);
                            }
                            f = (double)a[i, l];
                            g = -SIGN(Math.Sqrt(s), f);
                            h = f * g - s;
                            a[i, l] = (float)(f - g);
                            for (k = l; k < n; k++)
                                rv1[k] = (double)(a[i, k] / h);
                            if (i != mm1)
                            {
                                for (j = l; j < m; j++)
                                {
                                    for (s = 0.0, k = l; k < n; k++)
                                        s += ((double)a[j, k] * (double)a[i, k]);
                                    for (k = l; k < n; k++)
                                        a[j, k] += (float)(s * rv1[k]);
                                }
                            }
                            for (k = l; k < n; k++)
                                a[i, k] = (float)((double)a[i, k] * scale);
                        }
                    }
                    anorm = MAX(anorm, (Math.Abs((double)w[i]) + Math.Abs(rv1[i])));
                }
                
                /* accumulate the right-hand transformation */
                for (i = n - 1; i >= 0; i--)
                {
                    if (i < nm1)
                    {
                        if (g != 0)
                        {
                            for (j = l; j < n; j++)
                                v[j, i] = (float)(((double)a[i, j] / (double)a[i, l]) / g);
                            /* double division to avoid underflow */
                            for (j = l; j < n; j++)
                            {
                                for (s = 0.0, k = l; k < n; k++)
                                    s += ((double)a[i, k] * (double)v[k, j]);
                                for (k = l; k < n; k++)
                                    v[k, j] += (float)(s * (double)v[k, i]);
                            }
                        }
                        for (j = l; j < n; j++)
                            v[i, j] = v[j, i] = 0.0;
                    }
                    v[i, i] = 1.0;
                    g = rv1[i];
                    l = i;
                }

                /* accumulate the left-hand transformation */
                for (i = n - 1; i >= 0; i--)
                {
                    l = i + 1;
                    g = (double)w[i];
                    if (i < nm1)
                        for (j = l; j < n; j++)
                            a[i, j] = 0.0;
                    if (g != 0)
                    {
                        g = 1.0 / g;
                        if (i != nm1)
                        {
                            for (j = l; j < n; j++)
                            {
                                for (s = 0.0, k = l; k < m; k++)
                                    s += ((double)a[k, i] * (double)a[k, j]);
                                f = (s / (double)a[i, i]) * g;
                                for (k = i; k < m; k++)
                                    a[k, j] += (float)(f * (double)a[k, i]);
                            }
                        }
                        for (j = i; j < m; j++)
                            a[j, i] = (float)((double)a[j, i] * g);
                    }
                    else
                    {
                        for (j = i; j < m; j++)
                            a[j, i] = 0.0;
                    }
                    ++a[i, i];
                }

                /* diagonalize the bidiagonal form */
                for (k = n - 1; k >= 0; k--)
                {                                    /* loop over singular values */
                    for (its = 0; its < 30; its++)
                    {                                /* loop over allowed iterations */
                        flag = 1;
                        for (l = k; l >= 0; l--)
                        {                     /* test for splitting */
                            nm = l - 1;
                            if (Math.Abs(rv1[l]) + anorm == anorm)
                            {
                                flag = 0;
                                break;
                            }
                            if (Math.Abs((double)w[nm]) + anorm == anorm)
                                break;
                        }
                        if (flag == 1)
                        {
                            c = 0.0;
                            s = 1.0;
                            for (i = l; i <= k; i++)
                            {
                                f = s * rv1[i];
                                if (Math.Abs(f) + anorm != anorm)
                                {
                                    g = (double)w[i];
                                    h = PYTHAG(f, g);
                                    w[i] = (float)h;
                                    h = 1.0 / h;
                                    c = g * h;
                                    s = (-f * h);
                                    for (j = 0; j < m; j++)
                                    {
                                        y = (double)a[j, nm];
                                        z = (double)a[j, i];
                                        a[j, nm] = (float)(y * c + z * s);
                                        a[j, i] = (float)(z * c - y * s);
                                    }
                                }
                            }
                        }
                        z = (double)w[k];
                        if (l == k)
                        {                  /* convergence */
                            if (z < 0.0)
                            {              /* make singular value nonnegative */
                                w[k] = (float)(-z);
                                for (j = 0; j < n; j++)
                                    v[j, k] = (-v[j, k]);
                            }
                            break;
                        }
                        if (its == 30)
                        {
                            
                            Console.WriteLine("No convergence after 30,000! iterations \n");
                          //  return (0);
                        }

                        /* shift from bottom 2 x 2 minor */
                        x = (double)w[l];
                        nm = k - 1;
                        y = (double)w[nm];
                        g = rv1[nm];
                        h = rv1[k];
                        f = ((y - z) * (y + z) + (g - h) * (g + h)) / (2.0 * h * y);
                        g = PYTHAG(f, 1.0);
                        f = ((x - z) * (x + z) + h * ((y / (f + SIGN(g, f))) - h)) / x;

                        /* next QR transformation */
                        c = s = 1.0;
                        for (j = l; j <= nm; j++)
                        {
                            i = j + 1;
                            g = rv1[i];
                            y = (double)w[i];
                            h = s * g;
                            g = c * g;
                            z = PYTHAG(f, h);
                            rv1[j] = z;
                            c = f / z;
                            s = h / z;
                            f = x * c + g * s;
                            g = g * c - x * s;
                            h = y * s;
                            y = y * c;
                            for (jj = 0; jj < n; jj++)
                            {
                                x = (double)v[jj, j];
                                z = (double)v[jj, i];
                                v[jj, j] = (float)(x * c + z * s);
                                v[jj, i] = (float)(z * c - x * s);
                            }
                            z = PYTHAG(f, h);
                            w[j] = (float)z;
                            if (z !=0 )
                            {
                                z = 1.0 / z;
                                c = f * z;
                                s = h * z;
                            }
                            f = (c * g) + (s * y);
                            x = (c * y) - (s * g);
                            for (jj = 0; jj < m; jj++)
                            {
                                y = (double)a[jj, j];
                                z = (double)a[jj, i];
                                a[jj, j] = (float)(y * c + z * s);
                                a[jj, i] = (float)(z * c - y * s);
                            }
                        }
                        rv1[l] = 0.0;
                        rv1[k] = f;
                        w[k] = (float)x;
                    }
                }
                
               
                return (1);
           
        }

//##############    END END END  SVD SVD SVD SVD SVD ##################

//############ CREAT MATRIX A  METHOD  ###########
 public void CreatMatrx(double[,] MCOOR, int[,] IPOINT,double [,] A) //   leftMC => Matrix for 3d coordinates 
    {   
     //   LeftIP =>Left  Image points Matrix 
        int ri = 0; 
    for (int r=0 ; r<16 ; r++)
    {
               
           switch (r%2) 
              {
               case 0:
                       A[r, 0] = -MCOOR[ri, 0];
                       A[r, 1] = -MCOOR[ri, 1];
                       A[r, 2] = -MCOOR[ri, 2]; 
                       A[r,3]=-1;
                    
                       break ; 
                       
              default :
                    
                       A[r, 4] = -MCOOR[ri, 0];
                       A[r, 5] = -MCOOR[ri, 1];
                       A[r, 6] = -MCOOR[ri, 2];
                       A[r, 7] = -1;
                    
                        break; 

                   } // Switch 
            
                    if (r % 2 == 0 && r!=0 ) ri += 1; 
              } // for loop 
                 ri = 0; 
             for (int r = 0; r < 16; r++)
                 {
                     switch (r % 2)
                     {
                         case 0:
                             A[r, 8] = -MCOOR[ri, 0] * IPOINT[ri, 0];
                             A[r, 9] = -MCOOR[ri, 1] * IPOINT[ri, 0]; ;
                             A[r, 10] = -MCOOR[ri, 2] * IPOINT[ri, 0]; ;
                             break;
                         default:
                             A[r, 8] = -MCOOR[ri, 0] * IPOINT[ri, 1];
                             A[r, 9] = -MCOOR[ri, 1] * IPOINT[ri, 1];
                             A[r, 10] = -MCOOR[ri, 2] * IPOINT[ri, 1];
                             break;
                     } 
                       if(r%2==0)  
                           A[r, 11] = IPOINT[ri, 0];
                           else 
                           A[r, 11] =IPOINT[ri, 1];
                       if (r % 2 == 0 && r != 0) ri++; 
                 } 

            for(int r=0 ; r<16 ; r++){
                for (int c = 0; c < 12; c++)
                {
                    Console.Write("{0}     ", A[r, c]);
                }
             Console.WriteLine(); 
              }
           
            
            }

 //############## MAKE MATRIX END HERE 

 public Form1()
        {
            InitializeComponent();
        }

//########################   LOAD LOAD LOAD ##########################
 private void Form1_Load(object sender, EventArgs e)
       {
            string filename = "Threepoints.dat"; 
            loadfile(filename,8,3,THREDPOINTS);
            filename ="Fundamental.dat"; 
            loadfile(filename, 3, 3,Fmatrix);
            RightImage = (Bitmap)pictureBox2Rightimg.Image;
            Leftimage = (Bitmap)pictureBox1LeftImge.Image;
           

         
        }
//#################   LOADFILE INTO MATRIX METHOD            ######################       
 public void loadfile(string filename, int row, int column, double[,] PointsD)
        {
            string filthree = File.ReadAllText(filename);
            string[] integerString = filthree.Split(new char[] { ' ', '\t', '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries);
            double[] PointsFile = new double[integerString.Length];// pointsFile matrix contains 3 points
            Console.WriteLine("   LOADED MATRIX :{0} ", filename);  
            for (int i = 0; i < integerString.Length; i++)
            {
                PointsFile[i] = double.Parse(integerString[i]);
            }
            int PointIndex = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    PointsD[i, j] = PointsFile[PointIndex];
                    PointIndex++;
                    Console.Write(" {0} ", PointsD[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("____________________________________________________  ");  
        }

//################# CLOSE    CLOSE ######################  CLOSE ##########
        private void button1_Close_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
//################ LOAD ## LOAD ## LOAD ## LOAD ###########################
       
//###################  CLICK ON LEFT IMAGE ################
  private void pictureBox1LeftImge_MouseDown(object sender, MouseEventArgs e)
        {
            
            
            Graphics g = pictureBox1LeftImge.CreateGraphics();
             int X1=e.X ,Y1=e.Y ;
             this.textBox1XL.Text = X1.ToString();
             this.textBox1YL.Text = Y1.ToString(); 
             g.DrawRectangle(Pens.Yellow, X1, Y1, 2, 2); 
      //    if (rl == 0) EPIFAGE = false;
            switch (EPIFAGE)
            {
          case false:
                if (rl < 8)
                 {
                 LeftPoints[rl, 0] = e.X;
                 LeftPoints[rl, 1] = e.Y;
                 g.DrawRectangle(Pens.Yellow, e.X, e.Y, 1, 1);
                 rl++;
                 }
                     else
                      if (rl == 8) MessageBox.Show("YOU HAVE { 8 } POINTS" );
                         break;
                default:
                         MessageBox.Show("HAVE YOU DONE CALIBRATION MATRIX ");
                         EPIPOLAR(X1, Y1); 
                       break;
                          
            }
            g.Dispose(); 

        }
  //###################### RIGHT IMAGE POINTS START HERE    ######################
 private void pictureBox2Rightimg_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox2Rightimg.CreateGraphics();
            
                    if (rr < 8)
                    {
                        RightPoints[rr, 0] = e.X;
                        RightPoints[rr, 1] = e.Y;

                        g.DrawRectangle(Pens.Yellow, e.X, e.Y, 1, 1);
                        rr++;
                    }
                    else
                        if (rr == 8) MessageBox.Show("YOU HAVE { 8 } POINTS");

                    this.textBox1Right.Text = e.X.ToString();
                    this.textBox2Right.Text = e.Y.ToString(); 

            g.Dispose(); 
        }
//###################  CREAT M1 ########### CREAT M1 ############### 
    private void button1M1_Click(object sender, EventArgs e)
        {
                 
            CreatMatrx(PointsD, LeftPoints,A);   // A (16 x 12) 
            dsvd(A, 16, 12, w, v);
            CalibrationMatrix(M1);   
              
         
        }

 private void button1M2_Click(object sender, EventArgs e)
        {


            CreatMatrx(PointsD, RightPoints, A);  // A (16 x 12)
            dsvd(A, 16, 12, w, v);
            CalibrationMatrix(M2); 
           
            
           
        }
//################### CREAT CALIBRATION MATRIX  ###########  
 
//###################  LOAD M1 #########################

 private void button1LDM1_Click(object sender, EventArgs e)
 {
       string filename="MF1.txt";  
       loadfile(filename, 3, 4, M1);
       filename = "MF2.txt";
       loadfile(filename, 3, 4, M2);


 }
//################### END  LOAD M1 #########################



 public void CalibrationMatrix(double[,] CALM)
      {
          int i = 0,row=3,col=4;
          for (int r = 0; r < row; r++)
          {
              for (int c = 0; c < col; c++)
              {
                  CALM[r, c] = v[11, i]; i++;
          //        Console.Write("{0} ", CALM[r, c]);
              }
              Console.WriteLine();

          }
      }
  //################                                  ##########################
  //############### SAVE M1 CALIBRATION MATRIX BUTTON ##########################
        private void button1SaveM1_Click(object sender, EventArgs e)
        {
         string Mstring ="M1.txt";
         savefile(M1, Mstring); 

        }
 //######################## SAVE M2 CALIBRATION MATRIX BUTTON ################
        private void button1SaveM2_Click(object sender, EventArgs e)
        {
            string Mstring = "M2.txt";
            savefile(M2, Mstring); 
        }

  //######################## SAVE FILES M1 and M2 MATRICES IN  FILES #########
        public void savefile(double[,] M1, string MF)
        {

            Console.WriteLine(" THE FILE HAS SAVED {0} ",MF);

            StreamWriter sr = new StreamWriter(MF );

            for (int r = 0; r < 3; r++)
            {

                for (int c = 0; c < 4; c++)
                {
                    
                    sr.Write(M1[r, c]+"   " );

                }
                sr.WriteLine();
            }
            sr.Close();

        }

        private void button1Epipolar_Click(object sender, EventArgs e)
        {
            EPIFAGE = true;
            this.pictureBox1LeftImge.Refresh(); 
        }
//########## EPIPOLAR LINES  ###########################################
        public void EPIPOLAR(int x,int y )
        {   
             int Wsize=11 ,Start=Wsize/2, Xmatch=0 ,vx,    Ymatch=0 ,
             EndR=RightImage.Height-(Wsize/2),
             EndC=RightImage.Width-(Wsize/2);
             Console.WriteLine("Hieght {0} ", EndR);
             Console.WriteLine("Width  {0} ", EndC);
             double A1, B1, C1, X2, Y2, ZNCEP = 0.0, ZNCC0 = 0.0; int  Y1; 
             double [,] window1=new double [Wsize ,Wsize ],
                        EPwindow=new double [Wsize ,Wsize ];

             vx =((x-100>0)?x-100:Math.Abs (x-20));  //-30); 

             this.textBox1Right.Text = x.ToString();
             this.textBox2Right.Text = y.ToString(); 

            Graphics g = pictureBox2Rightimg.CreateGraphics();
             
            Pen point=new Pen (Color.Yellow ) ; 
           // X1 = Start; 
            //X2 = EndR ;
            A1 = Fmatrix[0, 0] * x + Fmatrix[0, 1] * y + Fmatrix[0, 2] * 1;
            B1 = Fmatrix[1, 0] * x + Fmatrix[1, 1] * y + Fmatrix[1, 2] * 1;
            C1 = Fmatrix[2, 0] * x + Fmatrix[2, 1] * y + Fmatrix[2, 2] * 1;
           // Console.WriteLine(" A={0} B={1}  C={2}", A1, B1, C1);  
            X2 = EndC;    //(vx + 101<EndC )?vx+101:vx+50; 
            Y1 =(int)( ((-A1 * vx  - C1)) / B1);
           
            Y2 = ((-A1 * X2 - C1)) / B1;
            g.DrawLine(Pens.Blue ,(float) vx   , (float)Y1, (float)X2 , (float)Y2);
           // g.DrawRectangle(Pens.Yellow, vx, Y1, 4, 4);


            makewindow1(window1, x, y,Wsize );
            epipolarwindow(EPwindow, vx, (int)Y1, Wsize);
            double epzncc; 
            epzncc = ZNCC(window1, EPwindow, Wsize);
            if (epzncc > ZNCC0) ZNCC0 = epzncc;
 
            if(epzncc<0.70) 
            {
                for (int x0 = x - 15; x0 < x+80; x0++)   //x0 < EndC  ,x + 80
                {
                    Y1 =(int) (((-A1 * x0) / B1) - (C1 / B1));
                    if (Y1 < Start || Y1 > EndC) continue;
                    if (x0 >= Start && x0 <= EndC)
                    {
                        epipolarwindow(EPwindow, x0, (int)Y1, Wsize);
                        ZNCEP = ZNCC(window1, EPwindow, Wsize);
                        if (ZNCEP > ZNCC0)
                        {
                            ZNCC0 = ZNCEP;
                            Xmatch = x0;
                            Ymatch = (int)Y1;
                            g.FillEllipse(Brushes.Yellow , Xmatch, Ymatch, 2, 2); 
                          
                        }
                    }
                }
             
            }
            g.DrawRectangle(Pens.Blue  , Xmatch, Ymatch, 5, 5);
         
            this.textBox1ZNCC.Text = ZNCC0.ToString();
            this.textBox1Right.Text = Xmatch.ToString();
            this.textBox2Right.Text = Ymatch.ToString(); 
            string filename = "MF1.txt";
            loadfile(filename, 3, 4, M1);
            filename = "MF2.txt";
            loadfile(filename, 3, 4, M2);
            CONSTRUCTOR_D3(x, y, Xmatch, Ymatch,M1 ,M2 );    // Calling construction 


        }
        //#####################    3 D CONSTRUCTION   #############

        public void CONSTRUCTOR_D3(int x, int y ,int u ,int v ,double [,]M1 ,double [,]M2)
        {
            Console.WriteLine(" THIS IS THE 3D MATRIX x:{0} :y:{1}: u:{2} :v:{3} ",x,y,u,v); 
            double[,] AD3 = new double[4, 4];
            double[,] B = new double[4,3];

            AD3[0, 0] = x * M1[2, 0] - M1[0, 0];
            AD3[0, 1] = x * M1[2, 1] - M1[0, 1];
            AD3[0, 2] = x * M1[2, 2] - M1[0, 2];
            AD3[0, 3] = -x * M1[2, 3] + M1[0, 3];

            AD3[1, 0] = y * M1[2, 0] - M1[1, 0];
            AD3[1, 1] = y * M1[2, 1] - M1[1, 1];
            AD3[1, 2] = y * M1[2, 2] - M1[1, 2];
            AD3[1, 3] = -y * M1[2, 3] + M1[1, 3];

            AD3[2, 0] = u * M2[2, 0] - M2[0, 0];
            AD3[2, 1] = u * M2[2, 1] - M2[0, 1];
            AD3[2, 2] = u * M2[2, 2] - M2[0, 2];
            AD3[2, 3] = -u * M2[2, 3] + M2[0, 3];

            AD3[3, 0] = v * M2[2, 0] - M2[1, 0];
            AD3[3, 1] = v * M2[2, 1] - M2[1, 1];
            AD3[3, 2] = v * M2[2, 2] - M2[1, 2];
            AD3[3, 3] = -v * M2[2, 3] + M2[1, 3];


                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                     /*   AD3[0, i] = x * M1[2, i] - M1[0, i];
                        AD3[1, i] = y * M1[2, i] - M1[1, i];

                        AD3[2, i] = u * M2[2, i] - M2[0, i];
                        AD3[3, i] = v * M2[2, i] - M2[1, i];*/
                        Console.Write("{0} ", AD3[i, j]);
                    }
                    Console.WriteLine(); 
                }
            
               
                
                   double[,] v1 = new double[4, 4]; 
                  
                  
                   double[] w1 = new double[4];
            //#######  CALLING DSVD ##############
           Console.WriteLine("____________________________________________________"); 
                dsvd(AD3, 4, 4, w1, v1);
           Console.WriteLine(" THIS IS (   X  Y  Z   1 ) SOLUTION  ");
                for (int i = 0; i <= 3; i++)
                {    
                    for (int j =0 ; j<4; j++) 
                   
                       Console.Write(" {0}  ",-1*(v1 [i, j]/v1[3,3]));
                   
                    Console.WriteLine();
                }

                Console.WriteLine("____________________________________________________");
                double  XD=-1 * v1[0, 3]/v1[3, 3];
                double YD = -1 * v1[1, 3] / v1[3, 3];
                double ZD = -1 * v1[2, 3] / v1[3, 3]; 
                this.textBox1XD3.Text = XD.ToString();
                this.textBox1YD3.Text = YD.ToString();
                this.textBox1ZD3.Text = ZD.ToString(); 

        }


        //################### MAKE WINDOW ONE IN LEFT IMAGE ##################

        public void makewindow1(double[,] window1, int V, int C ,int w1)
        {
            //int w1 = 9;
           
            int lx = V - (w1 / 2);
            int ly = C - (w1 / 2);
            for (int i = 0; i < w1; i++)
            {
                lx = V - 4;
                for (int j = 0; j < w1; j++)
                {
                    window1[i, j] =Leftimage.GetPixel(lx, ly).R;
                   
                    lx++;
                }
              
                ly++;
            }
        }
        //##################### MAKE EPIPOLAR RIGHT  WINDOWS 
        //##################### MAKE EPIPOLAR RIGHT  WINDOWS 

        public void epipolarwindow(double[,] epwindow, int x0, int y0,int we)
        {
           

            int epx = Math.Abs ((int)(x0 - (int)((we / 2))));
            int epy = Math.Abs((int)(y0 - (int)((we / 2)))); 
            
            
            for (int i = 0; i < we && i<RightImage.Height-(we/2); i++)
            
            {
                epx = (int)(x0 - (int)(we / 2));

                for (int j = 0; j < we && j<RightImage.Width-(we/2) ; j++)
                {
                    if (epy > RightImage.Height-(we/2)|| epy<(we/2) ) continue;
                    if (epx > RightImage.Width - (we / 2) || epx < (we / 2)) continue; 
                    epwindow[i, j] = RightImage.GetPixel(epx, epy).R;
                   
                    epx++;
                }
                Console.WriteLine();
                epy++;
            }
        }
        //########################## END EPIPOLAR WINDOW FOR RIGHT IMAGE     

        //#################   MEAN METHODS    MEAN METHODS   ################## 

        public double WindowsMean(double[,] W, int wsize)
        {

            double Mean = 0;
            for (int r = 0; r < wsize; r++)
                for (int c = 0; c < wsize; c++)
                    Mean += W[r, c];
            return Mean / (wsize * wsize);

        }

        // ###############  ZNCC  METHODS  HERE  ############### 
        public double ZNCC(double[,] LW, double[,] RW, int widthw)
        {
            double Numerator = 0, LWDenominator = 0, RWDenominator = 0,

                RWMean = WindowsMean(RW, widthw),
                LWMean = WindowsMean(LW, widthw);// LWMean = Mr, 
           
            for (int i = 0; i < widthw; i++)
                for (int j = 0; j < widthw; j++)
                {
                    Numerator += (RW[i, j] - RWMean) * (LW[i, j] - LWMean);
                    LWDenominator += (LW[i, j] - LWMean) * (LW[i, j] - LWMean);
                    RWDenominator += (RW[i, j] - RWMean) * (RW[i, j] - RWMean);

                }
            if ((System.Math.Sqrt(LWDenominator * RWDenominator) < 1e-10)) return 0;
            else return Numerator / System.Math.Sqrt(LWDenominator * RWDenominator);

        }
 //######################## END OF ZNCC ###############################

       
  


    }
}
