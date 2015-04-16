﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;


namespace VeriHash
{
    public partial class VeriHash : Form
    {
        String copiedHash01;
        public String hashValueString;
        public VeriHash()
        {
            InitializeComponent();
        }
                
        public string GetHash(string file)
        {
            
            try
            {
                byte[] hashValue;
                MD5 md5HashObj = MD5.Create();

                Console.WriteLine("Its a file");
                // Create a fileStream for the file.
                FileStream fileStream = new FileStream(file,FileMode.Open);
                // select the position of the filestream.
                fileStream.Position = 0;
                // Compute the hash of the fileStream.
                hashValue = md5HashObj.ComputeHash(fileStream);
                //instantiate a string builder 
                StringBuilder sBuilder = new StringBuilder();
                // Loop through each hash value bytes formatting each one as a hexadecimal string. 
                for (int i = 0; i < hashValue.Length; i++)
                {
                    sBuilder.Append(hashValue[i].ToString("x2"));
                    //String hashValueString = Convert.ToString (sBuilder);
                    // Write the hash value to the Console.
                }
                hashValueString = Convert.ToString(sBuilder);
                // Write the hash value to the Console.
                Debug.WriteLine("MD5 hash: " + hashValueString);
                //Close the file.
                fileStream.Close();   

            }
            catch (IOException e)
            {
                Debug.WriteLine(e);
                MessageBox.Show(e.ToString());
            }

            return hashValueString;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Copied.Text)
            {
                label3.Text = "Match";
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else 
            {
                label3.Text = "No match";
                label3.ForeColor = System.Drawing.Color.Red;

            }

          
           

        }

        private void Copied_TextChanged(object sender, EventArgs e)
        {
            copiedHash01 = Copied.Text;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path;
            textBox1.Enabled = true;
            Path.Enabled = true;

            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                Path.Text = file.FileName;
                path = file.FileName.ToString();
                textBox1.Text = GetHash(path);
            }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}