import React from 'react';
import "./vote.css";
import { useState } from "react";
import {Link} from 'react-router-dom'

const Vote = () => {


    const [nomineeusername, setnomineeusername] = useState();
    const [fullname, setFullname] = useState();
    const [phonenumber, setPhonenumber] = useState('');
    const [email, setemail] = useState('');
  
    //Post Method
    const apiPost = async () => {
       fetch("/users", {
        method: "POST",
        body: JSON.stringify({
          
          fullname,
          phonenumber,
          email,
         nomineeusername,
        }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((response) => response.json())
        .then((json) => console.log(json));
    };
  





  return (
    <div className='vote'>
    
    <div className='innersegmentv'>
   
    <div className='vote1'>
    <form className='fmv'>
    
    <h1>VOTING SECTION</h1>



    <label>Fullname:<br></br><input className='fullname' type="text" value={fullname} onChange={(e) =>{setFullname(e.target.value);}} /></label>
    <label>Phonenumber:<br></br><input className='phonenumber' type="text" value={phonenumber} onChange={(e) =>{setPhonenumber(e.target.value);}} /></label>
    <label>Email:<br></br><input className='email' type="email" value={email} onChange={(e) =>{setemail(e.target.value);}}/></label>
    <label>nomineeUsername:<br></br><input className='nomineeusername' value={nomineeusername} type="text"onChange={(e) =>{setnomineeusername(e.target.value);}}  /><br></br></label>

    <br></br>
    <br></br>
    <button className='btnsubmit'onClick={(e)=>{
      e.preventDefault();
      apiPost()
    }}>Submit</button>

    </form>
    </div>
 
    </div>
  </div>
  );
};
  
export default Vote;