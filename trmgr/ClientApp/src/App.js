import React from 'react';
import { Route, Switch, Redirect } from 'react-router';

import Login from './containers/Auth/Login';
import Register from './containers/Auth/Register';
import UserProfile from './containers/User/UserProfile';

import OrganizerDashboard from './containers/Organizer/Dashboard';
import Categories from './containers/Organizer/Categories';

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            user: JSON.parse(localStorage.getItem('user'))
        };
    }
    
    render() {
        if (this.state.user && this.state.user.roles && this.state.user.roles.length > 0) {
            if (this.state.user.roles.includes('Organizer')) {
                <Switch>
                    <Route path="/organizer-dashboard" component={OrganizerDashboard} />
                    <Route path="/categories" component={Categories} />
                    <Redirect to="/organazier-dashboard"/>
                </Switch>
            }
            else if (this.state.user.roles.includes('Competitor')) {
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

export default App;
