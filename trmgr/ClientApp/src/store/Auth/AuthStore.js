import * as at from './actionTypes';

const initialState = {
    isSignedIn: false,
    isSigningIn: false,
    signInError: ''
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case at.REQUEST_LOGIN:
            return { ...state, isSigningIn: true };
        case at.RECEIVE_LOGIN:
            return { state, isSigningIn: false, isSignedIn: true, signInError: '' };
        case at.RECEIVE_LOGIN_ERROR:
            return { state, isSigningIn: false, isSignedIn: false, signInError: action.error };
        default:
            return state;
    }
};

export default reducer;