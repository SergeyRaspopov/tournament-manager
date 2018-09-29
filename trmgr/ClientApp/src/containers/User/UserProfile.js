import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../store/User/actionCreators';

import { Dropdown } from 'primereact/dropdown';
import { AutoComplete } from 'primereact/autocomplete';

class UserProfile extends React.Component {
    state = {
        form: {
            country: {
                id: 'country',
                name: 'Country',
                type: 'dropdown',
                placeholder: 'Country',
                icon: '',
                value: null,
                rules: [],
                error: '',
                showErrors: false
            },
            province: {
                id: 'province',
                name: 'Province',
                type: 'dropdown',
                placeholder: 'Province',
                icon: '',
                value: null,
                rules: [],
                error: '',
                showErrors: false
            },
            city: {
                id: 'city',
                name: 'City',
                type: 'dropdown',
                placeholder: 'City',
                icon: '',
                value: null,
                rules: [],
                error: '',
                showErrors: false,
            }
        },
        citySuggestions: [],
        clubSuggestions: []
    }

    componentDidMount() {
        this.props.getCountries();
    }

    handleCountryChange = (e) => {
        this.props.getProvinces(e.value.id);
        this.setState({ form: { ...this.state.form, country: { ...this.state.form.country, value: e.value } } });
    }

    handleProvinceChange = (e) => {
        this.props.getCities(e.value.id);
        this.setState({ form: { ...this.state.form, province: { ...this.state.form.province, value: e.value } } });
    }

    handleCityChange = (e) => {
        this.setState({ form: { ...this.state.form, city: { ...this.state.form.city, value: e.value } } });
    }

    handleCitySuggestion = (e) => {
        const suggestions = this.props.cities ? this.props.cities.filter((city) => city.name.toLowerCase().startsWith(e.query.toLowerCase())) : null;
        this.setState({ citySuggestions: suggestions.map(c => c.name) });
    }

    handleClubChange = (e) => {

    }

    handleClubSuggestion = (e) => {

    }

    render() {
        return (
            <div>
                <h3>User Profile</h3>
                <form>
                    <Dropdown options={this.props.countries} optionLabel="name" placeholder="Select a Country" style={{ width: '100%' }}
                        onChange={this.handleCountryChange} value={this.state.form.country.value}

                    />
                    <Dropdown options={this.props.provinces} optionLabel="name" placeholder="Select a Province" style={{ width: '100%' }}
                        onChange={this.handleProvinceChange} value={this.state.form.province.value}
                    />
                    <AutoComplete suggestions={this.state.citySuggestions} style={{ width: '100%' }}
                        onChange={this.handleCityChange} value={this.state.form.city.value}
                        completeMethod={this.handleCitySuggestion}
                    />
                    <AutoComplete suggestions={this.state.clubSuggestions}
                        onChange={} value={}
                        completeMethod={}
                    />
                </form>
            </div>);
    }
}

export default connect(
    state => state.user,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserProfile);