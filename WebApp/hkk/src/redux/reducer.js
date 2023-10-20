import { legacy_createStore as createStore,applyMiddleware } from "redux";
import thunk from "redux-thunk";

const initialState = {
registerUser:''
}

const reviewReducer = (state = initialState,action) =>{
    // switch(action.type){
    //     case'REGISTER_USER':
    //     return{...state}
    // }

}
export const store = createStore(reviewReducer,applyMiddleware(thunk))