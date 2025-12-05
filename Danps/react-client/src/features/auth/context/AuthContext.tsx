import { createContext, useContext, useState, useEffect } from "react";
import { refreshToken } from "../api/authService";
import type { UserLoginResponse } from "../types";

interface AuthContextType {
  token: UserLoginResponse | null;
  isAuthenticated: boolean;
  setToken: (token: UserLoginResponse) => void;
  logout: () => void;
  hasRole: (role: string) => boolean;
}

const AuthContext = createContext<AuthContextType>({
  token: null,
  isAuthenticated: false,
  setToken: () => { },
  logout: () => { },
  hasRole: () => false,
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

  function hasRole(role: string): boolean {
    if (!token?.userToken?.claims) return false;
    // Check for "role" or standard identity role claim
    return token.userToken.claims.some(c =>
      (c.type === "role" || c.type.endsWith("/role")) && c.value === role
    );
  }

  return (
    <AuthContext.Provider
      value={{
        token,
        isAuthenticated: !!token,
        setToken,
        logout,
        hasRole,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}
