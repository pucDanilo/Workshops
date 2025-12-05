import axios from "axios";
import type { NewUser, UserLogin, UserLoginResponse } from "../types";

const API_URL = "/api/identity";

export async function register(newUser: NewUser) {
  return axios.post(`${API_URL}/new-account`, newUser);
}

export async function login(userLogin: UserLogin) {
  return axios.post<UserLoginResponse>(`${API_URL}/auth`, userLogin);
}

export async function refreshToken(token: string) {
  return axios.post<string>(`${API_URL}/refresh-token`, token, {
    headers: { "Content-Type": "application/json" },
  });
}
