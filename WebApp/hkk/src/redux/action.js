import axios from "axios";

export const register = (values) =>{
    console.log(typeof values.password2);
 return async(dispatch) =>{
    return await axios('https://deciding-bluebird-pleasantly.ngrok-free.app/api/auth/register',{
     method:'POST',
        headers:{
           ' accept': '*/*',
            ['Content-Type']: 'application/json'
        },
        data:{
            email: values.email,
            password: values.password2
          }
    }).then(res =>console.log(res))
 }
}