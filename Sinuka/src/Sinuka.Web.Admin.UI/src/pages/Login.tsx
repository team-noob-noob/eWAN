import React from "react";
import { Redirect } from "react-router-dom";
import { signInRedirect } from "../services/userService";
import { useStores } from "../useStores";

export const Login: React.FC = () => {
    const user = useStores().userStore.user;
    return (
        user ? <Redirect to="/" /> : <button onClick={signInRedirect}>LogIn</button>
    );
};
