import * as at from './actionTypes';

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
    },
    addTournament: (name, address, city, state, country, date, regStart, regEnd) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_TOURNAMENT });
            const tournament = {
                name: name,
                streetAddress: address,
                city: city,
                state: state,
                country: country,
                date: date,
                registrationStart: regStart,
                registrationEnd: regEnd
            };
            const url = ``;
            const response = await fetch(url, { body: tournament, headers: headers, method: 'POST' });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_TOURNAMENT });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_TOURNAMENT_ERROR });
        }
    }
};

export default actionCreators;