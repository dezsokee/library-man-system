import React from 'react'
import styles from './LibraryCard.module.css'
import { useNavigate } from 'react-router-dom';
import CardFooter from '../Molecules/LibraryCardFooter';

const LibraryCard = (props) => {

    const navigate = useNavigate();

    const handleViewBooksClick = () => {
        navigate('/books', {state: {books: props.books, libraryName: props.name, libraryId: props.id}});
    }

    const deleteLibrary = () => {

        if(!window.confirm("Are you sure you want to delete this library?")) return;

        fetch(`http://localhost:5257/api/v1/deleteLibrary/${props.id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(() => {
            window.location.reload();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    return (
        <div>
            <div className={styles.cardDiv}>
                <h2 className={styles.libraryName}>{props.name}</h2>
                <span className={styles.conYear}>
                    Construction year {props.constructionYear}
                </span>
                <CardFooter address={props.address} nrBooks={props.books.length} onclick={handleViewBooksClick} onclickdelete={deleteLibrary}/>
            </div>
            
        </div>
    )
}

export default LibraryCard