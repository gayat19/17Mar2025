import { createSlice } from "@reduxjs/toolkit";

const authSlice = createSlice({
    name :'auth',
    initialState:{
        user:null
    },
    reducers:{
        login:(state,action)=>{
            state.user = action.payload;
            sessionStorage.setItem("user",JSON.stringify(action.payload));
        },
        logout:(state)=>{
            state.user = null;
            sessionStorage.removeItem("user");
        },
        setUser:(state,action)=>{
            state.user = action.payload;
        }
    }
});

export const { login, logout, setUser } = authSlice.actions;
export default authSlice.reducer;


