import * as at from './actionTypes';

const headers = { 'Content-Type': 'application/json' };

const actionCreators = {
    getAgeCategories: () => async => {
        try {
            dispatch({ type: at.REQUEST_AGE_CATEGORIES });
            const url = `api/Organizer/AgeCategories`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_AGE_CATEGORIES, ageCategories: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_AGE_CATEGORIES_ERROR, error: err });
        }
    },
    getExperienceCategories: () => async => {
        try {
            dispatch({ type: at.REQUEST_EXPERIENCE_CATEGORIES });
            const url = `api/Organizer/ExperienceCategories`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_EXPERIENCE_CATEGORIES, experienceCategories: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_EXPERIENCE_CATEGORIES_ERROR, error: err });
        }
    },
    getGenderCategories: () => async => {
        try {
            dispatch({ type: at.REQUEST_GENDER_CATEGORIES });
            const url = `api/Organizer/GenderCategories`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_GENDER_CATEGORIES, genderCategories: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_GENDER_CATEGORIES_ERROR, error: err });
        }
    },
    getWeightCategories: () => async => {
        try {
            dispatch({ type: at.REQUEST_WEIGHT_CATEGORIES });
            const url = `api/Organizer/WeightCategories`;
            const response = await fetch(url);
            const result = await response.json();
            dispatch({ type: at.RECEIVE_WEIGHT_CATEGORIES, weightCategories: result });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_WEIGHT_CATEGORIES_ERROR, error: err });
        }
    }

    //addAgeCategory: (category, minAge, maxAge) => async (dispatch) => {

    //},
    
    //signIn: (userName, password) => async (dispatch, getState) => {
    //    try {
    //        dispatch({ type: at.REQUEST_LOGIN });
    //        const body = { userName: userName, password: password };
    //        const url = `api/auth/login`;
    //        const response = await fetch(url, { body: JSON.stringify(body), method: 'POST', headers: headers });
    //        const result = await response.json();
    //        localStorage.setItem('user', JSON.stringify(result.user));
    //        dispatch({ type: at.RECEIVE_LOGIN });
    //    }
    //    catch (err) {
    //        dispatch({ type: at.RECEIVE_LOGIN_ERROR });
    //    }
    //}
};

export default actionCreators;