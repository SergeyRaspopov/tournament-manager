import React from 'react';
import { IconButton, ActionButton } from 'office-ui-fabric-react/lib/Button';

const listItemGroup = (props) => {
    return (
    <div className="group">
        <div className="group-header">
            {props.name}
            <div>
                <IconButton iconProps={{ iconName: "Edit" }} onClick={props.onEdit} />
                <IconButton iconProps={{ iconName: "Delete" }} onClick={props.onDelete} />
            </div>
        </div>
        <div className="group-content">
            {props.children}
        </div>
        <div className="group-footer">
            <ActionButton iconProps={{ iconName: "Add" }} onClick={props.onAdd} >Add new category</ActionButton>
        </div>
    </div>);
};

export default listItemGroup;