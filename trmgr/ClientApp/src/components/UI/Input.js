import React from 'react';
import { InputText } from 'primereact/inputtext';
import { AutoComplete } from 'primereact/autocomplete';
import { Calendar } from 'primereact/calendar';

class Input extends React.Component {
    render() {
        if (this.props.type === "auto-complete") {
            return (
                <div className="form-input-field">
                    <AutoComplete value={this.props.value} onChange={this.props.onChange} suggestions={this.props.suggestions}
                        completeMethod={this.props.completeMethod}
                    />
                </div>
                );
        }
        else if (this.props.type === "date") {
            return (
                <div className="form-input-field">
                    <label htmlFor={this.props.id}>{this.props.name}</label>
                    <Calendar value={this.props.value} onChange={this.props.onChange} placeholder={this.props.placeholder} />
                </div>
            );
        }
        else {
            return (
                <div className="form-input-field">
                    <label htmlFor={this.props.id}>{this.props.name}</label>
                    <div className="p-inputgroup">
                        {this.props.icon ? (<span className="p-inputgroup-addon">
                            <i className={this.props.icon} />
                        </span>) : null}

                        <InputText type={this.props.type} placeholder={this.props.placeholder}
                            onChange={this.props.onChange} value={this.props.value} keyfilter={this.props.keyfilter}
                            ref={this.props.inputRef}
                        />
                    </div>
                </div>
            );
        }
    }
}

export default Input;