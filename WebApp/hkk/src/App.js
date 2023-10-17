
import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Header from "./components/Header"
import Banner from "./pages/Banner";


const  App =( ) => {
  return (
    <div >
     <Router>
      <Header/>
      <Routes>
        <Route path="/" element= {<Banner/>}/>
      </Routes>
     </Router>
    </div>
  );
}

export default App;
