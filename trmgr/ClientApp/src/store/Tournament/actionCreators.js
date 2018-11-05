import * as at from './actionTypes';
import { Action } from 'redux';

const headers = { 'Content-Type': 'application/json' };

const actionCreators = {
    getTournaments: () => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_TOURNAMENTS });
            const url = `api/organizer/tournaments`;
            const response = await fetch(url);
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_TOURNAMENTS, payload: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_TOURNAMENTS_ERROR });
        }
    }
}

export default actionCreators;