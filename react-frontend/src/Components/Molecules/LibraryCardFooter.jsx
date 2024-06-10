import React from 'react'

import styles from './LibraryCardFooter.module.css'

const CardFooter = (props) => {
    return (
        <div className={styles.cardFooter}>
            <span className={styles.address1}>
                Location:
                <span className={styles.propsAddress}> {props.address} </span>
            </span>
            <span>
                <button className={styles.booksButton} onClick={props.onclick}>
                    View books
                </button>
                <button className={styles.deleteButton} onClick={props.onclickdelete}>
                    Delete the library
                </button>
            </span>
            <span className={styles.address2}>
                Number of books:
                <span className={styles.propsAddress}>{props.nrBooks}</span>
            </span>
        </div>
    )
}

export default CardFooter