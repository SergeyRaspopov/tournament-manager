import * as at from './actionTypes';

const initialState = {
    tournaments: []
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case at.REQUEST_TOURNAMENTS:
            return { ...state };
        case at.RECEIVE_TOURNAMENTS:
            return { ...state };
        case at.RECEIVE_TOURNAMENTS_ERROR:
            return { ...state };

        default:
            return state;
    }
};

export default reducer;