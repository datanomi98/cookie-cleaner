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
using System.Diagnostics;

namespace cleaner
{

    public partial class Form1 : Form
    {
        public string finalfilepath;
        public Form1()
        {
            InitializeComponent();
        }

        //private void ListDirectory(TreeView treeView, string path)
        //{
        //    treeView.Nodes.Clear();
        //    var rootdirinfo = new DirectoryInfo(path);
        //    treeView.Nodes.Add(createDirectoryNode(rootdirinfo));
        //}
        //private static TreeNode createDirectoryNode(DirectoryInfo dirinfo)
        //{        //    var directoryNode = new TreeNode(dirinfo.Name);
        //    foreach (var directory in dirinfo.GetDirectories())

        //        directoryNode.Nodes.Add(createDirectoryNode(directory));


        //    foreach (var file in dirinfo.GetFiles())

        //        directoryNode.Nodes.Add(new TreeNode(file.Name));
        //    return directoryNode;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            
            Process[] pname = Process.GetProcessesByName("firefox");
            if (pname.Length == 0)
            {
                goto End;
            }

            else
            {
                MessageBox.Show("Please close firefox");
            }

            //ListDirectory(treeView1, @"C:\");


            //this code is working
            End:
            //only get dirs which name contains firefox string
            string[] dirs = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Mozilla", "Firefox*");
            //loop throught C: drive
            //string[] dirs = Directory.GetDirectories(@"D:\", "firefox*");
            foreach (string subdir in dirs)
            {
                //richTextBox1.Controls.Clear();
                //load function which checks the sub folders

                loadsubDirs(subdir);
            }
        }








        private void loadsubDirs(string dir)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            var files = new DirectoryInfo(dir).GetFiles("*");
            //loop throught files.
            //problem: i can't acces all the files in C: drive
            foreach (var filename in files)
            {



                if (filename.ToString() == "cookies.sqlite")
                {

                    //richTextBox1.Controls.Clear();
                    //richTextBox1.Text += filename.ToString().Length;
                    finalfilepath = dir + "/" + filename.ToString();
                    richTextBox1.Text += finalfilepath;
                    //richTextBox1.Text += finalfilepath;

                }






            }


            foreach (string subdirectory in subdirectoryEntries)

            {

                loadsubDirs(subdirectory);

            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                
                //richTextBox1.Text += result;
                File.Delete(finalfilepath);
                richTextBox1.Text += "Onnistui/succeed";
            }
            catch(Exception kek)
            {
                richTextBox1.Text += "error " + kek.Message;
            }
           
        }
    }

    }



