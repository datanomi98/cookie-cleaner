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

namespace cleaner
{

    public partial class Form1 : Form
    {

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
        //{
        //    var directoryNode = new TreeNode(dirinfo.Name);
        //    foreach (var directory in dirinfo.GetDirectories())

        //        directoryNode.Nodes.Add(createDirectoryNode(directory));


        //    foreach (var file in dirinfo.GetFiles())

        //        directoryNode.Nodes.Add(new TreeNode(file.Name));
        //    return directoryNode;
        //}
        private void button1_Click(object sender, EventArgs e)
        {


            //ListDirectory(treeView1, @"C:\");


            //this code is working

            //only get dirs which name contains firefox string
            string[] dirs = Directory.GetDirectories(@"D:\", "firefox*");
            //loop throught D: drive
            foreach (string subdir in dirs)
            {
                //load function which checks the sub folders
                loadsubDirs(subdir);
            }
        }
                
               
               


            
                private void loadsubDirs(string dir)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            var files = new DirectoryInfo(dir).GetFiles("*");
            //loop throught files.
            foreach (var filename in files)
            {

                if (filename.ToString().Contains("AccessibleMarshal.dll"))
                {
                    richTextBox1.Controls.Clear();
                    richTextBox1.Text += "\n" + dir + "\n" + filename.ToString();
                }





            }





            foreach (string subdirectory in subdirectoryEntries)

            {

                loadsubDirs(subdirectory);

            }

        }

        }
    }



