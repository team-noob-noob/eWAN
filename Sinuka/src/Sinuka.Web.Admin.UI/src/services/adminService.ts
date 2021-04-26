import axios from "axios";
import { HOSTS } from "../config";

export async function FetchTest() {
    const response = await axios.get(`${HOSTS.ADMIN_APIS}/test/admin/WeatherForecast`);
    return response.data;
}

export async function FetchUsers(query: IUserQueryInputModel) {
    const response = await axios.get(`${HOSTS.ADMIN_APIS}/Account/GetAllUsers`, {params: query});
    return response.data;
}

export async function CreateUser(userData: INewUserInputModel) {
    const response = await axios.post(`${HOSTS.ADMIN_APIS}/Account/CreateAccount`, userData);
    return response.data;
}

export async function UpdateUser(userData: IUpdateUserInputModel) {
    const response = await axios.put(`${HOSTS.ADMIN_APIS}/Account/UpdateUser`, userData);
    return response.data;
}

interface IUserQueryInputModel {
    Email: string;
}

interface INewUserInputModel {
    Email: string;
    Password: string;
    Username: string;
    PhoneNumber: string;
}

interface IUpdateUserInputModel {
    Id: string;
    Username: string | null;
    Password: string | null;
    Email: string | null;
    PhoneNumber: string | null;
    IsDeleted: boolean;
}
