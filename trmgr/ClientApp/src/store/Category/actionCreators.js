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
    getExperienceCategoryGroups: () => async (dispatch) => {
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
    addExperienceCategoryGroup: (groupName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_EXPERIENCE_CATEGORY_GROUP });
            const group = { name: groupName };
            const url = `api/Organizer/AddExperienceCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_EXPERIENCE_CATEGORY_GROUP, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_EXPERIENCE_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    addGenderCategoryGroup: (groupName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_GENDER_CATEGORY_GROUP });
            const group = { name: groupName };
            const url = `api/Organizer/AddGenderCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_GENDER_CATEGORY_GROUP, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_GENDER_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    addWeightCategoryGroup: (groupName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_WEIGHT_CATEGORY_GROUP });
            const group = { name: groupName };
            const url = `api/Organizer/AddWeightCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_WEIGHT_CATEGORY_GROUP, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_WEIGHT_CATEGORY_GROUP_ERROR, error: err });
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
    addExperienceCategory: (groupId, categoryName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_EXPERIENCE_CATEGORY_GROUP });
            const category = {
                experienceCategoryGroupId: groupId,
                name: categoryName
            };
            const url = `api/organizer/AddExperienceCategory`;
            const response = await fetch(url, { body: JSON.stringify(category), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_EXPERIENCE_CATEGORY, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_EXPERIENCE_CATEGORY_ERROR, error: err });
        }
    },
    addGenderCategory: (groupId, categoryName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_GENDER_CATEGORY });
            const category = {
                experienceCategoryGroupId: groupId,
                name: categoryName
            };
            const url = `api/organizer/AddGenderCategory`;
            const response = await fetch(url, { body: JSON.stringify(category), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_GENDER_CATEGORY, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_GENDER_CATEGORY_ERROR, error: err });
        }
    },
    addWeightCategory: (groupId, categoryName, minWeight, maxWeight) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_ADD_WEIGHT_CATEGORY });
            const category = {
                weightCategoryGroupId: groupId,
                name: categoryName,
                minWeight: minWeight,
                maxWeight: maxWeight
            };
            const url = `api/organizer/AddWeightCategory`;
            const response = await fetch(url, { body: JSON.stringify(category), method: 'POST', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_ADD_WEIGHT_CATEGORY, added: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_ADD_WEIGHT_CATEGORY_ERROR, error: err });
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
    updateExperienceCategoryGroup: (groupId, newName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_EXPERIENCE_CATEGORY_GROUP });
            const group = { id: groupId, name: newName };
            const url = `/api/organizer/UpdateExperienceCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_GROUP, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    updateGenderCategoryGroup: (groupId, newName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_GENDER_CATEGORY_GROUP });
            const group = { id: groupId, name: newName };
            const url = `/api/organizer/UpdateGenderCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_GENDER_CATEGORY_GROUP, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_GENDER_CATEGORY_GROUP_ERROR, error: err });
        }
    },
    updateWeightCategoryGroup: (groupId, newName) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_WEIGHT_CATEGORY_GROUP });
            const group = { id: groupId, name: newName };
            const url = `/api/organizer/UpdateWeightCategoryGroup`;
            const response = await fetch(url, { body: JSON.stringify(group), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_WEIGHT_CATEGORY_GROUP, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_WEIGHT_CATEGORY_GROUP_ERROR, error: err });
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
    updateExperienceCategory: (categoryId, name, groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_EXPERIENCE_CATEGORY });
            const body = {
                id: categoryId,
                name: name,
                experienceCategoryGroupId: groupId
            };
            const url = `/api/organizer/UpdateExperienceCategory`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_ERROR });
        }
    },
    updateGenderCategory: (categoryId, name, groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_GENDER_CATEGORY });
            const body = {
                id: categoryId,
                name: name,
                genderCategoryGroupId: groupId
            };
            const url = `/api/organizer/UpdateGenderCategory`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_GENDER_CATEGORY, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_GENDER_CATEGORY_ERROR });
        }
    },
    updateWeightCategory: (categoryId, name, minWeight, maxWeight, groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_UPDATE_WEIGHT_CATEGORY });
            const body = {
                id: categoryId,
                name: name,
                minWeight: minWeight,
                maxWeight: maxWeight,
                weightCategoryGroupId: groupId
            };
            const url = `/api/organizer/UpdateWeightCategory`;
            const response = await fetch(url, { body: JSON.stringify(body), method: 'PUT', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_UPDATE_WEIGHT_CATEGORY, updated: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_UPDATE_WEIGHT_CATEGORY_ERROR });
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
    deleteExperienceCategoryGroup: (groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_EXPERIENCE_CATEGORY_GROUP });
            const url = `/api/organizer/DeleteExperienceCategoryGroup`;
            const response = await fetch(url, { body: groupId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_GROUP, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_GROUP_ERROR });
        }
    },
    deleteGenderCategoryGroup: (groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_GENDER_CATEGORY_GROUP });
            const url = `/api/organizer/DeleteGenderCategoryGroup`;
            const response = await fetch(url, { body: groupId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_GENDER_CATEGORY_GROUP, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_GENDER_CATEGORY_GROUP_ERROR });
        }
    },
    deleteWeightCategoryGroup: (groupId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_WEIGHT_CATEGORY_GROUP });
            const url = `/api/organizer/DeleteWeightCategoryGroup`;
            const response = await fetch(url, { body: groupId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_WEIGHT_CATEGORY_GROUP, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_WEIGHT_CATEGORY_GROUP_ERROR });
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
    },
    deleteExperienceCategory: (categoryId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_AGE_CATEGORY });
            const url = `/api/organizer/DeleteExperienceCategory`;
            const response = await fetch(url, { body: categoryId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_EXPERIENCE_CATEGORY, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_ERROR });
        }
    },
    deleteGenderCategory: (categoryId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_GENDER_CATEGORY });
            const url = `/api/organizer/DeleteGenderCategory`;
            const response = await fetch(url, { body: categoryId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_GENDER_CATEGORY, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_GENDER_CATEGORY_ERROR });
        }
    },
    deleteWeightCategory: (categoryId) => async (dispatch) => {
        try {
            dispatch({ type: at.REQUEST_DELETE_WEIGHT_CATEGORY });
            const url = `/api/organizer/DeleteWeightCategory`;
            const response = await fetch(url, { body: categoryId, method: 'DELETE', headers: headers });
            const payload = await response.json();
            dispatch({ type: at.RECEIVE_DELETE_WEIGHT_CATEGORY, deleted: payload });
        }
        catch (err) {
            dispatch({ type: at.RECEIVE_DELETE_WEIGHT_CATEGORY_ERROR });
        }
    }

};

export default actionCreators;