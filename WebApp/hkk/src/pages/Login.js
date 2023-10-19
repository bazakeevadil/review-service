import React, { useState } from 'react'
import * as Yup from 'yup'
import { Formik, Form } from 'formik';


const SignupSchema = Yup.object().shape({
  email: Yup.string().email('hjh')
  .min(5, 'Cлишком короткое имя')
  .max(50, 'Слишком длинное имя')
  .required('Required'),
  password: Yup.string()
  .required('Required')
  .min(5, 'Слишком короткий пароль')
  .max(15, "Слишком длинный пароль")
  .matches(/^[aA-zZ0-9.-_--]+$/, "Forbidden symbol"),
 });

 const Login = ({setIsAuth}) => {
  const [password,setPassword]= useState("")
  const[email,setEmail] = useState("")
  const user ={
    email:"kkaaaa@mail.ru",
    password:"12345678"
  }
  const handleInputEmail = (e) => {
    setEmail(e.target.value)
  }
  const handleInputPass = (e) =>{
    setPassword(e.target.value)
  }
  const handleSubmit = () =>{
if(email===user.email && password === user.password){
  setIsAuth(true)
}
  }
  return(
    <div className='login'>
    <div className="login__wrapper">
      <p className="login__title">Авторизация</p>
      <Formik
        initialValues={{
        email: '',
          password: ''
        }}
        validationSchema={SignupSchema}
        onSubmit={
          () =>{
            if(email===user.email && password === user.password){
              setIsAuth(true)
              console.log('is auth');
            } else{
              alert('false')
            }
        }
      }
       >

        {
          ({ errors, touched, values, handleChange }) => (

            <Form className='login__form'>
              <input
                type="email"
                name="email"
                className="login__inp"
                placeholder="email"
                onChange={handleChange} 
                onInput={handleInputEmail}/>

              {errors.email && touched.email? <div>{errors.email}</div> : null}

              <input
                type="text"
                name="password"
                className="login__inp"
                placeholder="Password"
                onChange={handleChange}
                onInput={handleInputPass}
              />
              {errors.password && touched.password ? <div>{errors.password}</div> : null}

              <button
                type="submit"
                className="login__btn"
              >Войти</button>

            </Form>
          )
        }
      </Formik>
    </div>
  </div>)}
  
 export default Login