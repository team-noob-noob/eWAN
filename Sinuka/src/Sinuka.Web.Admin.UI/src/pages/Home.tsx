import React from "react";
import { signOutRedirect } from "../services/userService";
import { useStores } from "../useStores";

export const Home: React.FC = () => {
    const user = useStores().userStore.user;

    const signout = () => {
        signOutRedirect(user?.id_token || "");
    }

    return (
        <>
            <button onClick={signout}>Logout</button>
            Hello
            {JSON.stringify(user, null, 2)}
        </>
    );
};
