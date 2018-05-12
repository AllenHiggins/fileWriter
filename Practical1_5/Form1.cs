using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//use the input output stream class for reading and writing files to disk
using System.IO;

//Allen Higgins 

namespace Practical1_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declare a var for storing the name of a file
        static string fileName;

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setting file exstentions in the save file window
            saveFileDialog1.Filter = "*.txt|";

            if ( saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                File.WriteAllText(saveFileDialog1.FileName,richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setting file exstentions in the open file window
            openFileDialog1.Filter = "*.txt|";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                fileName = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(fileName);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close the form
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if the var filename is empty (no file has been chosen prevously)
            if (fileName == null)
            {
                //call the saveAs option in the menu
                saveAsToolStripMenuItem.PerformClick();
            }
            else
            {
                //otherwise create a new streamwriter object and pass it the current file name
                //write the data from the text editor to the file
                //clean up by disposing of the object so it wont case any problems later
                //alert the user that that data was saved
                StreamWriter wirter = new StreamWriter(fileName);
                wirter.WriteLine(richTextBox1.Text);
                wirter.Dispose();
                MessageBox.Show("File Saved");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if the var filename is empty (no file has been chosen prevously)
            if (fileName != null)
            {
                //ask the user if they want to save it before exiting to a new file
                //store the returned event in var result 
                var result = MessageBox.Show("Do you want to save file?","Save File",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                //send the event into the switch
                switch (result)
                {
                    //if the user pressed the yes button
                    case DialogResult.Yes:
                        //call the save menu option to save the data and clear the resst the text editor
                        saveToolStripMenuItem.PerformClick();
                        richTextBox1.Clear();
                        break;
                    //if the user pressed the no button don't save anything by simply resetting the text editor
                    case DialogResult.No:
                        richTextBox1.Clear();
                        break;
                    //the cancel button, just do nothing as nothing needs to change
                }
            }
        }

    }
}
