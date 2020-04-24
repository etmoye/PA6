using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class formEdit : Form
    {
        //create fields
        private Book myBook;
        private string cwid;
        private string mode;

        public formEdit(Object tempBook, string tempMode, string tempCwid)
        {

            myBook = (Book)tempBook; //cast
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formEdit_Load(object sender, EventArgs e)
        {
            if (mode == "edit")
            {
                //set textbox what is in the object
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGeneData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString(); //number of copies is and int so you have to use a ToString
                txtISBNData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.length.ToString(); //number of copies is and int so you have to use a ToString

                pbCover.Load(myBook.cover);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGeneData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text); //number of copies is and int so you have to use a ToString
            myBook.isbn = txtISBNData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.length = int.Parse(txtLengthData.Text); //number of copies is and int so you have to use a ToString

            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Content was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
