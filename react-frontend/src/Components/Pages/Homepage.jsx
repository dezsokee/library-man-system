import React from 'react'
import logo from '../../photos/logo.png'
import { useNavigate } from 'react-router-dom';
import styles from './HomePage.module.css'
import LargeButton from '../Atoms/LargeButton';

const Homepage = () => {

    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/libraries');
    }

    return (
        <div className= {styles.homePageDiv}>
            <img src={logo} className={styles.logo} alt="logo" />
            <hr className={styles.hr}/>

            <div className={styles.mottoText}> Unlock the Door to Knowledge: Explore, Discover, Learn! </div>

            <LargeButton onClick = {handleClick} width = {400}  text={"Start your journey here!"}/>

        </div>
    )
}

export default Homepage