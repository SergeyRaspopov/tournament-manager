import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/Category/actionCreators';

import { Link } from 'react-router-dom';
import { Button } from 'primereact/button';
import Input from '../../components/UI/Input';

class Categories extends React.Component {
    state = {
        //form: {
        //    userName: {
        //        id: 'userName',
        //        name: 'User',
        //        type: 'text',
        //        placeholder: 'User Name',
        //        icon: 'pi pi-user',
        //        value: '',
        //        rules: [],
        //        error: '',
        //        showErrors: false
        //    }
        //}
    }

    //handleInput = (event, field) => {
    //    const updatedForm = { ...this.state.form };
    //    const updatedField = { ...updatedForm[field] };
    //    updatedField.value = event.target.value;
    //    updatedForm[field] = updatedField;
    //    this.setState({
    //        form: updatedForm
    //    });
    //}


    render() {
        //const inputs = Object.keys(this.state.form).map(field => <Input key={field} {...this.state.form[field]} onChange={(event) => this.handleInput(event, field)} />);

        return (
            <div>
                <h3>Categories</h3>
                <div>
                    Ages:

                </div>
            </div>);
    }
}

export default connect(
    state => state.category,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Categories);