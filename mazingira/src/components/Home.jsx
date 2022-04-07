import React from 'react';
import "./Home.css";
import {Link} from 'react-router-dom'


const Home = () => {
  return (
    <div className='home'>
      <div className='home1'>
      <h2 className='centretext'>Wondering how to send your parcel<br></br> or who to trust with your parcel
      worry no more,<br></br> we at send-it provide you with the ultimate guarantee <br></br>
      and efficiency in parcel delivery</h2>

      
      <Link to="/Login" className="btmary">SIGN IN</Link>
      
      
      </div>
   

    </div>
    
  );
};
  
export default Home;