using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Determinant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private System.Windows.Forms.TextBox txtBox;
        private int Det(int[,] mat0, int i, int n)
        {
            if (n!=2)
            {
                int[,] mat1 = new int[n - 1, n - 1];
                for (int j = 0; j < n; j++)
                {
                    int ni=0, mj;
                    for (int ix = i+1; ix < n; ix++)
                    {
                        mj = 0;
                        for (int jy = 0; jy < n; jy++)
                        {
                            if (jy!=j)
                            {
                                mat1[ni, mj] = mat0[ix, jy];
                                mj++;
                            }
                        }
                        ni++;
                    }
                        return (-1) ^ (i + j) * mat0[i, j] * Det(mat1, i + 1, n-1);
                }
            }
            else
            {
                return mat0[0,0]*mat0[1,1]-mat0[0,1]*mat0[1,0];
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random r=new Random();
            int n=Convert.ToInt16(textBox1.Text);
            int[,] matris = new int[n,n];
            string txtbox;
            for (int i = 0; i <n; i++)
			{
                for (int j = 0; j < n; j++)
			    {
                    txtbox="A"+i+j;
                    matris[i,j]= r.Next(0, 10);
                    this.txtBox = new System.Windows.Forms.TextBox();
                    this.txtBox.Location = new System.Drawing.Point(i*20+12, j*20+38);
                    this.txtBox.Name = "A" + i+j;
                    this.txtBox.Size = new System.Drawing.Size(20, 20);
                    this.txtBox.TabIndex = 3;
                    this.txtBox.Text =Convert.ToString(matris[i,j]);
                    this.txtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    this.Controls.Add(this.txtBox);
			    }
			}
            label1.Text=Convert.ToString(Det(matris,0,n));
        }

    }
}
