using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sametersoyogluOdev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            Stack <char> stack = new Stack<char>();

            char[] ilk = { '(', '{', '[' };
            char[] son = { ')', '}', ']' };
            bool cevap = true;

            char[] oku = txtIfade.Text.ToCharArray();

            if (txtIfade.Text == "")
            {
                MessageBox.Show("Lütfen İfade Giriniz Boş Bırakılamaz","İFADE GİRİNİZ!");
            }
            else
            {
                for (int i = 0; i < oku.Length; i++)
                {
                    if (ilk.Contains(oku[i]))
                    {
                        stack.Push(oku[i]);
                    }
                    else if (son.Contains(oku[i]))
                    {
                        try
                        {
                            char gecici = stack.Pop();
                            for (int j = 0; j < ilk.Length; j++)
                            {
                                if (ilk[j] == gecici)
                                {
                                    if (son[j] != oku[i])
                                    {
                                        cevap = false;
                                        MessageBox.Show("Girilen İfade Dengesizdir. Girmiş Olduğunuz Parantezler Farklıdır.");
                                    }
                                }
                            }
                        }
                        catch
                        {
                            cevap = false;
                            MessageBox.Show("Girilen İfade Gecersizdir. Başlangıç Sembolü Bulunmalıdır!");

                        }
                    }
                }

                if (stack.Count != 0)
                {
                    cevap = false;
                    MessageBox.Show("Girilen İfade Gecersizdir. Parantez Kapatılmalıdır.");
                }
                else
                {
                    if (cevap == true)
                    {
                        MessageBox.Show("Girmiş Olduğunuz İfade Dengelidir.", "GEÇERLİ KULLANIM");
                    }
                }
            }
        }

    }
}
