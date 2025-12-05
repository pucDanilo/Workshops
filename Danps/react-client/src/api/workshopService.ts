import axios from "axios";
import type { WorkshopResponse } from "./models";

const API_URL = "https://localhost:5471/api/workshops";

export async function searchWorkshops(
  token: string,
  page: number,
  pageSize: number,
  q?: string
) {
  return axios.get<{ total: number; page: number; pageSize: number; items: WorkshopResponse[] }>(
    API_URL,
    {
      headers: { Authorization: `Bearer ${token}` },
      params: { page, pageSize, q },
    }
  );
}


export async function getWorkshops(token: string) {
  return axios.get<WorkshopResponse[]>(API_URL, {
    headers: { Authorization: `Bearer ${token}` },
  });
}

export async function createWorkshop(token: string, data: Partial<WorkshopResponse>) {
  return axios.post(API_URL, data, {
    headers: { Authorization: `Bearer ${token}` },
  });
}

export async function updateWorkshop(token: string, id: string, data: Partial<WorkshopResponse>) {
  return axios.put(`${API_URL}/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` },
  });
}

export async function deleteWorkshop(token: string, id: string) {
  return axios.delete(`${API_URL}/${id}`, {
    headers: { Authorization: `Bearer ${token}` },
  });
}
