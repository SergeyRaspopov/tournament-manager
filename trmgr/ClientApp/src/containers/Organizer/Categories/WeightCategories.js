﻿import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../../store/Category/actionCreators';

import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import Input from '../../../components/UI/Input';
import ListItem from '../../../components/UI/ListItem';
import ListItemGroup from '../../../components/UI/ListItemGroup';

class WeightCategories extends React.Component {
    constructor(props) {
        super(props);
        this.groupRef = React.createRef();
        this.categoryRef = React.createRef();
    }
    state = {
        onDelete: null,
        confirmDeleteModalHeader: '',
        confirmDeleteModalText: '',
        showEditGroupModal: false,
        selectedGroupId: 0,
        editedGroupId: 0,
        editedCategoryId: 0,
        editGroupForm: {
            groupName: {
                id: 'groupName',
                name: 'Group Name',
                type: 'text',
                placeholder: 'Group Name',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            }
        },
        editCategoryForm: {
            categoryName: {
                id: 'categoryName',
                name: 'Weight Category',
                type: 'text',
                placeholder: 'Weight Category',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            minWeight: {
                id: 'minWeight',
                name: 'Min Weight',
                type: 'text',
                placeholder: 'Min Weight',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            },
            maxWeight: {
                id: 'maxWeight',
                name: 'Max Weight',
                type: 'text',
                placeholder: 'Max Weight',
                icon: '',
                value: '',
                rules: [],
                error: '',
                showErrors: false
            }
        }
    }

    componentDidMount() {
        this.props.getWeightCategoryGroups();
    }

    handleNewGroupClick = () => {
        this.setState({
            showEditGroupModal: true,
            editGroupForm: { ...this.state.editGroupForm, groupName: { ...this.state.editGroupForm.groupName, value: '' } }
        });
    }

    handleNewCategoryClick = (groupId) => {
        this.setState({
            selectedGroupId: groupId,
            editCategoryForm: {
                ...this.state.editCategoryForm,
                categoryName: { ...this.state.editCategoryForm.categoryName, value: '' },
                minWeight: { ...this.state.editCategoryForm.minWeight, value: '' },
                maxWeight: { ...this.state.editCategoryForm.maxWeight, value: '' }
            }
        });
    }

    handleEditGroupClick = (group) => {
        this.setState({
            showEditGroupModal: true,
            editedGroupId: group.id,
            editGroupForm: { ...this.state.editGroupForm, groupName: { ...this.state.editGroupForm.groupName, value: group.name } }
        });
    }

    handleEditCategoryClick = (category) => {
        this.setState({
            selectedGroupId: category.weightCategoryGroupId,
            editedCategoryId: category.id,
            editCategoryForm: {
                ...this.state.editCategoryForm,
                categoryName: { ...this.state.editCategoryForm.categoryName, value: category.name },
                minWeight: { ...this.state.editCategoryForm.minWeight, value: category.minWeight },
                maxWeight: { ...this.state.editCategoryForm.maxWeight, value: category.maxWeight }
            }
        });
    }

    handleDeleteGroupClick = (group) => {
        this.setState({
            confirmDeleteModalHeader: 'Delete Confirmation',
            confirmDeleteModalText: 'Are you sure you want to delete this weight category group?',
            onDelete: () => this.handleDeleteGroup(group.id)
        });
    }

    handleDeleteCategoryClick = (category) => {
        this.setState({
            confirmDeleteModalHeader: 'Delete Confirmation',
            confirmDeleteModalText: 'Are you sure you want to delete this weight category?',
            onDelete: () => this.handleDeleteCategory(category.id)
        });
    }

    handleCloseGroupEdit = () => {
        this.setState({ showEditGroupModal: false, editedGroupId: 0 });
    }

    handleCloseCategoryEdit = () => {
        this.setState({
            selectedGroupId: 0,
            editedCategoryId: 0
        });
    }

    handleCloseDeleteModal = () => {
        this.setState({
            confirmDeleteModalHeader: '',
            confirmDeleteModalText: '',
            onDelete: null
        });
    }

    handleCategoryInput = (event, field) => {
        const updatedForm = { ...this.state.editCategoryForm };
        const updatedField = { ...updatedForm[field] };
        updatedField.value = event.target.value;
        updatedForm[field] = updatedField;
        this.setState({
            editCategoryForm: updatedForm
        });
    }

    handleGroupInput = (event) => {
        const updatedForm = { ...this.state.editGroupForm };
        const updatedField = { ...updatedForm.groupName };
        updatedField.value = event.target.value;
        updatedForm.groupName = updatedField;
        this.setState({ editGroupForm: updatedForm });
    }

    handleGroupFormSubmit = (event) => {
        event.preventDefault();
        if (this.state.editedGroupId > 0) {
            this.props.updateWeightCategoryGroup(this.state.editedGroupId, this.state.editGroupForm.groupName.value);
        }
        else {
            this.props.addWeightCategoryGroup(this.state.editGroupForm.groupName.value);
        }
        this.handleCloseGroupEdit();
    }

    handleCategoryFormSubmit = (event) => {
        event.preventDefault();
        if (this.state.editedCategoryId) {
            this.props.updateWeightCategory(
                this.state.editedCategoryId,
                this.state.editCategoryForm.categoryName.value,
                this.state.editCategoryForm.minWeight.value,
                this.state.editCategoryForm.maxWeight.value,
                this.state.selectedGroupId
            );
        }
        else {
            this.props.addWeightCategory(
                this.state.selectedGroupId,
                this.state.editCategoryForm.categoryName.value,
                this.state.editCategoryForm.minWeight.value,
                this.state.editCategoryForm.maxWeight.value
            );
        }

        this.handleCloseCategoryEdit();
    }

    handleDeleteGroup = (groupId) => {
        this.props.deleteWeightCategoryGroup(groupId);
        this.handleCloseDeleteModal();
    }

    handleDeleteCategory = (categoryId) => {
        this.props.deleteWeightCategory(categoryId);
        this.handleCloseDeleteModal();
    }

    handleGroupEditShow = () => {
        setTimeout(() => this.groupRef.current.inputEl.focus(), 1);
    }

    handleCategoryEditShow = () => {
        setTimeout(() => this.categoryRef.current.inputEl.focus(), 1);
    }

    render() {
        const editCategoryInputs = Object.keys(this.state.editCategoryForm).map(field => (
            <Input key={field} {...this.state.editCategoryForm[field]} onChange={(e) => this.handleCategoryInput(e, field)}
                inputRef={field === "categoryName" ? this.categoryRef : null}
            />));

        const groups = this.props.weightCategoryGroups.map(group => {
            const categories = group.weightCategories && group.weightCategories.length > 0 ? group.weightCategories.map(cat => (
                <ListItem key={cat.id} primaryText={cat.name} secondaryText={`${cat.minWeight} to ${cat.maxWeight} pounds`}
                    onItemClick={() => this.handleEditCategoryClick(cat)} onDeleteClick={() => this.handleDeleteCategoryClick(cat)} />)) :
                <h3 className="secondary-text">No Weight Categories</h3>;
            return (
                <ListItemGroup key={group.id} name={group.name} onEdit={() => this.handleEditGroupClick(group)}
                    onDelete={() => this.handleDeleteGroupClick(group)} onAdd={() => this.handleNewCategoryClick(group.id)}>
                    {categories}
                </ListItemGroup>);
        });
        console.log(this.props.weightCategoryGroups);
        return (
            <div>
                <div className="group-list">
                    {groups}
                </div>

                <Button icon="pi pi-plus" className="button-fab" onClick={this.handleNewGroupClick} />

                <Dialog visible={this.state.showEditGroupModal} header="New Group" modal
                    onHide={this.handleCloseGroupEdit} onShow={this.handleGroupEditShow}
                >

                    <form onSubmit={this.handleGroupFormSubmit} autoComplete="off">
                        <Input {...this.state.editGroupForm.groupName} onChange={this.handleGroupInput} inputRef={this.groupRef} />
                        <div className="form-buttons">
                            <Button label="Save Group" className="p-button-success" />
                            <Button type="button" label="Cancel" className="p-button-secondary" onClick={this.handleCloseGroupEdit} />
                        </div>
                    </form>
                </Dialog>

                <Dialog visible={this.state.selectedGroupId > 0} header="New Weight Category" modal
                    onHide={this.handleCloseCategoryEdit} onShow={this.handleCategoryEditShow}
                >

                    <form onSubmit={this.handleCategoryFormSubmit} autoComplete="off">
                        {editCategoryInputs}

                        <div className="form-buttons">
                            <Button type="submit" label="Save Category" className="p-button-success" />
                            <Button type="button" label="Cancel" className="p-button-secondary" onClick={this.handleCloseCategoryEdit} />
                        </div>
                    </form>
                </Dialog>

                <Dialog visible={this.state.confirmDeleteModalHeader !== ''} header={this.state.confirmDeleteModalHeader}
                    modal onHide={this.handleCloseDeleteModal}>
                    <div>
                        <p>
                            {this.state.confirmDeleteModalText}
                        </p>
                        <div className="form-buttons">
                            <Button type="button" label="Delete" className="p-button-danger" onClick={this.state.onDelete} />
                            <Button type="button" label="Cancel" className="p-button-secondary" onClick={this.handleCloseDeleteModal} />
                        </div>
                    </div>
                </Dialog>
            </div>);
    }
}

export default connect(
    state => state.category,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(WeightCategories);