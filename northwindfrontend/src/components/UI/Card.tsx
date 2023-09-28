import React from "react";
import './Card.css'

function Card(props:any){
    return  <div className="centered-container">{props.children}</div>
}

export default Card;