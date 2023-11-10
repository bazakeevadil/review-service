import axios from "axios";



export const register = (values) =>{

 return async(dispatch) =>{
    try{
   const {data} = await axios.post('https://deciding-bluebird-pleasantly.ngrok-free.app/api/auth/register',
      
       {
            email: values.email,
            password: values.password2
          }
    )
 dispatch({type:'REGISTER_USER',data})
 }
 catch(e){
    console.log(e)}
 }

 }


    export const authorization = (values) => {
        return (dispatch) => {
            return axios.post('https://deciding-bluebird-pleasantly.ngrok-free.app/api/auth/login', {
                email: values.email,
                password: values.password
            }).then(data => {
                return data.data
            })
        }
    }


    export const getCourses = () => {
return (dispatch) => {
    return axios ('https://deciding-bluebird-pleasantly.ngrok-free.app/api/courses',
    {
        headers:{
            ['ngrok-skip-browser-warning'] : true
        }
    })
    .then(res => {
        
        return dispatch({type:'GET_COURSE',payload:res.data})
    })
}

    }

// export const addPost = (value) => {
//     console.log(value);
//     return (dispatch) => {
//         return axios.post('https://deciding-bluebird-pleasantly.ngrok-free.app/api/reviews',{
//                 courseId: 5,
//                 content: value,
//                 userId: 0,
//                 grade: 2
//         }).then(res => {
//             return dispatch({type: 'ADD_NEW_POST', payload: res})
//         })
//     }
// }
//     curl -X 'POST' \
//   'https://deciding-bluebird-pleasantly.ngrok-free.app/api/reviews' \
//   -H 'accept: */*' \
//   -H 'Content-Type: application/json' \
//   -d '{
//   "courseId": 0,
//   "userId": 0,
//   "content": "string",
//   "grade": 0
// }'


// export const addPost = () => {
//     return () => {
//         return axios.post('https://deciding-bluebird-pleasantly.ngrok-free.app/api/reviews',{
//             "content" :""
//         })

//     }
// }



  



