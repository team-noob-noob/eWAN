import React, { useEffect } from "react";
import { useHistory } from "react-router";
import { signInRedirectCallback } from "../services/userService";

export const SigninOidc: React.FC = () => {
    const history = useHistory();
    useEffect(() => {
        async function signinAsync() {
            await signInRedirectCallback();
            history.push("/");
        }
        signinAsync();
    }, [history]);

    return (
        <div>Redirecting</div>
    );
};
