using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Class {
    class Program {
        static void Main(string[] args) {
            Author donHo = new Author("Don Ho", true);
            Author alPrince = new Author("Al Prince", false);
            Author georgePatton = new Author("George Patton", false);
            Author marthaMark = new Author("Martha Mark", false);
            Author joyceAppleby = new Author("Joyce Appleby", true);

            //CookBooks
            Book polyDesertsBk = new Cookbook("Polynesian Desserts", new List<Author> { donHo, alPrince }, 4, 9, 176);
            Book cookLentilsBk = new Cookbook("Cooking with Lentils", new List<Author> { marthaMark }, 3, 8, 107);
            //NonFiction
            Book funTanksBk = new NonFiction("Fun with Tanks", new List<Author> { georgePatton }, 3, 6, 22);
            Book warColoniesBk = new NonFiction("The War of the Colonies", new List<Author> { joyceAppleby }, 5, 6, 1776);


            Shelf shelfOne = new Shelf(10, 8);
            Shelf shelfTwo = new Shelf(10, 10);

            BookCase bookCase = new BookCase();
            bookCase.AddShelf(shelfTwo);
            bookCase.AddShelf(shelfOne);

            bookCase.AddBook(polyDesertsBk);
            bookCase.AddBook(funTanksBk);
            bookCase.AddBook(cookLentilsBk);
            bookCase.AddBook(warColoniesBk);

            shelfTwo.DescribeContents();
            Console.ReadLine();
        }
    }

    public class BookCase {
        private List<Shelf> _shelves { get; set; }

        public BookCase() {
            _shelves = new List<Shelf>();
        }

        public void AddShelf(Shelf shelf) {
            _shelves.Add(shelf);
            _shelves.Sort(new BookCaseShelfSorter());
        }

        public void AddBook(Book book) {
            foreach (Shelf shelf in _shelves) {
                if (shelf._depth >= book._depth) {
                    if (shelf.AddBook(book))
                        break;
                }
            }
        }
    }

    public class BookCaseShelfSorter : IComparer<Shelf> {
        public int Compare(Shelf shelf1, Shelf shelf2) {
            return (shelf1._width).CompareTo(shelf2._width);
        }
    }

    public class Shelf {
        public int _width { get; set; }
        public int _depth { get; set; }
        public int _leftOverWidth { get; set; }
        List<Book> _books { get; set; }

        public Shelf(int width, int depth) {
            _width = width;
            _depth = depth;
            _leftOverWidth = _width;
            _books = new List<Book>();
        }

        public bool AddBook(Book book) {
            if (book._width < _leftOverWidth && book._depth <= _depth) {
                _books.Add(book);
                _leftOverWidth -= book._width;
                return true;
            }
            return false;
        }

        public void DescribeContents() {
            foreach (Book book in _books) {
                book.DescribeMe();
            }
        }
    }

    public class Book {
        public string _title { get; set; }
        public List<Author> _authors { get; set; }
        public int _width { get; set; }
        public int _depth { get; set; }

        public Book(string title, List<Author> authors, int width, int depth) {
            _title = title;
            _authors = authors;
            _width = width;
            _depth = depth;
            authors = new List<Author>();
        }

        public virtual void DescribeMe() {
            StringBuilder strAuthor = new StringBuilder();

            for (int i = 0; i < _authors.Count - 1; i++) {
                strAuthor.Append(_authors[i]._name);
                strAuthor.Append(" & ");
            }
            strAuthor.Append(_authors[_authors.Count - 1]._name);

            Console.Write("\nTitle: {0}, Author(s): {1}, Width: {2}, Depth: {3}", _title, strAuthor, _width, _depth);
        }
    }

    public class Cookbook : Book {
        private int _recipeCount { get; set; }
        public Cookbook(string title, List<Author> authors, int width, int depth, int recipeCount) : base(title, authors, width, depth) {
            _recipeCount = recipeCount;
        }

        public override void DescribeMe() {
            base.DescribeMe();
            Console.Write(", RecipeCount: {0}", _recipeCount);
        }
    }

    public class NonFiction : Book {
        private int _citationCount { get; set; }
        public NonFiction(string title, List<Author> authors, int width, int depth, int citationCount) : base(title, authors, width, depth) {
            _citationCount = citationCount;
        }

        public override void DescribeMe() {
            base.DescribeMe();
            Console.Write(", CitationCount: {0}", _citationCount);
        }
    }

    public class Author {
        public string _name { get; set; }
        public bool _isBestSeller { get; set; }

        public Author(string name, bool isBestSeller) {
            _name = name;
            _isBestSeller = isBestSeller;
        }
    }
}
