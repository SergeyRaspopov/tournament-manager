import React from 'react';
import { Route, Switch, Redirect } from 'react-router';

import Login from './containers/Auth/Login';

const app = (props) => (
    <Switch>
        <Route path="/login" component={Login} />
        <Redirect to="/login" />
    </Switch>
);

export default app;
