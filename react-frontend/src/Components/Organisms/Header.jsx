import React from 'react'
import styles from './Header.module.css'
import logo from '../../photos/logo-horizontal.png'

const Header = () => {
    return (
        <div className={styles.headerDiv}>
            <nav>
                <a href='/' className={styles.navLink}>
                    <img src={logo} className={styles.logo} alt="logo" />
                </a>
            </nav>
        </div>
    )
}

export default Header