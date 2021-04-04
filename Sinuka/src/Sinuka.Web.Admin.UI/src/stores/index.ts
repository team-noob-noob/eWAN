import { createContext } from "react";
import { UserStore } from "./userStore";

export const rootStoreContext = createContext({
    userStore: new UserStore(),
});
