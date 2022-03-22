import React from "react";
import { Navbar } from "react-bootstrap";
import { Nav } from "react-bootstrap";
import { navigationlinks } from "../../helpers/navigationlinks";
import "./navigation.css";

function createLinks() {
  return navigationlinks.map((e, idx) => (
    <Nav.Link key={idx} href={e.ref}>
      {e.name}
    </Nav.Link>
  ));
}

function NavigationBar() {
  return (
    <div id="home">
      <Navbar className="navigation__container" expand="md">
        <Navbar.Brand style={{ marginLeft: "1 rem" }} href="#home">
          Mazingira Bora Website
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="offcanvasNavbar" />
        <Navbar.Collapse
          style={{
            justifyContent: "flex-end",
            marginRight: "1rem",
            borderColor: "none",
          }}
        >
          <Nav className="links" style={{margin:"0 1rem"}}>{createLinks()}</Nav>
        </Navbar.Collapse>
      </Navbar>
    </div>
  );
}

export default NavigationBar;
