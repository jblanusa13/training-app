export interface RegistrationUser {
  name: string;
  lastName: string;
  email: string;
  password: string;
}

export interface RegistrationUserResponse {
  id: string;
  name: string;
  lastName: string;
  email: string;
}

export interface LoginUser {
  email: string;
  password: string;
}

export interface LoginUserResponse {
  id: string;
  accessToken: string;
}

export interface User {
  email: string;
}
