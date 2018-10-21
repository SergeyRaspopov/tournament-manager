import * as at from './actionTypes';

const initialState = {
    user: {},
    exp: null,

    isSignedIn: false,
    isSigningIn: false,
    signInError: '',
    isRegistered: false, 
    isRegistering: false,
    registerError: ''
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case at.REQUEST_LOGIN:
            return { ...state, isSigningIn: true };
        case at.RECEIVE_LOGIN:
            return { ...state, isSigningIn: false, isSignedIn: true, signInError: '', user: action.user, exp: action.exp };
        case at.RECEIVE_LOGIN_ERROR:
            return { ...state, isSigningIn: false, isSignedIn: false, signInError: action.error };
        case at.REQUEST_REGISTER:
            return { ...state, isRegistering: true, isRegistered: false };
        case at.RECEIVE_REGISTER:
            return { ...state, isRegistering: false, isRegistered: true, registerError: '' };
        case at.RECEIVE_REGISTER_ERROR:
            return { ...state, isRegistering: false, registerError: action.error };
        default:
            return state;
    }
};

export default reducer;