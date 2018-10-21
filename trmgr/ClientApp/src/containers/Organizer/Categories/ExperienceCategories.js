import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../../store/Category/actionCreators';

class ExperienceCategories extends React.Component {
    state = {
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
                <h3>Levels</h3>
                <div>

                </div>
            </div>);
    }
}

export default connect(
    state => state.category,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(ExperienceCategories);