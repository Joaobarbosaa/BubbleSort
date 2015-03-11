using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List list;
        string[] array;

        int[] bubble;

        public Form1()
        {
            InitializeComponent();
            list = new List(2, 3, 4, 1);
            array = new string[10] { "13", "2", "5", "8", "23", "90", "41", "4", "77", "61" };

            bubble = new int[11] { 13, 2, 5, 8, 23, 90, 41, 4, 77, 61, 95 };

            listBox1.Items.AddRange(list.ToArray());
            listBox2.Items.AddRange(array);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            int value = 0;
            if (int.TryParse(textBox1.Text, out value))
            {
                if (checkBox1.Checked)
                {
                    index = listBox1.SelectedIndex;
                    if (radioButton3.Checked && int.TryParse(textBox2.Text, out index))
                    {
                        index--;
                        if (index >= list.Count)
                        {
                            list.Add(value);
                        }
                        else
                        {
                            Element indexSelected = list.Get(index);
                            Element previousIndexSelected = list.Get(index - 1);
                            Element current = new Element(value, previousIndexSelected, indexSelected);
                            indexSelected.Previous = current;
                            if (previousIndexSelected != null)
                            {
                                previousIndexSelected.Next = current;
                            }
                            else
                            {
                                list.SetFirst(current);
                            }
                        }
                    }
                    if (radioButton1.Checked && index >= 0)
                    {
                        Element indexSelected = list.Get(index);
                        Element previousIndexSelected = list.Get(index - 1);
                        Element current = new Element(value, previousIndexSelected, indexSelected);
                        indexSelected.Previous = current;
                        if (previousIndexSelected != null)
                        {
                            previousIndexSelected.Next = current;
                        }
                        else
                        {
                            list.SetFirst(current);
                        }
                    }

                    if (radioButton2.Checked && index >= 0)
                    {
                        Element indexSelected = list.Get(index);
                        Element current = new Element(value, indexSelected, indexSelected.Next);
                        indexSelected.Next = current;
                    }

                    if (index < 0)
                    {
                        MessageBox.Show("Selected any item");
                    }
                }
                else
                {
                    list.Add(value);
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                radioButton1.Visible = radioButton2.Visible = textBox2.Visible = radioButton3.Visible = true;
            }
            else
            {
                radioButton1.Visible = radioButton2.Visible = textBox2.Visible = radioButton3.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bubble.Length - 1; i++)
            {
                for (int j = i + 1; j < bubble.Length; j++)
                {
                    if (bubble[i] > bubble[j])
                    {
                        int temp = bubble[i];
                        bubble[i] = bubble[j];
                        bubble[j] = temp;
                        label1.Text = "Result in Console";
                    }
                }
                Console.Write(bubble[i] + " ");
            }
        }
    }
}
