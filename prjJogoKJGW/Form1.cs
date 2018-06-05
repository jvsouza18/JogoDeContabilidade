using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;



namespace prjJogoKJGW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public uint pontos;
        public bool status = false;
        public string compara1;
        public string compara2;
        List<PictureBox> lstCartas = new List<PictureBox>();
        string curDir;
        public string[] arquivos;
        List<System.Drawing.Image> lst_img_cartas = new List<System.Drawing.Image>();
        ListBox list = new ListBox();

        public void validacao(PictureBox b2)
        {
            if (!status)
            {
                status = true;
                timer.Stop();
                timer1.Stop(); 
                timerAtivo.Stop();
                timerPassivo.Stop();
                b2.Enabled = false;
                virar();
                b2.BackgroundImage = Image.FromFile(b2.Tag.ToString());
                string aux = b2.Tag.ToString();
                string[] tokens = aux.Split('#');
                compara1 = tokens[1];




            }
            else
            {
                
                b2.Enabled = false;
                b2.BackgroundImage = Image.FromFile(b2.Tag.ToString());
                string aux = b2.Tag.ToString();
                string[] tokens = aux.Split('#');
                compara2 = tokens[1];
             
                string a = lblAtivoPassivo.Tag.ToString();
                string a0 = compara1[0].ToString();
                string a1 = compara1[1].ToString();
                string a2 = compara1[2].ToString();
                string c0 = compara2[0].ToString();
                string c1 = compara2[1].ToString();
                string c2 = compara2[2].ToString();

                if (a0 == a && c0 == a)
                {
                    if (a1 == c2 || c1 == a2)
                    {
                        AumentarPontos();
                        MessageBox.Show("acertou");

                    }
                    else
                    {
                        MessageBox.Show("errou");
                    }
                }
                else
                {
                    MessageBox.Show("nem chegou perto");
                }
                timer.Start();
                timer1.Start();
                timerAtivo.Start();
                timerPassivo.Start();
                for (int i = 0; i < lstCartas.Count; i++)
                {

                    if (lstCartas[i].Enabled == false)
                    {
                        lstCartas[i].Enabled = true;

                    }

                }
                status = false;
                random();





            }

        }

        public void AumentarPontos()
        {
            pontos = pontos + 100;
            lblPontos.Text = pontos.ToString();

        }
       

        public void LabelAtivo()
        {
            curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            lblAtivoPassivo.BackgroundImage = Image.FromFile(curDir + "\\ATIVO.png");
        }
        public void LabelPassivo()
        {
            curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            lblAtivoPassivo.BackgroundImage = Image.FromFile(curDir + "\\passivo.png");
        }





        public void virar()
        {
            for (int i = 0; i < lstCartas.Count; i++)
            {
                curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
                curDir = curDir + "//fundo_yugioh.jpg";
                if(lstCartas[i].Enabled != false)
                {
                    lstCartas[i].BackgroundImage = Image.FromFile(curDir);

                }
                
            }
            

        }


        public void random()
        {
       
            System.Drawing.Bitmap bitmap = null;
            int width = 0;
            int height = 0;

            for (int i = 0; i < lstCartas.Count(); i++)
            {
                list.Items.Add(arquivos[i]);
            }
            
 
            Random rng = new Random();
            int n = list.Items.Count;

            while (n > 1)
            {
                
                n--;
                int k = rng.Next(n + 1);
                string value = (string)list.Items[k];
                list.Items[k] = list.Items[n];
                list.Items[n] = value;


                


            }


          







            foreach (string image in list.Items)
            {
                bitmap = new System.Drawing.Bitmap(image);
                //atualiza o tamanho da imagem bitmap final
                width += bitmap.Width;
                height = bitmap.Height > height ? bitmap.Height : height;

                try
                {
                    Image Imagem = Image.FromFile(image);
                    lst_img_cartas.Add(Imagem);
                    

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                    "Mensagem : " + ex.Message + "\n\n" +
                                    "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não é possível exibir a imagem : " + image.Substring(image.LastIndexOf('\\'))
                                     + ". Você pode não ter permissão para ler o arquivo , ou " +
                                     " ele pode estar corrompido.\n\nErro reportado : " + ex.Message);
                }
           
         
                
           

            }
            for (int i = 0; i < lstCartas.Count(); i++)
            {
                if (lstCartas[i].Enabled != false)
                {
                    lstCartas[i].BackgroundImage = lst_img_cartas[i];
                    lstCartas[i].Tag = (string)list.Items[i]; 
                    

                }
              
                arquivos[i] = (string)list.Items[i];



            }
            lst_img_cartas.Clear();
            list.Items.Clear();
           

        }

   

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 10000;


            // Enable timer.
            timer.Enabled = true;
            random();
            label3.Text = "rand";





        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            lstCartas.Add(b1);
            lstCartas.Add(b2);
            lstCartas.Add(b3);
            lstCartas.Add(b4);
            lstCartas.Add(b5);
            lstCartas.Add(b6);
            lstCartas.Add(b7);
            lstCartas.Add(b8);
            lstCartas.Add(b9);
            lstCartas.Add(b10);
            lstCartas.Add(b11);
            lstCartas.Add(b12);
            lstCartas.Add(b13);
            lstCartas.Add(b14);
            lstCartas.Add(b15);
            lstCartas.Add(b16);
            lstCartas.Add(b17);
            lstCartas.Add(b18);
            lstCartas.Add(b19);
            lstCartas.Add(b20);
            lstCartas.Add(b21);
            lstCartas.Add(b22);
            lstCartas.Add(b23);
            lstCartas.Add(b24);
            curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

            arquivos = Directory.GetFiles(curDir + "//images");







        }

     

        private void b1_Click_1(object sender, EventArgs e)
        {
            //if(!status)
            //{
            //    status = true;
            //    timer.Enabled = false;
            //    timer1.Enabled = false;
            //    b1.Enabled = false;
            //    timerAtivo.Enabled = false;
            //    timerPassivo.Enabled = false;
            //    timesDesvirar.Enabled = false;
            //    virar();
            //    b1.BackgroundImage = Image.FromFile(b1.Tag.ToString());
            //    string aux = b1.Tag.ToString();
            //    string[] tokens = aux.Split('#');
            //    compara1 = tokens[1];
            //    MessageBox.Show(compara1);



            //}
            //else
            //{
            //    virar();
            //    b1.Enabled = false;
            //    b1.BackgroundImage = Image.FromFile(b1.Tag.ToString());
            //    string aux = b1.Tag.ToString();
            //    string[] tokens = aux.Split('#');
            //    compara2 = tokens[1];
            //    MessageBox.Show(compara2);
            //    for (int i = 0; i < 3; i++)
            //    {
            //        MessageBox.Show("i");

            //    }


            //}
            validacao(b1);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 15000;


            // Enable timer.
            timer1.Enabled = true;

            virar();
            label3.Text = "vira";


        }

        private void b2_Click(object sender, EventArgs e)
        {

            validacao(b2);
        }

        private void b12_Click(object sender, EventArgs e)
        {
            validacao(b12);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

     

        private void timerAtivo_Tick(object sender, EventArgs e)
        {
            timerAtivo.Interval = 5000;


            // Enable timer.
            timerAtivo.Enabled = true;
            lblAtivoPassivo.Tag = "a";
            lblt.Text = "a";
            LabelAtivo();
        }

        private void timerPassivo_Tick(object sender, EventArgs e)
        {
            timerPassivo.Interval = 8000;


            // Enable timer.
            lblAtivoPassivo.Tag = "p";
            timerPassivo.Enabled = true;
            lblt.Text = "p";
            LabelPassivo();
        }



        private void b3_Click(object sender, EventArgs e)
        {
            validacao(b3);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            validacao(b4);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            validacao(b5);
        }

        private void b11_Click(object sender, EventArgs e)
        {
            validacao(b11);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            validacao(b6);
        }

        private void b7_Click(object sender, EventArgs e)
        {
            validacao(b7);
        }

        private void b8_Click(object sender, EventArgs e)
        {
            validacao(b8);
        }

        private void b9_Click(object sender, EventArgs e)
        {
            validacao(b9);
        }

        private void b10_Click(object sender, EventArgs e)
        {
            validacao(b10);
        }

        private void b13_Click(object sender, EventArgs e)
        {
            validacao(b13);
        }

        private void b14_Click(object sender, EventArgs e)
        {
            validacao(b14);
        }

        private void b15_Click(object sender, EventArgs e)
        {
            validacao(b15);
        }

        private void b16_Click(object sender, EventArgs e)
        {
            validacao(b16);
        }

        private void b17_Click(object sender, EventArgs e)
        {
            validacao(b17);
        }

        private void b18_Click(object sender, EventArgs e)
        {
            validacao(b18);
        }

        private void b19_Click(object sender, EventArgs e)
        {
            validacao(b19);
        }

        private void b20_Click(object sender, EventArgs e)
        {
            validacao(b20);
        }

        private void b21_Click(object sender, EventArgs e)
        {
            validacao(b21);
        }

        private void b22_Click(object sender, EventArgs e)
        {
            validacao(b22);
        }

        private void b23_Click(object sender, EventArgs e)
        {
            validacao(b23);
        }

        private void b24_Click(object sender, EventArgs e)
        {
            validacao(b24);
        }
    }
}
