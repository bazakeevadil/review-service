
import React from "react"
import { Navigate,Outlet } from "react-router-dom"
import Header from "./Header"
const Layout = () => {
const token= false
    return (
      <>
      
        {token?
        <div className="content">
          <Header/>
          <Outlet/>
        </div>:
        <Navigate to='/banner'/>
        }
      </>
    )
  }
  
  export default Layout