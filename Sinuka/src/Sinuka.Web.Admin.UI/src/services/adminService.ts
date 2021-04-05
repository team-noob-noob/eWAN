import axios from "axios";
import { HOSTS } from "../config";

export async function FetchTest() {
    const response = await axios.get(`${HOSTS.ADMIN_APIS}/WeatherForecast`);
    return response.data;
}
