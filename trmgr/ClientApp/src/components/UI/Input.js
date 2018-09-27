import React from 'react';
import { InputText } from 'primereact/inputtext';

const input = (props) => {
    return (
        <div className="form-input-field">
            <label htmlFor={props.id}>{props.name}</label>
            <div className="p-inputgroup">
                <span className="p-inputgroup-addon">
                    <i className={props.icon} />
                </span>
                <InputText type={props.type} placeholder={props.placeholder} id={props.id} className="form-input"
                    onChange={props.onChange} value={props.value} />
            </div>
        </div>);
};

export default input;