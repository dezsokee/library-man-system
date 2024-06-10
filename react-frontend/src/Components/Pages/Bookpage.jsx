import styles from './Bookpage.module.css'
import { useLocation } from 'react-router-dom';
import BookCard from '../Organisms/BookCard';
import { useNavigate } from 'react-router-dom';
import LargeButton from '../Atoms/LargeButton';
import { useState } from 'react';

const Bookpage = () => {

  const location = useLocation();
  const navigate = useNavigate();
  const [filter, setFilter] = useState(false);
  const [filteredBooks, setFilteredBooks] = useState([]);

  const books = location.state.books;
  const libraryName = location.state.libraryName;
  const libraryId = location.state.libraryId;

  const addNewBook = () => {
    navigate('/addbook', { state: { libraryId: libraryId, name: libraryName, books: books } });
  }

  const backToTheLibraries = () => {
    navigate('/libraries');
  }

  const searchFunction = () => {
    const searchInput = document.getElementById('searchinput').value;

    if (searchInput === '') {
      setFilter(false);
    } else {
      setFilteredBooks(books.filter(book => book.title.toLowerCase().includes(searchInput.toLowerCase())));
      setFilter(true);
    }
  }

  return (
    <div className={styles.mainBookDiv}>
      <h1 className={styles.titleH1}>List of the books in {libraryName}</h1>
      <hr styles={styles.hr} />

      <span className={styles.searchSpan}>
        <input id="searchinput" type="text" placeholder="Search for a book" className={styles.searchInput} onChange={searchFunction} />
      </span>

      {
        !filter ?
          <div className={styles.booksDiv}>
            {books.map((book, index) => (
              <div>
                <BookCard key={index} title={book.title} index={book.id} numberOfPages={book.pages} />
              </div>
            ))}
          </div>
          :
          <div className={styles.booksDiv}>
            {filteredBooks.map((book, index) => (
              <BookCard key={index} title={book.title} index={book.id} numberOfPages={book.pages} />
            ))}
          </div>
      }

      <LargeButton onClick={addNewBook} text={"Add a new book"} width={"50%"} />
      <LargeButton onClick={backToTheLibraries} text={"Back to the libraries"} width={"30%"} />
    </div>
  )
}

export default Bookpage