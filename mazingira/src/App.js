import './App.css';
import Navbar from './components/navbar';

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './components/Home';
import Learn from './components/Learn';
import Aboutus  from './components/Aboutus';
import Login from './components/Login';
import Signup from './components/Signup';
import Vote from './components/vote';




function App() {
return (
	
	<Router>
	<div>
  
	<Navbar/>
	<Routes>

		<Route path="/"  element={<Home></Home>} />
		<Route path="/Learn" element={<Learn></Learn>} />
		<Route path="/Aboutus" element={<Aboutus></Aboutus>} />
		<Route path="/Login" element={<Login></Login>} />
		<Route path="/Vote" element={<Vote></Vote>} />
		<Route path="/Signup" element={<Signup></Signup>} />


	</Routes>
	
	</div>
	</Router>
);
}

export default App;
