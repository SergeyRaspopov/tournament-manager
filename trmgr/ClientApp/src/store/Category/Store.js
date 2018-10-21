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

    ageCategoryGroups: [],
    experienceCategories: [],
    genderCategories: [],
    weightCategories: [],

    error: ''
};

const reducer = (state = initialState, action) => {
    let groups;
    let group;
    let gidx;
    let cidx;
    let categories;
    let category;
    switch (action.type) {
        case at.REQUEST_AGE_CATEGORIES:
            return { ...state, isGettingAgeCategories: true };
        case at.RECEIVE_AGE_CATEGORIES:
            return { ...state, isGettingAgeCategories: false, getAgeCategoriesError: '', ageCategoryGroups: action.ageCategoryGroups };
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

        case at.REQUEST_ADD_AGE_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_ADD_AGE_CATEGORY_GROUP:
            return { ...state, ageCategoryGroups: state.ageCategoryGroups.concat(action.added) };
        case at.RECEIVE_ADD_AGE_CATEGORY_GROUP_ERROR:
            return { ...state };
        //===================== Add age category to a group
        case at.REQUEST_ADD_AGE_CATEGORY:
            return { ...state };
        case at.RECEIVE_ADD_AGE_CATEGORY:
            gidx = state.ageCategoryGroups.findIndex(g => g.id === action.added.ageCategoryGroupId);
            groups = [...state.ageCategoryGroups];
            group = { ...groups[gidx] };
            group.ageCategories = group.ageCategories ? group.ageCategories.concat(action.added) : [action.added];
            groups[gidx] = group;
            return { ...state, ageCategoryGroups: groups };
        case at.RECEIVE_ADD_AGE_CATEGORY_ERROR:
            return { ...state, error: action.error };
        //==================== Update age category group (just the name)
        case at.REQUEST_UPDATE_AGE_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_UPDATE_AGE_CATEGORY_GROUP:
            gidx = state.ageCategoryGroups.findIndex(g => g.id === action.updated.id);
            groups = [...state.ageCategoryGroups];
            group = { ...groups[gidx] };
            group.name = action.updated.name;
            groups[gidx] = group;
            return { ...state, ageCategoryGroups: groups };
        case at.RECEIVE_UPDATE_AGE_CATEGORY_GROUP_ERROR:
            return { ...state };
        //===================== Delete age category group
        case at.REQUEST_DELETE_AGE_CATEGORY_GROUP:
            return state;
        case at.RECEIVE_DELETE_AGE_CATEGORY_GROUP:
            return { ...state, ageCategoryGroups: state.ageCategoryGroups.filter(g => g.id !== action.deleted.id) };
        case at.RECEIVE_DELETE_AGE_CATEGORY_GROUP_ERROR:
            return state;
        //=================== Update age category group
        case at.REQUEST_UPDATE_AGE_CATEGORY:
            return {...state};
        case at.RECEIVE_UPDATE_AGE_CATEGORY:
            gidx = state.ageCategoryGroups.findIndex(g => g.id === action.updated.ageCategoryGroupId);
            groups = [...state.ageCategoryGroups];
            group = { ...groups[gidx] };
            cidx = group.ageCategories.findIndex(c => c.id === action.updated.id);
            categories = [...group.ageCategories];
            categories[cidx] = action.updated;
            group.ageCategories = categories;
            groups[gidx] = group;
            return {...state, ageCategoryGroups: groups};
        case at.RECEIVE_UPDATE_AGE_CATEGORY_ERROR:
            return { ...state };
        //====================== Delete age category
        case at.REQUEST_DELETE_AGE_CATEGORY:
            return { ...state };
        case at.RECEIVE_DELETE_AGE_CATEGORY:
            gidx = state.ageCategoryGroups.findIndex(g => g.id === action.deleted.ageCategoryGroupId);
            groups = [...state.ageCategoryGroups];
            group = { ...groups[gidx] };
            group.ageCategories = group.ageCategories.filter(c => c.id !== action.deleted.id);
            groups[gidx] = group;
            return { ...state, ageCategoryGroups: groups };
        case at.RECEIVE_DELETE_AGE_CATEGORY_ERROR:
            return { ...state };


        default:
            return state;
    }
};

export default reducer;