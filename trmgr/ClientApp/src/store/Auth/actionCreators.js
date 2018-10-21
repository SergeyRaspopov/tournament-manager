import * as at from './actionTypes';

const headers = { 'Content-Type': 'application/json' };

const actionCreators = {
    initAuth: () => async (dispatch) => {
        const user = JSON.parse(localStorage.getItem('user'));
        const exp = +localStorage.getItem('exp');
        //console.log(user, exp, Date.now());
        if (user) {
            if (exp > Date.now()) {
                dispatch({ type: at.RECEIVE_LOGIN, user: user, exp: exp });
            }
        }
    },
    signIn: (userName, password) => async (dispatch, getState) => {
        try {
            dispatch({ type: at.REQUEST_LOGIN });
            const body = { userName: userName, password: password };
            const url = `api/auth/login`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'POST', headers: headers });
            const result = await response.json();
            const expiresAt = Date.now() + result.expiresIn * 1000;
            localStorage.setItem('user', JSON.stringify(result.user));
            localStorage.setItem('exp', expiresAt);
            dispatch({ type: at.RECEIVE_LOGIN, user: result.user, exp: result.expiresAt });
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
            await response.json();
            dispatch({ type: at.RECEIVE_REGISTER });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_REGISTER_ERROR });
        }
    }
};

export default actionCreators;