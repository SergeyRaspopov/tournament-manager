import * as at from './actionTypes';

const actionCreators = {
    getCountries: () => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_COUNTRIES });
            const url = `api/address/countries`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_COUNTRIES, countries: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_COUNTRIES_ERROR, error: err });
        }
    },

    getProvinces: (countryId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_PROVINCES });
            const url = `api/address/provinces/${countryId}`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_PROVINCES, provinces: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_PROVINCES_ERROR, error: err });
        }
    },

    getCities: (provinceId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_CITIES });
            const url = `api/address/cities/${provinceId}`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_CITIES, cities: result });
        }
        catch (err) {
            dispatch({ type: at.RECIEVE_CITIES_ERROR, error: err });
        }
    }  
};

export default actionCreators;