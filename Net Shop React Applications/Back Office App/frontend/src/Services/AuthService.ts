import axios, { AxiosResponse } from "axios";

import { webAPIUrl } from "../AppSettings";
import { User } from "../Data/UserData";
import authHeader from "./AuthHeader";

export const login = (
  email: string,
  password: string
): Promise<string | undefined> => {
  return axios
    .post(webAPIUrl + "/Auth/LogIn", {
      email: email,
      password: password,
    })
    .then((response) => {
      if (response.data) {
        localStorage.setItem("token", JSON.stringify(response.data));
      }

      return response.data;
    });
};

export const logout = () => {
  localStorage.removeItem("token");
};

export const getCurrentUser = (): Promise<User | undefined> => {
  return axios
    .get(webAPIUrl + "/Auth/GetUserData", {
      headers: {
        Authorization: authHeader(),
      },
    })
    .then((response: AxiosResponse) => {
      return response.data as User;
    });
};
