import React from 'react';
import "./Login.css";
import {Link, Navigate} from 'react-router-dom';
import { useState } from "react";
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const Navigate = useNavigate()
  const [email, setemail] = useState('');
  const [password, setPassword] = useState('');

  //Post Method
  const logPost = async () => {
     fetch("/login", {
      method: "POST",
      body: JSON.stringify({
        email,
        password,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((json) => {console.log(json);
      localStorage.setItem('x-access-token', json.token)
     Navigate('/');
    });
  };




  return (
 
    <div className='login'>
    
      <div className='innersegment'>
      <div className='form'>

      <form>
      <h1>LOG  IN</h1>



      <label>Email:<br></br><input className='email'  type="text" value={email} onChange={(e) =>{setemail(e.target.value);}}/></label><br></br>
      <label>Password:<br></br><input className='password' type="text" value={password} onChange={(e) =>{setPassword(e.target.value);}}/></label>
      <br></br>
      <br></br>

      <button className='btnsubmit'onClick={(e)=>{
        e.preventDefault();
        logPost()
      }}>Login</button>

      <p>Forgotten your password?</p>
      <p>Not a member? <Link to="/Signup" className="bimary">SIGN UP</Link></p>

      </form>

      </div>
      <div className='membership'>
      
      <p>
     
      A Full Member is a member <br></br>
      who is duly elected as such.<br></br>
      He or She shall be entitled <br></br>
      to all privileges of the Club, <br></br>
      to vote at any General<br></br>
      Meeting, and or any <br></br>
      sub-committeethat may be<br></br>
      formed, providing that they <br></br>
      are fully paid-up members.
      </p>

      </div>
      
      </div>
   

    </div>
  );
};
  
export default Login;