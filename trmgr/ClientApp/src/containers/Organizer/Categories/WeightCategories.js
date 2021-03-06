﻿import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import actionCreators from '../../../store/Category/actionCreators';

import { DefaultButton, PrimaryButton, IconButton } from 'office-ui-fabric-react/lib/Button';
import { Modal } from 'office-ui-fabric-react/lib/Modal';
import Input from '../../../components/UI/Input';
import ListItem from '../../../components/UI/ListItem';
import ListItemGroup from '../../../components/UI/ListItemGroup';

class WeightCategories extends React.Component {
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

    componentDidUpdate(prevProps) {
        if (prevProps.weightCategoryGroups !== this.props.weightCategoryGroups)
            this.handleCloseAllModals();
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

    handleCloseAllModals = () => {
        this.setState({
            showEditGroupModal: false,
            editedGroupId: 0,
            selectedGroupId: 0,
            editedCategoryId: 0,
            confirmDeleteModalHeader: '',
            confirmDeleteModalText: '',
            onDelete: null
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
    }

    handleDeleteGroup = (groupId) => {
        this.props.deleteWeightCategoryGroup(groupId);
    }

    handleDeleteCategory = (categoryId) => {
        this.props.deleteWeightCategory(categoryId);
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
        return (
            <div>
                <div className="group-list">
                    {groups}
                </div>

                <PrimaryButton className="button-fab" onClick={this.handleNewGroupClick}>New Group</PrimaryButton>

                <Modal isOpen={this.state.showEditGroupModal} onDismiss={this.handleCloseGroupEdit}>
                    <form onSubmit={this.handleGroupFormSubmit} autoComplete="off">
                        <Input {...this.state.editGroupForm.groupName} onChange={this.handleGroupInput} inputRef={this.groupRef} />
                        <div className="form-buttons">
                            <PrimaryButton type="submit">Save Group</PrimaryButton>
                            <DefaultButton type="button" onClick={this.handleCloseGroupEdit}>Cancel</DefaultButton>
                        </div>
                    </form>
                </Modal>

                <Modal isOpen={this.state.selectedGroupId > 0} onDismiss={this.handleCloseCategoryEdit}>

                    <form onSubmit={this.handleCategoryFormSubmit} autoComplete="off">
                        {editCategoryInputs}

                        <div className="form-buttons">
                            <PrimaryButton type="submit">Save Category</PrimaryButton>
                            <DefaultButton type="button" onClick={this.handleCloseCategoryEdit}>Cancel</DefaultButton>
                        </div>
                    </form>
                </Modal>

                <Modal isOpen={this.state.confirmDeleteModalHeader !== ''} onDismiss={this.handleCloseDeleteModal}>
                    <div>
                        <h4>{this.state.confirmDeleteModalHeader}</h4>
                        <p>
                            {this.state.confirmDeleteModalText}
                        </p>
                        <div className="form-buttons">
                            <PrimaryButton type="button" onClick={this.state.onDelete}>Delete</PrimaryButton>
                            <DefaultButton type="button" onClick={this.handleCloseDeleteModal}>Cancel</DefaultButton>
                        </div>
                    </div>
                </Modal>
            </div>);
    }
}

export default connect(
    state => state.category,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(WeightCategories);