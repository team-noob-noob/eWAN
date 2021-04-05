import React, { useEffect, useRef } from "react";
import { UserManager, UserManagerEvents } from "oidc-client";
import { UserStore } from "../stores/userStore";
import { setAuthHeader } from "../utils/axiosHeaders";

export const AuthProvider: React.FC<AuthProviderProps> = ({userManager: manager, store, children}) => {
    let userManager = useRef<UserManager>();

    useEffect(() => {
        userManager.current = manager;

        const onUserLoaded: UserManagerEvents.UserLoadedCallback = (user) => {
            console.log(`Sinuka.Web.Admin.UI > user loaded: ${user}`);
            store.user = user;
            setAuthHeader(user.access_token);
        };

        const onUserUnloaded: UserManagerEvents.UserUnloadedCallback = () => {
            console.log(`Sinuka.Web.Admin.UI > user unloaded`);
            store.user = null;
            setAuthHeader(null);
        };

        const onAccessTokenExpiring = () => {
            console.log(`Sinuka.Web.Admin.UI > user token expiring`);
        }

        const onAccessTokenExpired = () => {
            console.log(`Sinuka.Web.Admin.UI > user token expired`);
        }

        const onUserSignedOut = () => {
            console.log(`Sinuka.Web.Admin.UI > user signed out`);
        };

        userManager.current.events.addUserLoaded(onUserLoaded);
        userManager.current.events.addUserUnloaded(onUserUnloaded);
        userManager.current.events.addAccessTokenExpiring(onAccessTokenExpiring);
        userManager.current.events.addAccessTokenExpired(onAccessTokenExpired);
        userManager.current.events.addUserSignedOut(onUserSignedOut);

        return function cleanup() {
            if(userManager.current) {
                userManager.current.events.removeUserLoaded(onUserLoaded);
                userManager.current.events.removeUserUnloaded(onUserUnloaded);
                userManager.current.events.removeAccessTokenExpiring(onAccessTokenExpiring);
                userManager.current.events.removeAccessTokenExpired(onAccessTokenExpired);
                userManager.current.events.removeUserSignedOut(onUserSignedOut);
            }
        }
    }, [manager, store])

    return (
        <>
            {children}
        </>
    );
}

interface AuthProviderProps {
    userManager: UserManager;
    store: UserStore;
}
