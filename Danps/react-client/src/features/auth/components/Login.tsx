import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useNavigate } from "react-router-dom";
import * as yup from "yup";
import type { UserLogin, UserLoginResponse } from "../types";
import { login } from "../api/authService";
import { useAuth } from "../context/AuthContext";

const loginSchema = yup.object({
  email: yup.string().email("Formato inválido").required("O campo Email é obrigatório"),
  password: yup
    .string()
    .min(6, "A senha deve ter no mínimo 6 caracteres")
    .max(100, "A senha deve ter no máximo 100 caracteres")
    .required("O campo Senha é obrigatório"),
});

export default function Login() {
  const navigate = useNavigate();
  const { setToken } = useAuth();

  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm<UserLogin>({
    resolver: yupResolver(loginSchema),
  });

  async function onSubmit(data: UserLogin) {
    try {
      const response = await login(data);
      const authData: UserLoginResponse = response.data;
      setToken(authData);   // salva token no contexto
      navigate("/token");   // redireciona para página de token
    } catch (err: any) {
      alert("Erro ao logar: " + err.message);
    }
  }

  // 🔄 Função para login rápido com usuário demo
  function quickLogin(email: string) {
    setValue("email", email);
    setValue("password", email); // senha = email
    handleSubmit(onSubmit)();    // dispara o submit
  }

  return (
    <div className="container flex-col flex-center full-height">
      <div className="card" style={{ width: '100%', maxWidth: '400px' }}>
        <h2 style={{ textAlign: 'center', marginBottom: '24px' }}>Login</h2>

        <form onSubmit={handleSubmit(onSubmit)} className="flex-col">
          <div className="input-group">
            <input
              type="email"
              placeholder="E-mail"
              {...register("email")}
              className="input-field"
            />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.email?.message}</p>
          </div>

          <div className="input-group">
            <input
              type="password"
              placeholder="Senha"
              {...register("password")}
              className="input-field"
            />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.password?.message}</p>
          </div>

          <button type="submit" className="btn btn-primary">Entrar</button>
        </form>

        <div style={{ marginTop: '24px' }}>
          <h3 style={{ fontSize: '16px', marginBottom: '12px' }}>Login rápido (demo)</h3>
          <div className="flex-col" style={{ gap: "8px" }}>
            <button type="button" className="btn" style={{ backgroundColor: '#e0e0e0', color: '#000' }} onClick={() => quickLogin("allroles@example.com")}>
              Entrar como AllRoles
            </button>
            <button type="button" className="btn" style={{ backgroundColor: '#e0e0e0', color: '#000' }} onClick={() => quickLogin("instructor@example.com")}>
              Entrar como Instrutor
            </button>
            <button type="button" className="btn" style={{ backgroundColor: '#e0e0e0', color: '#000' }} onClick={() => quickLogin("admin@example.com")}>
              Entrar como Admin
            </button>
            <button type="button" className="btn" style={{ backgroundColor: '#e0e0e0', color: '#000' }} onClick={() => quickLogin("norole@example.com")}>
              Entrar sem Role
            </button>
          </div>
        </div>

        <div style={{ marginTop: '16px', textAlign: 'center' }}>
          <Link to="/register" style={{ color: 'var(--primary-color)', textDecoration: 'none' }}>
            Não tem conta? Cadastre-se
          </Link>
        </div>
      </div>
    </div>
  );
}
