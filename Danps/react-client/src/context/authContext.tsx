// src/context/AuthContext.tsx
import { createContext, useContext, useState, useEffect } from "react";
import type { UserLoginResponse } from "../api/models";
import { refreshToken } from "../api/authService";

interface AuthContextType {
  token: UserLoginResponse | null;
  isAuthenticated: boolean;
  setToken: (token: UserLoginResponse) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType>({
  token: null,
  isAuthenticated: false,
  setToken: () => {},
  logout: () => {},
});

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setTokenState] = useState<UserLoginResponse | null>(null);

  function setToken(newToken: UserLoginResponse) {
    setTokenState(newToken);
    localStorage.setItem("authData", JSON.stringify(newToken));
  }

  function logout() {
    setTokenState(null);
    localStorage.removeItem("authData");
  }

  // 🔄 Atualiza token automaticamente
  async function handleRefresh() {
    if (token?.refreshToken) {
      try {
        const response = await refreshToken(token.refreshToken);
        const newAccessToken = response.data;
        setToken({ ...token, accessToken: newAccessToken });
      } catch {
        logout();
      }
    }
  }

  
  useEffect(() => {
    const interval = setInterval(() => {
      handleRefresh();
    }, 14 * 60 * 1000); // 14 minutos

    return () => clearInterval(interval);
  }, [token]);

  
  useEffect(() => {
    const saved = localStorage.getItem("authData");
    if (saved) {
      setTokenState(JSON.parse(saved));
    }
  }, []);

  return (
    <AuthContext.Provider
      value={{
        token,
        isAuthenticated: !!token,
        setToken,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}
