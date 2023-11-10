
import React from "react"
import { Navigate,Outlet } from "react-router-dom"
import Header from "./Header"
import { useSelector } from 'react-redux'
const Layout = () => {
const token = localStorage.getItem('token')
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