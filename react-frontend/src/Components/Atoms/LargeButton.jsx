import React from 'react'
import styles from './LargeButton.module.css'

const LargeButton = (props) => {
  return (
    <button className={styles.buttonDiv} style = {{width: props.width}} onClick={props.onClick}>
      {props.text}
    </button>
  )
}

export default LargeButton