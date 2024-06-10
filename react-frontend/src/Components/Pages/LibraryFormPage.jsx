import React from 'react'
import styles from './LibraryFormPage.module.css'
import { useNavigate } from 'react-router-dom';

const LibraryForm = () => {

  const navigate = useNavigate();

  const addNewLibrary = () => {
    const name = document.querySelector('input[name="name"]').value;
    const address = document.querySelector('input[name="address"]').value;
    const conyear = document.querySelector('input[name="conyear"]').value;

    if(name === '' || address === '' || conyear === '' || isNaN(conyear) || conyear < 0 || conyear > 2024 || address.length < 5 || name.length < 5 || name.length > 50 || address.length > 50){
      alert('Please fill in all the fields');
      return;
    }

    fetch('http://localhost:5257/api/v1/addLibrary', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        name: name,
        address: address,
        constructionYear: conyear
      })
    })

    navigate('/libraries');

  }

  return (
    <div className={styles.formDiv}>
      <h1 className={styles.h1text}>Add a new library</h1>

      <hr style={styles.hr} />

      <form className={styles.formLayout}>
        <label>Name</label>
        <input type="text" name="name" />

        <label>Address</label>
        <input type="text" name="address" />

        <label>Construction year</label>
        <input type="text" name="conyear" />
        
        <button className={styles.addLibraryButton} onClick={addNewLibrary}>Submit</button>
      </form>

    </div>
  )
}

export default LibraryForm