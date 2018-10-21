import React from 'react';
import { NavLink } from 'react-router-dom';

const mainNavBar = (props) => {
    const navItems = props.items.map(i => <NavLink key={i.path} className="main-nav-item" to={i.path}>{i.text}</NavLink>);
    return (
        <nav className="main-nav">
            {navItems}
        </nav>
    );
};

export default mainNavBar;