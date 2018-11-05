import * as at from './actionTypes';

const initialState = {
    isLoadingCountries: false,
    isLoadingProvinces: false,
    isLoadingCities: false,
    loadingCountiesError: '',
    loadingProvincesError: '',
    loadingCitiesError: '',
    countries: [],
    provinces: [],
    cities: []
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case at.REQUEST_COUNTRIES:
            return { ...state, isLoadingCountries: true };
        case at.RECEIVE_COUNTRIES:
            return { ...state, isLoadingCountries: false, loadingCountiesError: '', countries: action.countries };
        case at.RECEIVE_COUNTRIES_ERROR:
            return { ...state, isLoadingCountries: false, loadingCountiesError: action.error };

        case at.REQUEST_PROVINCES:
            return { ...state, isLoadingProvinces: true };
        case at.RECEIVE_PROVINCES:
            return { ...state, isLoadingProvinces: false, loadingProvincesError: '', provinces: action.provinces };
        case at.RECEIVE_PROVINCES_ERROR:
            return { ...state, isLoadingProvinces: false, loadingProvincesError: action.error };

        case at.REQUEST_CITIES:
            return { ...state, isLoadingCities: true };
        case at.RECEIVE_CITIES:
            return { ...state, isLoadingCities: false, loadingCitiesError: '', cities: action.cities };
        case at.RECIEVE_CITIES_ERROR:
            return { ...state, isLoadingCities: false, loadingCitiesError: action.error };

        default:
            return state;
    }
};

export default reducer;