import * as at from './actionTypes';

const headers = { 'Content-Type': 'application/json' };

const actionCreators = {
    getAgeCategoryGroups: () => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_AGE_CATEGORIES });
            const url = `api/Organizer/AgeCategories`;
            const response = await fetch(url);
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_AGE_CATEGORIES, ageCategoryGroups: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_AGE_CATEGORIES_ERROR, error: err });
        }
    },
    getExperienceCategories: () => async (dispatch) => {
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
    getGenderCategories: () => async (dispatch) => {
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
    getWeightCategories: () => async (dispatch) => {
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
    },

    addAgeCategoryGroup: (groupName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_AGE_CATEGORY_GROUP });
            const group = { name: groupName };
            const url = `api/Organizer/AddAgeCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_AGE_CATEGORY_GROUP, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_AGE_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    addAgeCategory: (groupId, categoryName, minAge, maxAge) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_AGE_CATEGORY });
            const ageCategory = {
                ageCategoryGroupId: groupId,
                name: categoryName,
                minAge: minAge,
                maxAge: maxAge
            };
            const url = `api/organizer/AddAgeCategory`;
            const response = await fetch(url, { body: JSON.stringify(ageCategory), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_AGE_CATEGORY, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_AGE_CATEGORY_ERROR, error: err });
        }
    },
    updateAgeCategoryGroup: (groupId, newName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_AGE_CATEGORY_GROUP });
            const group = { id: groupId, name: newName };
            const url = `/api/organizer/UpdateAgeCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_AGE_CATEGORY_GROUP, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_AGE_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    updateAgeCategory: (categoryId, name, minAge, maxAge, groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_AGE_CATEGORY });
            const body = {
                id: categoryId,
                name: name,
                minAge: minAge,
                maxAge: maxAge,
                ageCategoryGroupId: groupId
            };
            const url = `/api/organizer/UpdateAgeCategory`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_AGE_CATEGORY, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_AGE_CATEGORY_ERROR });
        }
    },
    deleteAgeCategoryGroup: (groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_AGE_CATEGORY_GROUP });
            const url = `/api/organizer/DeleteAgeCategoryGroup`;
            const response = await fetch(url, { body: groupId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_AGE_CATEGORY_GROUP, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_AGE_CATEGORY_GROUP_ERROR });
        }
    },
    deleteAgeCategory: (categoryId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_AGE_CATEGORY });
            const url = `/api/organizer/DeleteAgeCategory`;
            const response = await fetch(url, { body: categoryId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_AGE_CATEGORY, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_AGE_CATEGORY_ERROR});
        }
    }
    
};

export default actionCreators;