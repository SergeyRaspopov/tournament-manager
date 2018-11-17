import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/Address/actionCreators';


class UserProfile extends React.Component {
    state = {
        country: null,
        province: null,
        city: '',
        club: '',
        citySuggestions: [],
        clubSuggestions: []
    }

    componentDidMount() {
        this.props.getCountries();
    }

    handleCountryChange = (e) => {
        this.props.getProvinces(e.value.id);
        this.setState({ country: e.value });
    }

    handleProvinceChange = (e) => {
        this.props.getCities(e.value.id);
        this.setState({ province: e.value });
    }

    handleCityChange = (e) => {
        this.setState({ city: e.value });
    }

    handleCitySuggestion = (e) => {
        const suggestions = this.props.cities ? this.props.cities.filter((city) => city.name.toLowerCase().startsWith(e.query.toLowerCase())) : null;
        this.setState({ citySuggestions: suggestions.map(c => c.name) });
    }

    handleClubChange = (e) => {
        this.setState({ club: e.value})
    }

    handleClubSuggestion = (e) => {

    }

    render() {
        return (
            <div>
                <h3>User Profile</h3>
                <form>
                    
                </form>
            </div>);
    }
}

export default connect(
    state => state.user,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserProfile);