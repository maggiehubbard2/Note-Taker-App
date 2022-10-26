using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class NoteForm : Form
    {
        
        DataTable notes = new DataTable();
        bool editing = false;

        public NoteForm()
        {
            InitializeComponent();

            
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            //create colums for data table
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            //point to data grid in the form to connect to data table
            previousNotes.DataSource = notes;
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {

                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = Title.Text;
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = Body.Text;
                
            }
            else
            {
                //save the note
                notes.Rows.Add(Title.Text, Body.Text);
                Console.WriteLine("Note Count" + notes.Rows.Count);

            }

            //clear text after saving
            this.clearBtn_Click( sender, e);
            editing = false;

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            Title.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            Body.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;



        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //try catch just in case there is nothing to delete
            try
            {
                //deletes selected row from data grid
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();

            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid note");
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Body.Text = "";
            Title.Text = "";

        }
        

       
    }
}
