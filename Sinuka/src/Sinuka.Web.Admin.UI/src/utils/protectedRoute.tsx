import React from "react";
import { Route, Redirect } from "react-router-dom";
import { UserStore } from "../stores/userStore";
import { useStores } from "../useStores";

export const ProtectedRoute: React.FC<ProtectedRouteProps> = ({children, component: Component, userStore, ...rest}) => {
    const user = userStore.user;
    return (user ? <Route {...rest} component={Component} /> : <Redirect to={'/login'} />);
};

interface ProtectedRouteProps {
    component: React.ComponentType;
    userStore: UserStore;
    path: string;
}
