using Bookmaster.AppData;
using Bookmaster.Model;
using Bookmaster.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();
        List<BookCover> _bookCovers = App.context.BookCover.ToList();

        PaginationService<Book> _booksPagination;
        PaginationService<BookCover> _bookcoverPagination;

        public BrowseCatalogPage()
        {
            InitializeComponent();


        }

        private void Page_loaded(object sender, RoutedEventArgs e)
        {

        }

        private ListView GetBookAuthorLv()
        {
            return BookAuthorLv;
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            SearchResultGrid.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(SearchByBookTitleTb.Text) && string.IsNullOrEmpty(SearchByAuthorNameTb.Text) && string.IsNullOrEmpty(SearchByBookSubjectTb.Text))
            {
                _booksPagination = new PaginationService<Book>(_books, 50);
            }
            else
            {
                List<Book> searchResults = _books.Where(book => book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) && book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();

                _booksPagination = new PaginationService<Book>(searchResults, 50);
            }

            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfItems;
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination; _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);


            BookAuthorLv.ItemsSource = _books;

            BookAuthorLv.ItemsSource = _books.Where(book => book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) && book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower()));



        }



        private void CurrentPageTb_TextChanged(object sender, RoutedEvent e)
        {

        }
        private void NextBookBtn_Click(object sender, RoutedEvent e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
            _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
        }
        private void PreviousBookBtn_Click(object sender, RoutedEvent e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviousPage();
            _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
        }

        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int result))
            {

            }
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;

            if (selectedBook != null)
            {
                BookDetailsGrid.DataContext = selectedBook;
                _bookcoverPagination = new PaginationService<BookCover>(_bookCovers.Where(bc => bc.BookId == selectedBook.Id).ToList(), 1);
                CoversLb.ItemsSource = _bookcoverPagination.CurrentPageOfItems;
                _bookcoverPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
            }           
        }

        private void AuthorDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;

            BookAuthorDetailsWindow bookAuthorDetailsWindow = new BookAuthorDetailsWindow(selectedBook);
            bookAuthorDetailsWindow.ShowDialog();
        }

        private void NextBookBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousBookBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
