import React from 'react';
import { TextField } from 'office-ui-fabric-react/lib/TextField';
import { DatePicker } from 'office-ui-fabric-react/lib/DatePicker';

class Input extends React.Component {
    render() {
        if (this.props.type === "date") {
            return (
                <div className="form-input-field">
                    <DatePicker label={this.props.placeholder} onSelectDate={this.props.onChange} value={this.props.value} />
                </div>
            );
        }
        else {
            return (
                <div className="form-input-field">
                    <TextField type={this.props.type} label={this.props.name} iconProps={{ iconName: this.props.icon }}
                        value={this.props.value} onChange={this.props.onChange} />
                </div>
            );
        }
    }
}

export default Input;