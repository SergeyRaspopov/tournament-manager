import * as at from './actionTypes';

const actionCreators = {
    signIn: (userName, password) => async (dispatch, getState) => {
        dispatch({ type: at.REQUEST_LOGIN });

        const body = { userName: userName, password: password };
        const headers = { 'Content-Type': 'application/json' };
        const url = `api/auth/login`;
        const response = await fetch(url, { body: JSON.stringify(body), method: 'POST', headers: headers });
        console.log(document.cookie);
        const result = await response.json();
        dispatch({ type: at.REQUEST_LOGIN });
    }
};

export default actionCreators;