import { legacy_createStore as createStore,applyMiddleware } from "redux";
import thunk from "redux-thunk";

const initialState = {
registerUser:{},
courses:[]
}

const reviewReducer = (state = initialState,action) =>{
    console.log(action);
    switch(action.type){
        case'REGISTER_USER':
        return{...state,registerUser:action.payload}
       case "GET_COURSE":
        return{...state,courses: action.payload}
        default:
            return state
    }

}
export const store = createStore(reviewReducer,applyMiddleware(thunk))