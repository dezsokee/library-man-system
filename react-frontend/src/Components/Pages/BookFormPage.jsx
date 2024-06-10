import React from 'react'
import { useLocation } from 'react-router-dom';
import styles from './BookFormPage.module.css'
import { useNavigate } from 'react-router-dom';
import LargeButton from '../Atoms/LargeButton';

const BookForm = (props) => {

    const location = useLocation();
    const navigate = useNavigate();

    const libraryId = location.state.libraryId;
    const libraryName = location.state.name;
    let bookID = 0;
    
    if(props.edit) {
        bookID = location.state.bookId;
    }

    const addNewBook = () => {
        const title = document.querySelector('input[name="title"]').value;
        const pubyear = document.querySelector('input[name="pubyear"]').value;
        const pages = document.querySelector('input[name="pages"]').value;

        if (title === '' || pubyear === '' || pages === '' || pages < 0 || pubyear < 0 || isNaN(pages) || isNaN(pubyear) || title.length > 100) {
            alert('Please type valid values for the book!');
            navigate('/libraries');
        } else {
            fetch('http://localhost:5257/api/v1/addBooks', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    title: title,
                    pubyear: pubyear,
                    pages: pages,
                    libraryId: libraryId
                })
            })

            navigate('/libraries');
        }
    }

    const editCurrentBook = () => {
        const title = document.querySelector('input[name="title"]').value;
        const pubyear = document.querySelector('input[name="pubyear"]').value;
        const pages = document.querySelector('input[name="pages"]').value;

        if (title === '' || pubyear === '' || pages === '' || pages < 0 || pubyear < 0 || isNaN(pages) || isNaN(pubyear) || title.length > 100) {
            alert('Please type valid values for the book!');
            navigate('/libraries');
        } else {
            fetch(`http://localhost:5257/api/v1/updateBook/${bookID}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    title: title,
                    pubyear: pubyear,
                    pages: pages,
                })
            })

            navigate('/libraries');
        }
    }

    return (
        <div className={styles.formDiv}>
            {
                props.edit ?
                    <div className={styles.formAlDiv}>
                        <h1 className={styles.h1text}>Edit the selected book informations!</h1>

                        <hr style={styles.hr} />

                        <form className={styles.formLayout}>
                            <label>Title</label>
                            <input type="text" name="title" />

                            <label>Publish year</label>
                            <input type="text" name="pubyear" />

                            <label>Pages</label>
                            <input type="text" name="pages" />

                            <LargeButton onClick={editCurrentBook} text={"Complete the edit"} width={"50%"} />
                        </form>
                    </div>
                    :
                    <div className={styles.formAlDiv}>
                        <h1 className={styles.h1text}>Add a new book into {libraryName}</h1>

                        <hr style={styles.hr} />

                        <form className={styles.formLayout}>
                            <label>Title</label>
                            <input type="text" name="title" />

                            <label>Publish year</label>
                            <input type="text" name="pubyear" />

                            <label>Pages</label>
                            <input type="text" name="pages" />

                            <LargeButton onClick={addNewBook} text={"Submit"} width={"50%"} />
                        </form>
                    </div>
            }


        </div>
    )
}

export default BookForm