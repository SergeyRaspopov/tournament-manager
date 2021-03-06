﻿import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/Auth/actionCreators';

import { Link } from 'react-router-dom';

import Input from '../../components/UI/Input';
import { PrimaryButton, ActionButton } from 'office-ui-fabric-react/lib/Button';

class Login extends React.Component {
    state = {
        form: {
            userName: {
                id: 'userName',
                name: 'User',
                type: 'text',
                placeholder: 'User Name',
                icon: 'Contact',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            password: {
                id: 'password',
                name: 'Password',
                type: 'password',
                placeholder: 'Password',
                icon: 'Lock',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            }
        }
    }

    handleInput = (event, field) => {
        const updatedForm = { ...this.state.form };
        const updatedField = { ...updatedForm[field] };
        updatedField.value = event.target.value;
        updatedForm[field] = updatedField;
        this.setState({
            form: updatedForm
        });
    }

    handleLogin = (event) => {
        event.preventDefault();
        this.props.signIn(this.state.form.userName.value, this.state.form.password.value);
    }

    render() {
        const inputs = Object.keys(this.state.form).map(field => <Input key={field} {...this.state.form[field]} onChange={(event) => this.handleInput(event, field)} />);

        return (
            <div>
                <form className="login-form" onSubmit={this.handleLogin}>
                    <h3>Login</h3>
                    {inputs}
                    <Link to="/register">Register</Link>
                    <div className="form-buttons">
                        <PrimaryButton type="submit">Login</PrimaryButton>
                    </div>
                </form>
            </div>);
    }
}

export default connect(
    state => state.auth,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Login);