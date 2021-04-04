import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";
import { signOutRedirectCallback } from "../services/userService";

export const SignoutOidc: React.FC = () => {
    const history = useHistory();

    useEffect(() => {
        async function signoutAsync() {
            await signOutRedirectCallback();
            history.push("/");
        }
        signoutAsync();
    }, [history]);
    
    return (
        <div>Redirecting</div>
    );
};
