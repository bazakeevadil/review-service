
import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Header from "./components/Header"
import Banner from "./pages/Banner";
import Login from "./pages/Login";
import Registration from "./pages/Registration";
import Home from "./pages/Home";
import Layout from "./components/Layout";
import Courses from "./pages/Courses";
import Reviews from "./pages/Reviews";


const  App =( ) => {


  return (
    <div >
    
     <Router>
      <Header/>
      <Routes>
        <Route path="/" element={<Layout />}>
      <Route index element={<Home />}/> 
      <Route path="/courses" element= {<Courses/>}/>
      <Route path="/courses/:id" element= {<Reviews/>}/>
      </Route>
        <Route path="/banner" element= {<Banner/>}/>
        <Route path="/login" element={<Login />}/>
        <Route path="/registration" element={<Registration/>}/>
      </Routes>
     </Router>
    </div>
  );
}

export default App;
