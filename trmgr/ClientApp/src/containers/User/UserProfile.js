import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/User/actionCreators';

import { Dropdown } from 'primereact/dropdown';

class UserProfile extends React.Component {
    componentDidMount() {
        this.props.getCountries();
    }

    render() {
        return (
            <div>
                <h3>User Profile</h3>
                <form>
                    <Dropdown />
                </form>
            </div>);
    }
}

export default connect(
    state => state.user,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserProfile);