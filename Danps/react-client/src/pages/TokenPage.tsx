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
    <div>
      <h2>Dados do Token</h2>
      <pre>{JSON.stringify(token, null, 2)}</pre>

      <Link to="/workshops">
        <button type="button">Ver Workshops</button>
      </Link>

      <button onClick={handleLogout}>Logoff</button>
    </div>
  );
}
