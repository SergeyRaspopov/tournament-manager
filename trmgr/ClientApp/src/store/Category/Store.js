import * as at from './actionTypes';

const initialState = {
    isGettingAgeCategories: false,
    isGettingExperienceCategories: false,
    isGettingGenderCategories: false,
    isGettingWeightCategories: false,
    
    getAgeCategoriesError: '',
    getExperienceCategoriesError: '',
    getGenderCategoriesError: '',
    getWeightCategoriesError: '',

    ageCategories: [],
    experienceCategories: [],
    genderCategories: [],
    weightCategories: []
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case at.REQUEST_AGE_CATEGORIES:
            return { ...state, isGettingAgeCategories: true };
        case at.RECEIVE_AGE_CATEGORIES:
            return { ...state, isGettingAgeCategories: false, getAgeCategoriesError: '', ageCategories: action.ageCategories };
        case at.RECEIVE_AGE_CATEGORIES_ERROR:
            return { ...state, isGettingAgeCategories: false, getAgeCategoriesError: action.error };

        case at.REQUEST_EXPERIENCE_CATEGORIES:
            return { ...state, isGettingExperienceCategories: true};
        case at.RECEIVE_EXPERIENCE_CATEGORIES:
            return { ...state, isGettingExperienceCategories: false, getExperienceCategoriesError: '', experienceCategories: action.experienceCategories};
        case at.RECEIVE_EXPERIENCE_CATEGORIES_ERROR:
            return { ...state, isGettingExperienceCategories: false, getExperienceCategoriesError: action.error };

        case at.REQUEST_GENDER_CATEGORIES:
            return { ...state, isGettingGenderCategories: true};
        case at.RECEIVE_GENDER_CATEGORIES:
            return { ...state, isGettingGenderCategories: false, getGenderCategoriesError: '', genderCategories: action.genderCategories };
        case at.RECEIVE_GENDER_CATEGORIES_ERROR:
            return { ...state, isGettingGenderCategories: false, getGenderCategoriesError: action.error };
        
        case at.REQUEST_WEIGHT_CATEGORIES:
            return { ...state, isGettingWeightCategories: true };
        case at.RECEIVE_WEIGHT_CATEGORIES:
            return { ...state, isGettingWeightCategories: false, getWeightCategoriesError: '', weightCategories: action.weightCategories };
        case at.RECEIVE_WEIGHT_CATEGORIES_ERROR:
            return { ...state, isGettingWeightCategories: false, getWeightCategoriesError: action.error };

        default:
            return state;
    }
};

export default reducer;