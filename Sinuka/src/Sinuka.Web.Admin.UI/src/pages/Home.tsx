import React, { useState } from "react";
import { signOutRedirect } from "../services/userService";
import { FetchTest } from "../services/adminService";
import { useStores } from "../useStores";

export const Home: React.FC = () => {
    const [temp, setTemp] = useState(null);
    const user = useStores().userStore.user;

    const signout = () => {
        signOutRedirect(user?.id_token || "");
    }

    const fetch = async () => {
        let test = await FetchTest();
        setTemp(test);
    }

    return (
        <>
            <button onClick={signout}>Logout</button> <br />
            <button onClick={fetch}>Fetch Temps</button>
            Hello <br />
            {JSON.stringify(user, null, 2)} <br />
            {JSON.stringify(temp)}
        </>
    );
};
