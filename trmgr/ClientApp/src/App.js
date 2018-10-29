import React from 'react';
import { Route, Switch, Redirect, withRouter } from 'react-router';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from './store/Auth/actionCreators';


import MainNavBar from './components/Navigation/MainNavBar';
import Login from './containers/Auth/Login';
import Register from './containers/Auth/Register';
import UserProfile from './containers/User/UserProfile';

import OrganizerDashboard from './containers/Organizer/OrganizerDashboard';
import AgeCategories from './containers/Organizer/Categories/AgeCategories';
import ExperienceCategories from './containers/Organizer/Categories/ExperienceCategories';
import GenderCategories from './containers/Organizer/Categories/GenderCategories';
import WeightCategories from './containers/Organizer/Categories/WeightCategories';

class App extends React.Component {
    componentWillMount() {
        this.props.initAuth();
    }
    
    render() {
        if (this.props.user && this.props.user.roles && this.props.user.roles.length > 0) {
            if (this.props.user.roles.includes('Organizer')) {
                const navigationItems = [
                    { path: "/organizer-dashboard", text: "Home" },
                    { path: "/age-categories", text: "Ages" },
                    { path: "/experience-categories", text: "Levels" },
                    { path: "/gender-categories", text: "Genders" },
                    { path: "/weight-categories", text: "Weights" }
                ];

                return (
                    <div>
                        <MainNavBar items={navigationItems} />
                        <Switch>
                            <Route path="/organizer-dashboard" component={OrganizerDashboard} />
                            <Route path="/age-categories" component={AgeCategories} />
                            <Route path="/experience-categories" component={ExperienceCategories} />
                            <Route path="/gender-categories" component={GenderCategories} />
                            <Route path="/weight-categories" component={WeightCategories} />
                            <Redirect to="/age-categories" />
                        </Switch>
                    </div>
                );
            }
            else if (this.props.user.roles.includes('Competitor')) {
                return (
                    <Switch>
                        <Route path="/user-profile" component={UserProfile} />
                        <Redirect to="/user-profile" />
                    </Switch>
                );
            }
        }
        else {
            return (
                <Switch>
                    <Route path="/login" component={Login} />
                    <Route path="/register" component={Register} />
                    <Redirect to="/login" />
                </Switch>
            );
        }
    }
}

export default withRouter(connect(
    state => state.auth,
    dispatch => bindActionCreators(actionCreators, dispatch))(App));
