import { UserManager } from "oidc-client";

const config = {
    authority: "https://localhost:5000",
    client_id: "Sinuka.Web.Admin.UI",
    redirect_uri: "https://localhost:7001/signin-oidc",
    scope: "openid profile Admin",
    response_type: "id_token token",
    post_logout_redirect_uri: "https://localhost:7001/signout-oidc",
};

const userManager = new UserManager(config);

export async function loadUserFromStorage() {

}

export async function signInRedirect() {

}

export async function signInRedirectCallback() {

}

export async function signOutRedirect() {

}

export async function signOutRedirectCallback() {

}

export default userManager;
