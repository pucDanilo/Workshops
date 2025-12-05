import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Sidebar() {
  const { isAuthenticated, logout } = useAuth();

  return (
    <aside
      style={{
        width: "200px",
        background: "#f5f5f5",
        padding: "20px",
        height: "100vh",
      }}
    >
      <h3>Menu</h3>
      <nav>
        <ul style={{ listStyle: "none", padding: 0 }}>
          {!isAuthenticated ? (
            <>
              <li>
                <Link to="/login">Login</Link>
              </li>
              <li>
                <Link to="/register">Registrar</Link>
              </li>
            </>
          ) : (
            <>
              <li>
                <Link to="/token">Token</Link>
              </li>
              <li>
                <Link to="/workshops">Workshops</Link>
              </li>
              <li>
                <button
                  onClick={logout}
                  style={{
                    background: "none",
                    border: "none",
                    color: "blue",
                    cursor: "pointer",
                    padding: 0,
                  }}
                >
                  Logoff
                </button>
              </li>
            </>
          )}
        </ul>
      </nav>
    </aside>
  );
}
