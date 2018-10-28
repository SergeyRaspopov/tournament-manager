import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../../store/Category/actionCreators';

class WeightCategories extends React.Component {
    

    render() {
        
        return (
            <div>
                <h3>Weights</h3>
                <div>
                </div>
            </div>);
    }
}

export default connect(
    state => state.category,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(WeightCategories);