import React from 'react';
import "./Signup.css";
import { useState } from "react";
import {Link} from 'react-router-dom'

const Signup = () => {


    const [username, setusername] = useState();
    const [fullname, setFullname] = useState();
    const [phonenumber, setPhonenumber] = useState('');
    const [email, setemail] = useState('');
    const [password, setPassword] = useState('');
  
    //Post Method
    const apiPost = async () => {
       fetch("/users", {
        method: "POST",
        body: JSON.stringify({
          username,
          fullname,
          phonenumber,
          email,
          password,
        }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((response) => response.json())
        .then((json) => console.log(json));
    };
  





  return (
    <div className='signup'>
    
    <div className='innersegmentsp'>
   
    <div className='signup1'>
    <form className='fm'>
    
    <h1>SIGN  UP</h1>



    <label>Username:<br></br><input className='username' value={username} type="text"onChange={(e) =>{setusername(e.target.value);}}  /><br></br></label>
    <label>Fullname:<br></br><input className='fullname' type="text" value={fullname} onChange={(e) =>{setFullname(e.target.value);}} /></label>
    <label>Phonenumber:<br></br><input className='phonenumber' type="text" value={phonenumber} onChange={(e) =>{setPhonenumber(e.target.value);}} /></label>
    <label>Email:<br></br><input className='email' type="email" value={email} onChange={(e) =>{setemail(e.target.value);}}/></label>
    <label>Password:<br></br><input className='password' type="password" value={password} onChange={(e) =>{setPassword(e.target.value);}}/></label>

    <br></br>
    <br></br>
    <button className='btnsubmit'onClick={(e)=>{
      e.preventDefault();
      apiPost()
    }}>Submit</button>
    <p>Already a member? <Link to="/Login" className="btimary">SIGN IN</Link></p>
    </form>
    </div>
 
    </div>
  </div>
  );
};
  
export default Signup;