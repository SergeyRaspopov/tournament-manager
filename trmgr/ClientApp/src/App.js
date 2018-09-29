import React from 'react';
import { Route, Switch, Redirect } from 'react-router';

import Login from './containers/Auth/Login';
import Register from './containers/Auth/Register';

const app = (props) => (
    <Switch>
        <Route path="/login" component={Login} />
        <Route path="/register" component={Register} />
        <Redirect to="/login" />
    </Switch>
);

export default app;
