import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/'}>PaymentClient</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/'} exact>
                            <NavItem>
                                <Glyphicon glyph='home' /> Home
              </NavItem>
                        </LinkContainer>
                        
                        <LinkContainer to={'/paymentList'}>
                            <NavItem>
                                <Glyphicon glyph='education' /> Display Payment
        </NavItem>  
                        </LinkContainer>
            <LinkContainer to={'/addPayment'}>
            <NavItem>
            <Glyphicon glyph='education' /> Add Payment
            </NavItem>
            </LinkContainer>
                       
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}
