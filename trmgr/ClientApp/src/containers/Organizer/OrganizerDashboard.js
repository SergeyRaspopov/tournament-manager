﻿import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import tournamentActionCreators from '../../store/Tournament/actionCreators';
import addressActionCreators from '../../store/Address/actionCreators';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import Input from '../../components/UI/Input';

class OrganizerDashboard extends React.Component {
    state = {
        showEditTournamentModal: false,
        countrySuggestions: [],
        stateSuggestions: [],
        citySuggestions: [],
        form: {
            name: {
                id: 'tournament',
                name: 'Tournament Name',
                type: 'text',
                placeholder: 'Tournament Name',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            address: {
                id: 'address',
                name: 'Steet Address',
                type: 'text',
                placeholder: 'Street Address',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            city: {
                id: 'city',
                name: 'City',
                type: 'text',
                placeholder: 'City',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false,
                suggestions: []
            },
            province: {
                id: 'province',
                name: 'Province',
                type: 'text',
                placeholder: 'Province',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false,
                suggestions: []
            },
            country: {
                id: 'country',
                name: 'Country',
                type: 'text',
                placeholder: 'Country',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false,
                suggestions: []
            },
            date: {
                id: 'date',
                name: 'Date',
                type: 'date',
                placeholder: 'Date',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            registrationStart: {
                id: 'registrationStart',
                name: 'Registration Start',
                type: 'date',
                placeholder: 'Registration Start',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            registrationEnd: {
                id: 'registrationEnd',
                name: 'Registration End',
                type: 'date',
                placeholder: 'Registration End',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            }
        }
        
    }

    componentDidMount() {
        this.props.getTournaments();
        //this.props.getCountries();
    }

    handleNewTournamentClick = () => {
        this.setState({ showEditTournamentModal: true });
    }

    handleInput = (e, field) => {
        const updatedForm = { ...this.state.form };
        const updatedField = { ...updatedForm[field] };
        updatedField.value = e.target.value;
        updatedForm[field] = updatedField;
        this.setState({
            form: updatedForm
        });
    }

    handleSuggestCountry = (e) => {
        const countries = this.props.countries.filter(c => c.name.toLowerCase().startsWith(e.query.toLowerCase()));
        this.setState({ countrySuggestions: countries.map(c => c.name) });
    }

    handleSuggestState = (e) => {
        //const states = this.props.s
    }

    render() {
        const inputs = Object.keys(this.state.form).map(field => (
            <Input key={field} {...this.state.form[field]} onChange={(e) => this.handleInput(e, field)} />));

        //name street address
        // country => state => city
        // dates
        return (
            <div>
                <h3>Dashboard</h3>
                <Dialog visible={this.state.showEditTournamentModal} modal header="New Tournament" width="100%">
                    <form>
                        {inputs}
                        <div className="form-buttons">
                            <Button label="Save" className="p-button-success" />
                        </div>
                    </form>
                </Dialog>
                
                <Button icon="pi pi-plus" className="button-fab" onClick={this.handleNewTournamentClick} />
            </div>
        );
    }
}

export default connect(
    state => { return { ...state.tournament, ...state.address } },
    dispatch => bindActionCreators({...tournamentActionCreators, ...addressActionCreators }, dispatch)
)(OrganizerDashboard);