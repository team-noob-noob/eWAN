import axios from "axios";

export function setAuthHeader(token: string | null): void {
    axios.defaults.headers.common["Authorization"] = token ? "Bearer " + token : "";
}
