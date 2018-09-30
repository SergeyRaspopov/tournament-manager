import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/User/actionCreators';

import { Dropdown } from 'primereact/dropdown';
import { AutoComplete } from 'primereact/autocomplete';

class Dashboard extends React.Component {
    render() {
        return (
            <div>
                <h3>Dashboard</h3>
                
            </div>);
    }
}

export default connect(
    state => state.user,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Dashboard);