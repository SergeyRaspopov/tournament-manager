import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/User/actionCreators';

import { Dropdown } from 'primereact/dropdown';
import { AutoComplete } from 'primereact/autocomplete';

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
                    <Dropdown options={this.props.countries} optionLabel="name" placeholder="Select a Country" style={{ width: '100%' }}
                        onChange={this.handleCountryChange} value={this.state.country}

                    />
                    <Dropdown options={this.props.provinces} optionLabel="name" placeholder="Select a Province" style={{ width: '100%' }}
                        onChange={this.handleProvinceChange} value={this.state.province}
                    />
                    <AutoComplete suggestions={this.state.citySuggestions}
                        onChange={this.handleCityChange} value={this.state.city}
                        completeMethod={this.handleCitySuggestion}
                    />
                    <AutoComplete suggestions={this.state.clubSuggestions}
                        onChange={this.handleClubChange} value={this.state.club}
                        completeMethod={this.handleClubSuggestion}
                    />
                </form>
            </div>);
    }
}

export default connect(
    state => state.user,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserProfile);