import React from 'react';
import { IconButton } from 'office-ui-fabric-react/lib/Button';

const listItem = (props) => (
    <div className="list-item" >
        <div className="list-item-content pointable" onClick={props.onItemClick}>
            {props.primaryText}
            <div className="secondary-text">{props.secondaryText}</div>
        </div>
        <div className="list-item-controls">
            <IconButton iconProps={{ iconName: "Delete" }} onClick={props.onDeleteClick} />
        </div>
    </div>
);

export default listItem;