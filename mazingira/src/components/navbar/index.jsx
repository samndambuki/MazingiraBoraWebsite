import React from 'react';
//import {Nav,NavLink,Bars,NavMenu,NavBtn,NavBtnLink,} from './NavbarElements';
import {Link} from 'react-router-dom'
import "./nav.css";
import logo from "../../images/logo.png"
//<button className='signinbtn' >Sign In</button>
//<Link to="./Login" className="btn btn-primary">Sign in</Link>



const menuu = () => {
	const menu = document.getElementById('bar')
	menu.style.display = 'block'
}

const xmenu = () => {
	const menux = document.getElementById('bar')
	menux.style.display = 'none'
}


const Navbar = () => {
return (
	<div className='navbar'>
	<img src={logo} alt="logo" className='logo' />
    <ul className='navbarul'>
	<Link onClick={()=>{menuu()}} className='menu' to='/'><li> &#9776;</li></Link>

	<div id='bar' className='nsp'>
	<Link onClick={()=>{xmenu()}} className='xmenu' to='/'><li>&times;</li></Link>
	<Link className='lnk' to='/'><li>Home</li></Link>
	<Link className='lnk' to='/Learn'><li>Learn</li></Link>
	<Link className='lnk' to='/Aboutus'><li>About us</li></Link>
	<Link className='lnk' to='/Vote'><li>Vote</li></Link>
	<Link className='lnk' to='/Signup'><li>Sign up</li></Link>
	<Link to='/Login'><li>Login</li></Link>
	</div>
	


	
	</ul>

	</div>
);

};

export default Navbar;
