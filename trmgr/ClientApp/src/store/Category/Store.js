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
    experienceCategoryGroups: [],
    genderCategoryGroups: [],
    weightCategoryGroups: [],

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
            return { ...state, isGettingExperienceCategories: false, getExperienceCategoriesError: '', experienceCategoryGroups: action.experienceCategories};
        case at.RECEIVE_EXPERIENCE_CATEGORIES_ERROR:
            return { ...state, isGettingExperienceCategories: false, getExperienceCategoriesError: action.error };

        case at.REQUEST_GENDER_CATEGORIES:
            return { ...state, isGettingGenderCategories: true};
        case at.RECEIVE_GENDER_CATEGORIES:
            return { ...state, isGettingGenderCategories: false, getGenderCategoriesError: '', genderCategoryGroups: action.genderCategories };
        case at.RECEIVE_GENDER_CATEGORIES_ERROR:
            return { ...state, isGettingGenderCategories: false, getGenderCategoriesError: action.error };
        
        case at.REQUEST_WEIGHT_CATEGORIES:
            return { ...state, isGettingWeightCategories: true };
        case at.RECEIVE_WEIGHT_CATEGORIES:
            return { ...state, isGettingWeightCategories: false, getWeightCategoriesError: '', weightCategoryGroups: action.weightCategories };
        case at.RECEIVE_WEIGHT_CATEGORIES_ERROR:
            return { ...state, isGettingWeightCategories: false, getWeightCategoriesError: action.error };

        //===================== Add group
        case at.REQUEST_ADD_AGE_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_ADD_AGE_CATEGORY_GROUP:
            return { ...state, ageCategoryGroups: state.ageCategoryGroups.concat(action.added) };
        case at.RECEIVE_ADD_AGE_CATEGORY_GROUP_ERROR:
            return { ...state };

        case at.REQUEST_ADD_EXPERIENCE_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_ADD_EXPERIENCE_CATEGORY_GROUP:
            return { ...state, experienceCategoryGroups: state.experienceCategoryGroups.concat(action.added) };
        case at.RECEIVE_ADD_EXPERIENCE_CATEGORY_GROUP_ERROR:
            return { ...state };

        case at.REQUEST_ADD_GENDER_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_ADD_GENDER_CATEGORY_GROUP:
            return { ...state, genderCategoryGroups: state.genderCategoryGroups.concat(action.added) };
        case at.RECEIVE_ADD_GENDER_CATEGORY_GROUP_ERROR:
            return { ...state };

        case at.REQUEST_ADD_WEIGHT_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_ADD_WEIGHT_CATEGORY_GROUP:
            return { ...state, weightCategoryGroups: state.weightCategoryGroups.concat(action.added) };
        case at.RECEIVE_ADD_WEIGHT_CATEGORY_GROUP_ERROR:
            return { ...state };

        //===================== Add category to a group
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

        case at.REQUEST_ADD_EXPERIENCE_CATEGORY:
            return { ...state };
        case at.RECEIVE_ADD_EXPERIENCE_CATEGORY:
            gidx = state.experienceCategoryGroups.findIndex(g => g.id === action.added.experienceCategoryGroupId);
            groups = [...state.experienceCategoryGroups];
            group = { ...groups[gidx] };
            group.experienceCategories = group.experienceCategories ? group.experienceCategories.concat(action.added) : [action.added];
            groups[gidx] = group;
            return { ...state, experienceCategoryGroups: groups };
        case at.RECEIVE_ADD_EXPERIENCE_CATEGORY_ERROR:
            return { ...state, error: action.error };

        case at.REQUEST_ADD_GENDER_CATEGORY:
            return { ...state };
        case at.RECEIVE_ADD_GENDER_CATEGORY:
            gidx = state.genderCategoryGroups.findIndex(g => g.id === action.added.genderCategoryGroupId);
            groups = [...state.genderCategoryGroups];
            group = { ...groups[gidx] };
            group.genderCategories = group.genderCategories ? group.genderCategories.concat(action.added) : [action.added];
            groups[gidx] = group;
            return { ...state, genderCategoryGroups: groups };
        case at.RECEIVE_ADD_GENDER_CATEGORY_ERROR:
            return { ...state, error: action.error };

        case at.REQUEST_ADD_WEIGHT_CATEGORY:
            return { ...state };
        case at.RECEIVE_ADD_WEIGHT_CATEGORY:
            gidx = state.weightCategoryGroups.findIndex(g => g.id === action.added.weightCategoryGroupId);
            groups = [...state.weightCategoryGroups];
            group = { ...groups[gidx] };
            group.weightCategories = group.weightCategories ? group.weightCategories.concat(action.added) : [action.added];
            groups[gidx] = group;
            return { ...state, weightCategoryGroups: groups };
        case at.RECEIVE_ADD_WEIGHT_CATEGORY_ERROR:
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

        case at.REQUEST_UPDATE_EXPERIENCE_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_GROUP:
            gidx = state.experienceCategoryGroups.findIndex(g => g.id === action.updated.id);
            groups = [...state.experienceCategoryGroups];
            group = { ...groups[gidx] };
            group.name = action.updated.name;
            groups[gidx] = group;
            return { ...state, experienceCategoryGroups: groups };
        case at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_GROUP_ERROR:
            return { ...state };

        case at.REQUEST_UPDATE_GENDER_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_UPDATE_GENDER_CATEGORY_GROUP:
            gidx = state.genderCategoryGroups.findIndex(g => g.id === action.updated.id);
            groups = [...state.genderCategoryGroups];
            group = { ...groups[gidx] };
            group.name = action.updated.name;
            groups[gidx] = group;
            return { ...state, genderCategoryGroups: groups };
        case at.RECEIVE_UPDATE_GENDER_CATEGORY_GROUP_ERROR:
            return { ...state };

        case at.REQUEST_UPDATE_WEIGHT_CATEGORY_GROUP:
            return { ...state };
        case at.RECEIVE_UPDATE_WEIGHT_CATEGORY_GROUP:
            gidx = state.weightCategoryGroups.findIndex(g => g.id === action.updated.id);
            groups = [...state.weightCategoryGroups];
            group = { ...groups[gidx] };
            group.name = action.updated.name;
            groups[gidx] = group;
            return { ...state, weightCategoryGroups: groups };
        case at.RECEIVE_UPDATE_WEIGHT_CATEGORY_GROUP_ERROR:
            return { ...state };

        //===================== Delete category group
        case at.REQUEST_DELETE_AGE_CATEGORY_GROUP:
            return state;
        case at.RECEIVE_DELETE_AGE_CATEGORY_GROUP:
            return { ...state, ageCategoryGroups: state.ageCategoryGroups.filter(g => g.id !== action.deleted.id) };
        case at.RECEIVE_DELETE_AGE_CATEGORY_GROUP_ERROR:
            return state;

        case at.REQUEST_DELETE_EXPERIENCE_CATEGORY_GROUP:
            return state;
        case at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_GROUP:
            return { ...state, experienceCategoryGroups: state.experienceCategoryGroups.filter(g => g.id !== action.deleted.id) };
        case at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_GROUP_ERROR:
            return state;

        case at.REQUEST_DELETE_GENDER_CATEGORY_GROUP:
            return state;
        case at.RECEIVE_DELETE_GENDER_CATEGORY_GROUP:
            return { ...state, genderCategoryGroups: state.genderCategoryGroups.filter(g => g.id !== action.deleted.id) };
        case at.RECEIVE_DELETE_GENDER_CATEGORY_GROUP_ERROR:
            return state;

        case at.REQUEST_DELETE_WEIGHT_CATEGORY_GROUP:
            return state;
        case at.RECEIVE_DELETE_WEIGHT_CATEGORY_GROUP:
            return { ...state, weightCategoryGroups: state.weightCategoryGroups.filter(g => g.id !== action.deleted.id) };
        case at.RECEIVE_DELETE_WEIGHT_CATEGORY_GROUP_ERROR:
            return state;

        //=================== Update category group
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

        case at.REQUEST_UPDATE_EXPERIENCE_CATEGORY:
            return { ...state };
        case at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY:
            gidx = state.experienceCategoryGroups.findIndex(g => g.id === action.updated.experienceCategoryGroupId);
            groups = [...state.experienceCategoryGroups];
            group = { ...groups[gidx] };
            cidx = group.experienceCategories.findIndex(c => c.id === action.updated.id);
            categories = [...group.experienceCategories];
            categories[cidx] = action.updated;
            group.experienceCategories = categories;
            groups[gidx] = group;
            return { ...state, experienceCategoryGroups: groups };
        case at.RECEIVE_UPDATE_EXPERIENCE_CATEGORY_ERROR:
            return { ...state };

        case at.REQUEST_UPDATE_GENDER_CATEGORY:
            return { ...state };
        case at.RECEIVE_UPDATE_GENDER_CATEGORY:
            gidx = state.genderCategoryGroups.findIndex(g => g.id === action.updated.genderCategoryGroupId);
            groups = [...state.genderCategoryGroups];
            group = { ...groups[gidx] };
            cidx = group.genderCategories.findIndex(c => c.id === action.updated.id);
            categories = [...group.genderCategories];
            categories[cidx] = action.updated;
            group.genderCategories = categories;
            groups[gidx] = group;
            return { ...state, genderCategoryGroups: groups };
        case at.RECEIVE_UPDATE_GENDER_CATEGORY_ERROR:
            return { ...state };

        case at.REQUEST_UPDATE_WEIGHT_CATEGORY:
            return { ...state };
        case at.RECEIVE_UPDATE_WEIGHT_CATEGORY:
            gidx = state.weightCategoryGroups.findIndex(g => g.id === action.updated.weightCategoryGroupId);
            groups = [...state.weightCategoryGroups];
            group = { ...groups[gidx] };
            cidx = group.weightCategories.findIndex(c => c.id === action.updated.id);
            categories = [...group.weightCategories];
            categories[cidx] = action.updated;
            group.weightCategories = categories;
            groups[gidx] = group;
            return { ...state, weightCategoryGroups: groups };
        case at.RECEIVE_UPDATE_WEIGHT_CATEGORY_ERROR:
            return { ...state };

        //====================== Delete category
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

        case at.REQUEST_DELETE_EXPERIENCE_CATEGORY:
            return { ...state };
        case at.RECEIVE_DELETE_EXPERIENCE_CATEGORY:
            gidx = state.experienceCategoryGroups.findIndex(g => g.id === action.deleted.experienceCategoryGroupId);
            groups = [...state.experienceCategoryGroups];
            group = { ...groups[gidx] };
            group.experienceCategories = group.experienceCategories.filter(c => c.id !== action.deleted.id);
            groups[gidx] = group;
            return { ...state, experienceCategoryGroups: groups };
        case at.RECEIVE_DELETE_EXPERIENCE_CATEGORY_ERROR:
            return { ...state };

        case at.REQUEST_DELETE_GENDER_CATEGORY:
            return { ...state };
        case at.RECEIVE_DELETE_GENDER_CATEGORY:
            gidx = state.genderCategoryGroups.findIndex(g => g.id === action.deleted.genderCategoryGroupId);
            groups = [...state.genderCategoryGroups];
            group = { ...groups[gidx] };
            group.genderCategories = group.genderCategories.filter(c => c.id !== action.deleted.id);
            groups[gidx] = group;
            return { ...state, genderCategoryGroups: groups };
        case at.RECEIVE_DELETE_GENDER_CATEGORY_ERROR:
            return { ...state };

        case at.REQUEST_DELETE_WEIGHT_CATEGORY:
            return { ...state };
        case at.RECEIVE_DELETE_WEIGHT_CATEGORY:
            gidx = state.weightCategoryGroups.findIndex(g => g.id === action.deleted.weightCategoryGroupId);
            groups = [...state.weightCategoryGroups];
            group = { ...groups[gidx] };
            group.weightCategories = group.weightCategories.filter(c => c.id !== action.deleted.id);
            groups[gidx] = group;
            return { ...state, weightCategoryGroups: groups };
        case at.RECEIVE_DELETE_WEIGHT_CATEGORY_ERROR:
            return { ...state };


        default:
            return state;
    }
};

export default reducer;