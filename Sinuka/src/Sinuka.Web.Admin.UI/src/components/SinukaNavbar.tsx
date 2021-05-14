import React from "react";
import Navbar from "react-bootstrap/Navbar"
import Container from "react-bootstrap/Container";

export const SinukaNavbar: React.FC = () => {
    return (
        <Navbar>
            <Container fluid>
                <Navbar.Brand>
                    Sinuka
                </Navbar.Brand>
            </Container>
        </Navbar>
    );
};
