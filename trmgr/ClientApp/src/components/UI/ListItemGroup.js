import React from 'react';

const listItemGroup = (props) => {
    return (<div className="group">
        <div className="group-header">
            {props.name}
            <div>
                <i className="pi pi-pencil pointable" onClick={props.onEdit} />
                <i className="pi pi-trash pointable" onClick={props.onDelete} />
            </div>
        </div>
        <div className="group-content">
            {props.children}
        </div>
        <div className="group-footer">
            <div className="button-link" onClick={props.onAdd}>
                <i className="pi pi-plus" />
                <div>Add new category</div>
            </div>
        </div>
    </div>);
};

export default listItemGroup;