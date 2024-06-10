import React from 'react'
import styles from './BookCardFooter.module.css'

const BookCardFooter = (props) => {
    return (
        <div className={styles.bookCardDivFooter}>

            <div className={styles.title}>
                <p className={styles.titleText}>
                    {props.title}
                </p>
            </div>

            <button className={styles.deleteButton} onClick={props.onClick}>
                Delete the book
            </button>
        </div>
    )
}

export default BookCardFooter