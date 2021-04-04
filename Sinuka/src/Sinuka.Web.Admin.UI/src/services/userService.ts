import { UserManager, UserManagerSettings } from "oidc-client";
import { UserStore } from "../stores/userStore";

const config: UserManagerSettings = {
    authority: "https://localhost:5000",
    client_id: "sinukaWebAdminUI",
    redirect_uri: "https://localhost:7001/signin-oidc",
    scope: "openid profile Admin",
    response_type: "id_token token",
    post_logout_redirect_uri: "https://localhost:7001/signout-oidc",
};

const userManager = new UserManager(config);

export async function loadUserFromStorage(store: UserStore) {
    try {
        let user = await userManager.getUser();
        store.user = user;
    }
    catch(e) {
        console.log(`Sinuka.Web.Admin.UI> user not found ${e}`);
        store.user = null;
    }
}

export async function signInRedirect() {
    return userManager.signinRedirect();
}

export async function signInRedirectCallback() {
    return userManager.signinRedirectCallback();
}

export async function signOutRedirect(idToken: string) {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect({'id_token_hint': idToken});
}

export async function signOutRedirectCallback() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export default userManager;
