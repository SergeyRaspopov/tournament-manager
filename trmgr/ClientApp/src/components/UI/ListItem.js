import React from 'react';

const listItem = (props) => (
    <div className="list-item" >
        <div className="list-item-content pointable" onClick={props.onItemClick}>
            {props.primaryText}
            <div className="secondary-text">{props.secondaryText}</div>
        </div>
        <div className="list-item-controls">
            <i className="pi pi-trash pointable" onClick={props.onDeleteClick} />
        </div>
    </div>
);

export default listItem;