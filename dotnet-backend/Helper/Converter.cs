using webapi;

namespace webapi.Helper {
    public static class Converter {

        public static BookDAL FromBookToBookDAL (Book book) {
            BookDAL bookDAL = new BookDAL {
                Id = book.Id,
                Title = book.Title,
                PublishYear = book.PublishYear,
                Pages = book.Pages,
                LibraryId = book.LibraryId
            };

            return bookDAL;
        }

        public static Book FromBookDALToBook(BookDAL bookDAL) {
            Book book = new Book {
                Id = bookDAL.Id,
                Title = bookDAL.Title,
                PublishYear = bookDAL.PublishYear,
                Pages = bookDAL.Pages,
                NumberOfCharacters = bookDAL.Title != null ? bookDAL.Title.Length : 0,
                LibraryId = bookDAL.LibraryId
            };

            return book;
        }

        public static Book FromInBookDTOToBook(InBookDTO bookDTO) {
            Book book = new Book {
                Title = bookDTO.Title,
                PublishYear = bookDTO.PublishYear,
                Pages = bookDTO.Pages,
                NumberOfCharacters = bookDTO.Title != null ? bookDTO.Title.Length : 0,
                LibraryId = bookDTO.LibraryId
            };

            return book;
        }

        public static OutBookDTO FromBookToOutBookDTO(Book book) {
            OutBookDTO bookDTO = new OutBookDTO {
                Title = book.Title,
                PublishYear = book.PublishYear,
                Pages = book.Pages,
                NumberOfCharacters = book.NumberOfCharacters,
                LibraryId = book.LibraryId
            };

            return bookDTO;
        }

        public static Library FromInLibraryDTOToLibrary(InLibraryDTO libraryDTO) {
            Library library = new Library {
                Name = libraryDTO.Name,
                Address = libraryDTO.Address,
                ConstructionYear = libraryDTO.ConstructionYear,
                Books = new List<Book>(),
                NumberOfBooks = 0
            };

            return library;
        }

        public static OutLibraryDTO FromLibraryToOutLibraryDTO(Library library) {
            OutLibraryDTO libraryDTO = new OutLibraryDTO {
                Name = library.Name,
                Address = library.Address,
                ConstructionYear = library.ConstructionYear,
                NumberOfBooks = library.NumberOfBooks,
                Books = new List<Book>()
            };

            if (library.Books != null) {
                foreach (Book book in library.Books) {
                    libraryDTO.Books.Add(book);
                }
            }

            return libraryDTO;
        }

        public static LibraryDAL FromLibraryToLibraryDAL(Library library) {
            LibraryDAL libraryDAL = new LibraryDAL {
                Id = library.Id,
                Name = library.Name,
                Address = library.Address,
                ConstructionYear = library.ConstructionYear,
                Books = new List<BookDAL>()
            };

            if (library.Books != null) {
                foreach (Book book in library.Books) {
                    libraryDAL.Books.Add(FromBookToBookDAL(book));
                }
            }

            return libraryDAL;
        }

        public static Library FromLibraryDALToLibrary(LibraryDAL libraryDAL) {
            Library library = new Library {
                Id = libraryDAL.Id,
                Name = libraryDAL.Name,
                Address = libraryDAL.Address,
                ConstructionYear = libraryDAL.ConstructionYear,
                Books = new List<Book>(),
                NumberOfBooks = 0
            };

            if (libraryDAL.Books != null) {
                foreach (BookDAL bookDAL in libraryDAL.Books) {
                    library.Books.Add(FromBookDALToBook(bookDAL));
                }
            }

            library.NumberOfBooks = library.Books.Count;

            return library;
        }

    }
}