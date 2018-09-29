import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/Auth/actionCreators';

import { Button } from 'primereact/button';
import Input from '../../components/UI/Input';

class Register extends React.Component {
    state = {
        form: {
            userName: {
                id: 'userName',
                name: 'User',
                type: 'text',
                placeholder: 'User Name',
                icon: 'pi pi-user',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            emailAddress: {
                id: 'emailAddress',
                name: 'Email Address',
                type: 'email',
                placeholder: 'Email Address',
                icon: 'pi pi-mail',
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
                icon: 'pi pi-lock',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            confirmPassword: {
                id: 'confirmPassword',
                name: 'Confirm Password',
                type: 'password',
                placeholder: 'Password',
                icon: 'pi pi-lock',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            }
        }
    }

    componentDidUpdate(prevProps) {
        if (prevProps.isRegistering && !this.props.isRegistering && this.props.isRegistered)
            this.props.history.replace('/login');
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

    handleRegister = (event) => {
        event.preventDefault();
        this.props.register(this.state.form.userName.value, this.state.form.emailAddress.value,
            this.state.form.password.value, this.state.form.confirmPassword.value);
    }

    render() {
        const inputs = Object.keys(this.state.form).map(field => <Input key={field} {...this.state.form[field]} onChange={(event) => this.handleInput(event, field)} />);

        return (
            <div>
                <form className="login-form" onSubmit={this.handleRegister}>
                    <h3>Register</h3>
                    {inputs}
                    <div className="form-buttons">
                        <Button label="Register" />
                    </div>
                </form>
            </div>);
    }
}

export default connect(
    state => state.auth,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Register);