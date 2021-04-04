import React, { useEffect } from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import userManager, { loadUserFromStorage } from "./services/userService";
import { useStores } from "./useStores";
import { AuthProvider } from "./providers/authProvider";

import { Login } from "./pages/Login"
import { SigninOidc } from "./pages/SigninOidc";
import { SignoutOidc } from "./pages/SignoutOidc";
import { Home } from "./pages/Home";

import { ProtectedRoute } from "./utils/protectedRoute";

function App() {
  const store = useStores();

  useEffect(() => {
    loadUserFromStorage(store.userStore);
  }, [])

  return (
    <AuthProvider
      userManager={userManager}
      store={store.userStore}
    >
      <BrowserRouter>
        <Switch>
          <Route path="/login" component={Login} />
          <Route path="/signin-oidc" component={SigninOidc} />
          <Route path="/signout-oidc" component={SignoutOidc} />
          <ProtectedRoute userStore={store.userStore} path="/" component={Home} />
        </Switch>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
