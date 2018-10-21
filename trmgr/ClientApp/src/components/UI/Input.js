import React from 'react';
import { InputText } from 'primereact/inputtext';

class Input extends React.Component {
    render() {
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

export default Input;