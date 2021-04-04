import { UserManager } from "oidc-client";
import { UserStore } from "stores/userStore";

const config = {
    authority: "https://localhost:5000",
    client_id: "Sinuka.Web.Admin.UI",
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

export async function signOutRedirect() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
}

export async function signOutRedirectCallback() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export default userManager;
