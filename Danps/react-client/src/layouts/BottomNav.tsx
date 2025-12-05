import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../features/auth/context/AuthContext";

export default function Sidebar() {
  const { isAuthenticated, logout } = useAuth();
  const location = useLocation();

  // Simple SVG icons as components for now


  const ListIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><line x1="8" y1="6" x2="21" y2="6"></line><line x1="8" y1="12" x2="21" y2="12"></line><line x1="8" y1="18" x2="21" y2="18"></line><line x1="3" y1="6" x2="3.01" y2="6"></line><line x1="3" y1="12" x2="3.01" y2="12"></line><line x1="3" y1="18" x2="3.01" y2="18"></line></svg>
  );

  const KeyIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M21 2l-2 2m-7.61 7.61a5.5 5.5 0 1 1-7.778 7.778 5.5 5.5 0 0 1 7.777-7.777zm0 0L15.5 7.5m0 0l3 3L22 7l-3-3m-3.5 3.5L19 4"></path></svg>
  );

  const LoginIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M15 3h4a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2h-4"></path><polyline points="10 17 15 12 10 7"></polyline><line x1="15" y1="12" x2="3" y2="12"></line></svg>
  );

  const LogoutIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4"></path><polyline points="16 17 21 12 16 7"></polyline><line x1="21" y1="12" x2="9" y2="12"></line></svg>
  );

  const isActive = (path: string) => location.pathname === path ? "active" : "";

  return (
    <nav className="bottom-nav">
      {!isAuthenticated ? (
        <>
          <Link to="/login" className={`nav-item ${isActive('/login')}`}>
            <div className="nav-icon"><LoginIcon /></div>
            <span>Login</span>
          </Link>
          <Link to="/register" className={`nav-item ${isActive('/register')}`}>
            <div className="nav-icon"><KeyIcon /></div>
            <span>Registrar</span>
          </Link>
        </>
      ) : (
        <>
          <Link to="/workshops" className={`nav-item ${isActive('/workshops')}`}>
            <div className="nav-icon"><ListIcon /></div>
            <span>Workshops</span>
          </Link>
          <Link to="/token" className={`nav-item ${isActive('/token')}`}>
            <div className="nav-icon"><KeyIcon /></div>
            <span>Token</span>
          </Link>
          <button
            onClick={logout}
            className="nav-item"
            style={{ background: 'none', border: 'none', padding: 0, cursor: 'pointer' }}
          >
            <div className="nav-icon"><LogoutIcon /></div>
            <span>Sair</span>
          </button>
        </>
      )}
    </nav>
  );
}
