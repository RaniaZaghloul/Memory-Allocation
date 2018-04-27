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
        private List<int> ending_H = new List<int>();
        private List<int> ending_P = new List<int>();
        private List<int> size_P = new List<int>();
        private List<Int32> size_H = new List<int>();
        private List<int> size_HNew = new List<int>();
        private List<int> size_after = new List<int>();
        private List<string> listGV = new List<string>();
        private List<string> EndGV = new List<string>();
        private List<string> ProcessGV = new List<string>();
        private List<string> SizeGV = new List<string>();
        private DataTable dt = new DataTable();


        #region UI
        private int programCounter = 0;
        private void getNextProcess()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Enter the name and the size of the next process");
        }
        private void allocate()
        {
            // for (int Programe = 0; Programe <= Int32.Parse(textBox2.Text); Programe++)
            //{

            int count = 0;

            switch (comboBox1.Text)
            {

                case "First Fit":
                    p = 0;
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
                    ending_P.Add(Start_H[count] + p);
                    size_P.Add(p);

                    if (size_H[count] - p == 0)
                    {
                        Start_H.RemoveAt(count);
                        ending_H.RemoveAt(count);
                        break;

                    }
                    else
                    {

                        Start_H[count] = Start_H[count] + p + 1;

                        size_H[count] = size_H[count] - p;

                    }

                    break;
                #region
                case "Best Fit":

                    p = Int32.Parse(textBox3.Text);
                    current = 0;
                    for (int i = 0; i < size_H.Count; i++)
                    {
                        if (size_H[i] >= p && size_H[i]< size_H[current])
                        {
                            current = i;

                        }

                    }
                    MessageBox.Show(current.ToString());
                    Start_P.Add(Start_H[current]);
                    // name_after.Add(name_before[i]);
                    size_after.Add(p);
                    ending_P.Add(Start_H[current] + p);
                    if (size_H[current] - p == 0)
                    {
                        ending_H.RemoveAt(current);
                        Start_H.RemoveAt(current);
                       // break;
                    }
                    else
                    {
                        Start_H[current] = Start_H[current] + p + 1;
                      //  ending_P.Add(Start_H[current] + p);
                        size_H[current] = size_H[current] - p;
                    }
                    size_P.Add(p);

                    break;
                #endregion
                #region
                case "Worst Fit":

                    p = Int32.Parse(textBox3.Text);
                    current = 0;
                    for (int i = 0; i < size_H.Count; i++)
                    {
                        if (size_H[i] >= p && size_H[i] > size_H[current])
                        {
                            current = i;

                        }

                    }
                    MessageBox.Show(current.ToString());
                    Start_P.Add(Start_H[current]);
                    // name_after.Add(name_before[i]);
                    size_after.Add(p);
                    ending_P.Add(Start_H[current] + p);
                    if (size_H[current] - p == 0)
                    {
                        ending_H.RemoveAt(current);
                        Start_H.RemoveAt(current);
                        // break;
                    }
                    else
                    {
                        Start_H[current] = Start_H[current] + p + 1;
                        //  ending_P.Add(Start_H[current] + p);
                        size_H[current] = size_H[current] - p;
                    }
                    size_P.Add(p);

                    break;
                    #endregion

            }
            if (programCounter < Int32.Parse(textBox1.Text) - 1)
            {
                programCounter++;
                getNextProcess();
            }

        }

        #endregion
        #region backend

        #endregion

        private Int32 p = 0;
        private int current = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Checks()
        {
            bool j=false;
            for (int i = 0; i < size_H.Count; i++)
            {
                if (Int32.Parse(textBox3.Text) <= size_H[i])
                {
                    j = true;
                    break;
                 //   getInput();
                }
            }
            if (j == true)
            {
                MessageBox.Show("This Process is Unvalid");
            }
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || comboBox1.Text == null)
            {
                MessageBox.Show("Data Missing, Please Fill all Required Data");
            }
            if (size_H.Count == Start_H.Count)
            {
                bool emptyFields = false;

                //5ally el row elly byetdaf el gdeed da yt4al
                //if we have an empty cell don't continue
                //dataGridView1.SelectAll();
                //foreach (DataGridViewCell c in dataGridView1.SelectedCells)
                //{
                //    if (c.Visible == true)
                //    {
                //        if (c.Value == null)
                //        {
                //            emptyFields = true;
                //            break;
                //        }
                //        else
                //        {
                //            //c.Value = counter;
                //            //counter++;
                //        }
                //    }
                //}
                if (dataGridView1.RowCount == 0)
                    MessageBox.Show("Please Enter Holes.");

                if (emptyFields)
                    MessageBox.Show("You Should Fill All The Information To Continue");
            }
            else
            {
                MessageBox.Show("Data Missing, Please Fill all Required Data");
            }

        }

        private void getInput()
        {
            size_H.Clear();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.SelectAll();
                int startingAddr = Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                //   MessageBox.Show(startingAddr.ToString());
                int Holesize = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                Start_H.Add(startingAddr);
                size_H.Add(Holesize);
                ending_H.Add(Start_H[i] + size_H[i]);

            }
        }

        private void Deallocate()
        {
            string p = textBox2.Text;
            int pp = 0;
            bool found = false;
            //get the index of the specified process in the grid
            for (int i = 0; i < name_before.Count; i++)
            {
                if (p == name_before[i])
                {
                    pp = i;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show("This Process dosn't Exist");
            }

            //merge new hole with existing holes
            for (int i = 0; i < Start_H.Count; i++)
            {
                if (ending_H[i] == Start_P[pp] - 1)
                {
                    ending_H[i]= ending_P[pp];
                }
                if (Start_H[i] == ending_P[pp] + 1)
                {
                    Start_H[i]= Start_P[pp];
                }
            }

            name_before.RemoveAt(pp);
            size_P.RemoveAt(pp);
            Start_P.RemoveAt(pp);
            ending_P.RemoveAt(pp);
        }
        //   }
        private void output()
        {
            //fill datagridview2
            string[] tempNameArray = new string[name_before.Count];
            name_before.CopyTo(tempNameArray);
            List<string> tempName = tempNameArray.ToList();

            dt = new DataTable();
            //BindingSource sbind = new BindingSource();
            listGV.Clear();
            EndGV.Clear();
            ProcessGV.Clear();
            SizeGV.Clear();
            listGV = Start_P.ConvertAll(s => s.ToString());
            listGV.AddRange(Start_H.ConvertAll(s => s.ToString()));

            EndGV = ending_P.ConvertAll(s => s.ToString());
            EndGV.AddRange(ending_H.ConvertAll(s => s.ToString()));

            SizeGV = size_P.ConvertAll(s => s.ToString());
            SizeGV.AddRange(size_H.ConvertAll(s => s.ToString()));

            ProcessGV = tempName;
            ProcessGV.AddRange(Enumerable.Repeat("hole", size_H.Count).ToList());

            addListToGV("Start", listGV);
            addAgain("End", EndGV);
            addAgain("ProName", ProcessGV);
            addAgain("Size", SizeGV);

            //sbind.DataSource = dt;
            dataGridView2.DataSource = this.dt;
            //sort data by starting address in the datagridview
            dataGridView2.Sort(this.dataGridView2.Columns["Start"], ListSortDirection.Ascending);
        }

        private void addListToGV(string colName, List<string> list)
        {
            dt.Columns.Add(colName, typeof(string));
            foreach (string item in list)
            {
                DataRow row = dt.NewRow();
                row[colName] = item;
                dt.Rows.Add(row);
            }

        }
        private void addAgain(string colName, List<string> list)
        {
            int counter = 0;
            dt.Columns.Add(colName, typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                if (counter == list.Count)
                    break;
                row[colName] = list[counter];
                counter++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // check that all input is taken
            int processesNo = Int32.Parse(textBox1.Text);
            Checks();
            name_before.Add(textBox2.Text);
            if (programCounter == 0)
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

        private void button2_Click(object sender, EventArgs e)
        {
            // check that all input is taken
            getInput();
            Checks();
            name_before.Add(textBox2.Text);
            if (programCounter == 0)
                allocate();
            output();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Deallocate();
            MessageBox.Show("finished deallocation");
            output();
        }
    }
}
