import React, { useEffect, useState } from 'react'
import styles from './Librarypage.module.css'
import LibraryCard from '../Organisms/LibraryCard'
import { useNavigate } from 'react-router-dom';
import LargeButton from '../Atoms/LargeButton';

const LibraryPage = () => {

  const [data, setData] = useState([])

  const navigate = useNavigate();

  useEffect(() => {
    fetch('http://localhost:5257/api/v1/libraries')
      .then(response => response.json())
      .then(data => setData(data))
  }, [])

  const addLibrary = () => {
    navigate('/addLibrary');
  }


  return (
    <div className={styles.mainLibraryDiv}>
      <h1 className={styles.titleH1}>List of the libraries</h1>
      <hr style={styles.hr} />
      <ul>
        {data.map((library, index) => (
          <LibraryCard key={index} name={library.name} address={library.address} constructionYear={library.constructionYear} nrBooks={library.numberOfBooks} books={library.books} id={library.id}/>
        ))}
      </ul>
      <LargeButton text="Add library" width="500px" onClick={addLibrary}/>
    </div>
  )
}

export default LibraryPage