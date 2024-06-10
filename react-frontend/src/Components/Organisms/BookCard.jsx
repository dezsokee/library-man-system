import React from 'react'
import styles from './BookCard.module.css'
import { useNavigate } from 'react-router-dom';
import BookCardFooter from '../Molecules/BookCardFooter';

const BookCard = (props) => {

    const navigate = useNavigate();
    const [isHovered, setIsHovered] = React.useState(false);

    const deleteCurrentBook = () => {

        if (!window.confirm('Are you sure you want to delete the book?')) {
            return;
        }

        fetch(`http://localhost:5257/api/v1/deleteBook/${props.index}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(() => {
                navigate('/libraries');
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }

    const handleMouseEnter = () => {
        setIsHovered(true);
    }

    const handleMouseLeave = () => {
        setIsHovered(false);
    }

    const editButtonHandle = () => {
        navigate('/editbook', { state: { bookId: props.index } });
    }

    return (
        <div className={styles.bookCardContainer} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
            {
                !isHovered ? <div className={styles.bookCardDiv}> </div> :
                    <div className={styles.bookCardDivHover}>
                        <p className={styles.pageText}>
                            Number of pages: {props.numberOfPages}
                        </p>
                        <button className={styles.editButton} onClick={editButtonHandle}>
                            Edit the book
                        </button>
                    </div>
            }

            <BookCardFooter title={props.title} onClick={deleteCurrentBook}/>
        </div>

    )
}

export default BookCard