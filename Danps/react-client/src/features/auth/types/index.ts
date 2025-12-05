// Representa o DTO de registro
export interface NewUser {
    name: string;
    socialNumber: string;
    email: string;
    password: string;
    confirmPassword: string;
}

// Representa o DTO de login
export interface UserLogin {
    email: string;
    password: string;
}

// Representa cada claim
export interface UserClaim {
    value: string;
    type: string;
}

// Representa o token do usuário
export interface UserToken {
    id: string;
    email: string;
    claims: UserClaim[];
}

// Representa a resposta do login
export interface UserLoginResponse {
    accessToken: string;
    refreshToken: string;
    expiresIn: number;
    userToken: UserToken;
}
