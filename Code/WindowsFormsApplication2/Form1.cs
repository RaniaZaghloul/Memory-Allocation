using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rania
{
    public partial class Form1 : Form
    {
        private List<string> name_before = new List<string>();
        private List<string> name_after = new List<string>();
        private List<int> Start_H = new List<int>();
        private List<int> Start_P = new List<int>();
        private List<int> ending = new List<int>();
        private List<int> size_P = new List<int>();
        private List<int> size_H = new List<int>();
        private List<int> size_HNew = new List<int>();
        private List<int> size_after = new List<int>();
        private int current = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void getInput()
        {
            name_before.Add(textBox2.Text);
            size_H.Clear();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.SelectAll();
                int startingAddr = Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
             //   MessageBox.Show(startingAddr.ToString());
                int Holesize = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                Start_H.Add(startingAddr);
                size_H.Add(Holesize);

            }

            size_P.Add(Int32.Parse(textBox3.Text));

        }
        private void allocate()
        {
            
            int count = 0;
            switch (comboBox1.Text)
            {
                
                case "First Fit":
                    int p = 0;
                    for (int i = 0; i < size_H.Count; i++)
                    {
                        p = Int32.Parse(textBox3.Text);
                      //  MessageBox.Show(size_H[i].ToString());
                      //  MessageBox.Show(p.ToString());

                        if (size_H[i] >= p)
                        {
                            count = i;
                            MessageBox.Show(count.ToString());
                            break;
                        }


                    }
                    Start_P.Add(Start_H[count]);
                    // name_after.Add(name_before[i]);
                    size_after.Add(p);
                    if (size_H[count] - p == 0)
                    {
                        break;
                    }
                    else
                    {
                        Start_H.Insert(count, Start_H[count] + p + 1);
                        size_HNew.Add(size_H[count] - p);
                        List<int> temp = new List<int>();
                        int[] tempArray = new int[size_H.Count];
                        size_H.CopyTo(tempArray);
                        temp = tempArray.ToList();
                        temp.RemoveAt(count);
                        size_HNew.AddRange(temp);
                    
                        size_HNew.CopyTo(tempArray);
                        size_H = tempArray.ToList();

                    }
                    size_P.Add(p);

                    break;
                #region
                case "Best Fit":
                    
                    p = Int32.Parse(textBox3.Text);
                    for (int i = 0; i <= size_H.Count; i++)
                    {
                        if (size_H[i] >= p)
                        {
                            if (current == 0)
                            {
                                current = i;

                            }
                            else
                            {
                                if (size_H[i] < size_H[current])
                                {
                                    current = i;
                                    MessageBox.Show(current.ToString());
                                    break;
                                }
                            }

                        }

                    }
                    Start_P.Add(Start_H[count]);
                    // name_after.Add(name_before[i]);
                    size_after.Add(p);
                    if (size_H[count] - p == 0)
                    {
                        break;
                    }
                    else
                    {
                        Start_H.Insert(count, Start_H[count] + p + 1);
                        size_HNew.Add(size_H[count] - p);
                        List<int> temp = new List<int>();
                        int[] tempArray = new int[size_H.Count];
                        size_H.CopyTo(tempArray);
                        temp = tempArray.ToList();
                        temp.RemoveAt(count);
                        size_HNew.AddRange(temp);

                        size_HNew.CopyTo(tempArray);
                        size_H = tempArray.ToList();

                    }
                    size_P.Add(p);

                    break;
                #endregion

                case "Worst Fit":
                    p = Int32.Parse(textBox3.Text);
                    int counter = 0;
                    for (int i = 0; i <= size_H.Count; i++)
                    {                      
                        if (size_H[i] >= p)
                        {
                            counter++;
                            if (current == 0)
                            {
                                current = i;
                            }
                            else
                            {
                                if (size_H[i] > size_H[current])
                                {
                                    current = i;
                                }
                            }
                            break;
                        }

                        
                    }
                    break;
        



        }

        private void output()
        {
            switch (comboBox1.Text)
            {
                case "First Fit":

                    break;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // check that all input is taken
            getInput();
            allocate();
            output();
        }

        #region junk
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
