import React from 'react';

import { connect } from 'react-redux';

import { Navbar, Nav, NavItem, NavDropdown, MenuItem, OverlayTrigger } from 'react-bootstrap';
import { Popover, Button, Glyphicon } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import * as Constant from '../constants';

import Spinner from '../components/Spinner.jsx';


var TopNav = React.createClass({
  propTypes: {
    currentUser: React.PropTypes.object,
    showWorkingIndicator: React.PropTypes.bool,
    requestError: React.PropTypes.object,
    showNav: React.PropTypes.bool,
  },

  getDefaultProps() {
    return {
      showNav: true,
    };
  },

  render() {
    return <div id="header">
      <nav id="header-main" className="navbar navbar-default navbar-fixed-top">
        <div className="container">
          <div id="logo">
            <a href="http://www2.gov.bc.ca/gov/content/home">
              <img title="Government of B.C." alt="Government of B.C." src="images/gov/gov3_bc_logo.png"/>
            </a>
          </div>
          <h1 id="banner">MOTI Hired Equipment Tracking System</h1>
        </div>
        <Navbar id="top-nav">
          {this.props.showNav &&
            <Nav>
              <LinkContainer to={{ pathname: `/${ Constant.HOME_PATHNAME }` }}>
                <NavItem eventKey={ 1 }>Home</NavItem>
              </LinkContainer>
              <LinkContainer to={{ pathname: `/${ Constant.OWNERS_PATHNAME }` }}>
                <NavItem eventKey={ 2 }>Owners</NavItem>
              </LinkContainer>
              <LinkContainer to={{ pathname: `/${ Constant.EQUIPMENT_PATHNAME }` }}>
                <NavItem eventKey={ 3 }>Equipment</NavItem>
              </LinkContainer>
              <LinkContainer to={{ pathname: `/${ Constant.PROJECTS_PATHNAME }` }}>
                <NavItem eventKey={ 5 }>Projects</NavItem>
              </LinkContainer>
              <LinkContainer to={{ pathname: `/${ Constant.RENTAL_REQUESTS_PATHNAME }` }}>
                <NavItem eventKey={ 6 }>Requests</NavItem>
              </LinkContainer>
              { (this.props.currentUser.hasPermission(Constant.PERMISSION_ADMIN) ||
                this.props.currentUser.hasPermission(Constant.PERMISSION_USER_MANAGEMENT) ||
                this.props.currentUser.hasPermission(Constant.PERMISSION_ROLES_AND_PERMISSIONS)) &&
                <NavDropdown id="admin-dropdown" title="Administration">
                  { this.props.currentUser.hasPermission(Constant.PERMISSION_USER_MANAGEMENT) &&
                    <LinkContainer to={{ pathname: `/${ Constant.USERS_PATHNAME }` }}>
                      <MenuItem eventKey={ 7 }>User Management</MenuItem>
                    </LinkContainer>
                  }
                  { this.props.currentUser.hasPermission(Constant.PERMISSION_ROLES_AND_PERMISSIONS) &&
                    <LinkContainer to={{ pathname: `/${ Constant.ROLES_PATHNAME }` }}>
                      <MenuItem eventKey={ 8 }>Roles and Permissions</MenuItem>
                    </LinkContainer>
                  }
                </NavDropdown>
              }
              { this.props.currentUser.hasPermission(Constant.PERMISSION_DISTRICT_CODE_TABLE_MANAGEMENT) &&
                <LinkContainer to={{ pathname: `/${ Constant.DISTRICT_ADMIN_PATHNAME }` }}>
                  <NavItem eventKey={ 9 }>District Admin</NavItem>
                </LinkContainer>
              }
            </Nav>
          }
          {this.props.showNav &&
            <Nav id="navbar-current-user" pullRight>
              <NavItem>
                {this.props.currentUser.fullName} <small>{this.props.currentUser.districtName} District</small>
              </NavItem>
            </Nav>
          }
          <OverlayTrigger trigger="click" placement="bottom" rootClose overlay={
              <Popover id="error-message" title={ this.props.requestError.status + ' – API Error' }>
                <p><small>{ this.props.requestError.message }</small></p>
              </Popover>
            }>
            <Button id="error-indicator" className={ this.props.requestError.message ? '' : 'hide' } bsStyle="danger" bsSize="xsmall">
              Error
              <Glyphicon glyph="exclamation-sign" />
            </Button>
          </OverlayTrigger>
          <div id="working-indicator" hidden={ !this.props.showWorkingIndicator }>Working <Spinner/></div>
        </Navbar>
      </nav>
    </div>;
  },
});


function mapStateToProps(state) {
  return {
    currentUser: state.user,
    showWorkingIndicator: state.ui.requests.waiting,
    requestError: state.ui.requests.error,
  };
}

export default connect(mapStateToProps, null, null, { pure:false })(TopNav);
