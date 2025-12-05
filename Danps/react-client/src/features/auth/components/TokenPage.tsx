import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";


export default function TokenPage() {
  const { token, logout } = useAuth();
  const navigate = useNavigate();

  function handleLogout() {
    logout();          // limpa token do contexto
    navigate("/login"); // redireciona para login
  }

  if (!token) {
    return <p>Nenhum token encontrado. Faça login ou registre-se.</p>;
  }

  return (
    <div className="container">
      <div className="card">
        <h2 style={{ marginBottom: '16px' }}>Dados do Token</h2>
        <pre style={{
          background: '#f5f5f5',
          padding: '12px',
          borderRadius: '4px',
          overflowX: 'auto',
          fontSize: '12px',
          marginBottom: '24px'
        }}>
          {JSON.stringify(token, null, 2)}
        </pre>

        <div className="flex-col" style={{ gap: '12px' }}>
          <Link to="/workshops" style={{ textDecoration: 'none' }}>
            <button type="button" className="btn btn-primary">Ver Workshops</button>
          </Link>

          <button onClick={handleLogout} className="btn" style={{ backgroundColor: '#ffebee', color: '#c62828' }}>
            Logoff
          </button>
        </div>
      </div>
    </div>
  );
}
