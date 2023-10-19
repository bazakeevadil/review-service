import React, { useState } from 'react'
import * as Yup from 'yup'
import { Formik, Form } from 'formik';
import axios from 'axios';


const SignupSchema = Yup.object().shape({
  email: Yup.string().email()
  .min(5, 'Cлишком короткое имя')
  .max(50, 'Слишком длинное имя')
  .required('Required')
  .matches(/^[aA-zZ]+$/, "Forbidden symbol"),
  password1: Yup.string()
  .required('Required')
  .min(5, 'Слишком короткий пароль')
  .max(15, "Слишком длинный пароль")
  .matches(/^[aA-zZ0-9.-_--]+$/, "Forbidden symbol"),
  password2: Yup.string()
  .oneOf([Yup.ref('password1'), null], 'Неверный пароль')

 });

 const Registration = () => {
    // const addList = async () => {
    //     const config = {
    //       method:"POST",
    //       url:"http://localhost/api/auth/register" ,
    //       headers:{
    //         "Content-Type" : "application/json"
    //       },
    //       data:JSON.stringify({
    //     '  username':'fjfjfj',
    //   '  password':'ygfseg6',
    //   'role' :1
    //       })
      
    //   }
    //   const {data} = await axios (config)
    //   console.log(data);}
    //   addList()
    const [password,setPassword] = useState('')
    const handleInput = (e) =>{
setPassword(e.target.value)
    }
    
  return(
    <div className='login'>
    <div className="login__wrapper">
      <p className="login__title">Регистрация</p>
      <Formik
        initialValues={{
        email: '',
          password1: '',
          password2:''
        }}
        validationSchema={SignupSchema}
       >

        {
          ({ errors, touched, values, handleChange }) => (

            <Form className='login__form'>
              <input
                type="text"
                name="email"
                className="login__inp"
                placeholder="email"
                onChange={handleChange} />

              {errors.email && touched.email? <div>{errors.email}</div> : null}

              <input
                type="text"
                name="password1"
                className="login__inp"
                placeholder="Пароль"
                onChange={handleChange}
                onInput={handleInput}
              />
              {errors.password1 && touched.password1? <div>{errors.password1}</div> : null}
              <input
                type="text"
                name="password2"
                className="login__inp"
                placeholder="Подтверждение пароля"
                onChange={handleChange}
             
              />
              {errors.password2 && touched.password2 ? <div>{errors.password2}</div> : null}


              <button
                type="submit"
                className="login__btn"
              >Регистрация</button>

            </Form>
          )
        }
      </Formik>
    </div>
  </div>)}
  
 export default Registration