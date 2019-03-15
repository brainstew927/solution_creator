using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sol_creator
{
    public partial class Form1 : Form
    {
        String string_sol;

        public string[] split_prob(string problemi)
        {

            List<string> prob = new List<string>();

            string[] temp;

            temp = problemi.Split(',');


            prob.AddRange(temp);


            return prob.ToArray();

        }


        public string[] split_punt(string[] lett, int sel)
        {

            List<string> punt = new List<string>();

            string temp;

            foreach (string linea in lett)
            {
                temp = linea.Split(':')[sel];

                punt.Add(temp);
            }

            return punt.ToArray();

        }

        public string[] read()
        {

            string text = System.IO.File.ReadAllText(@"soluzioni.txt");
      
            string[] lines = System.IO.File.ReadAllLines(@"soluzioni.txt");


            return lines;
               
             
        }
        


        public Form1()
        {
            InitializeComponent();

            string[] array_str = read();


            string[] punt;
            string[] temp;

            string[][] prob = new string[array_str.Length][];

            int punt_cont = 0;

            punt = split_punt(array_str, 0);
            temp = split_punt(array_str, 1);

            for (int i =0; i < array_str.Length; i++)
            {
               // temp = split_punt(array_str[i], 1);
               

                prob[i] = split_prob(temp[i]);
             
            }


            foreach(string pt in punt)
            {
                textBox1.AppendText(pt);
                textBox1.AppendText("\n");

                foreach(string sol in prob[punt_cont])
                {
                    textBox1.AppendText("      " + sol);
                    textBox1.AppendText("\n");
                }


                punt_cont++;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text_in = input.Text;

            textBox1.AppendText(text_in);
            
        }
    }
}
