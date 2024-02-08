import axios, { AxiosError, AxiosInstance } from "axios";


export const url = process.env.NODE_ENV === 'development' ? 'https://localhost:7125/' : '/';

export function api(): AxiosInstance {
  const headers: { [key: string]: string } = {
    "Content-Type": "application/json",
  };

  const token = localStorage.getItem("token");
  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }

  const instance = axios.create({
    baseURL: url,
    headers,
  });

  instance.interceptors.response.use(
    (response) => {
      handleDates(response.data);

      if (isIsoDateString(response.data))
        response.data = new Date(response.data);

      return response;
    },
    (error: AxiosError) => {
      const { response } = error || { response: null, config: {} };
      const { status } = response || { status: null };

      console.error("error:", { error, response });

      if (status === 401) {
        // TODO handle unauthorized
      }

      return Promise.reject(error);
    }
  );
  instance.interceptors.request.use((request) => {
    // console.info(request);

    return request;
  });

  return instance;
}

const isoDateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d*)?$/;

function isIsoDateString(value: any): boolean {
  return value && typeof value === "string" && isoDateFormat.test(value);
}

export function handleDates(body: any) {
  if (body === null || body === undefined || typeof body !== "object")
    return body;

  for (const key of Object.keys(body)) {
    const value = body[key];
    if (isIsoDateString(value)) body[key] = new Date(value);
    else if (typeof value === "object") handleDates(value);
  }
}
