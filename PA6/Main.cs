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
    public partial class formMain : Form
    {
        string cwid;
        List<Book> myBooks; //creating a list of books

        public formMain(string tempCWID)
        {
            this.cwid = tempCWID;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //reload the list of books
        private void LoadList()
        { 
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //casting

            //must set textbox equal to data from book
            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGeneData.Text = myBook.genre;
            txtISBNData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }
        }

        //decrease number of copies
        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");

            LoadList();
        }

        //increase number of copies
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");

            LoadList();
        }

        //delete selected book
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid); //must pass associated cwid
            }

            LoadList();
        }

        //edit selected book
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //casting
            //calls the edit form
            formEdit myForm = new formEdit(myBook, "edit", cwid); //mode determines if fields prepopulate
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        //create new book
        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            //calls new form
            formEdit myForm = new formEdit(myBook, "new", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
