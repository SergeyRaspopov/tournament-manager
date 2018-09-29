import * as at from './actionTypes';

const headers = { 'Content-Type': 'application/json' };

const actionCreators = {
    signIn: (userName, password) => async (dispatch, getState) => {
        try {
            dispatch({ type: at.REQUEST_LOGIN });
            const body = { userName: userName, password: password };
            const url = `api/auth/login`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'POST', headers: headers });
            const result = await response.json();
            localStorage.setItem('user', JSON.stringify(result.user));
            dispatch({ type: at.RECEIVE_LOGIN });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_LOGIN_ERROR });
        }
    },
    
    register: (userName, emailAddress, password, confirmPassword) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_REGISTER });
            const body = {
                userName: userName,
                emailAddress: emailAddress,
                password: password,
                confirmPassword: confirmPassword
            };
            const url = `api/auth/register`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'POST', headers: headers });
            const result = await response.json();
            dispatch({ type: at.RECEIVE_REGISTER });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_REGISTER_ERROR });
        }
    }
};

export default actionCreators;