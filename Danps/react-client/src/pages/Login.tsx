import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useNavigate } from "react-router-dom";
import * as yup from "yup";
import type { UserLogin, UserLoginResponse } from "../api/models";
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
     <div>
      <h2>Login</h2>

      <form onSubmit={handleSubmit(onSubmit)}>
        <input type="email" placeholder="E-mail" {...register("email")} />
        <p>{errors.email?.message}</p>

        <input type="password" placeholder="Senha" {...register("password")} />
        <p>{errors.password?.message}</p>

        <button type="submit">Entrar</button>
      </form>

      <h3>Login rápido (demo)</h3>
      <div style={{ display: "flex", gap: "10px", flexWrap: "wrap" }}>
        <button type="button" onClick={() => quickLogin("allroles@example.com")}>
          Entrar como AllRoles
        </button>
        <button type="button" onClick={() => quickLogin("instructor@example.com")}>
          Entrar como Instrutor
        </button>
        <button type="button" onClick={() => quickLogin("admin@example.com")}>
          Entrar como Admin
        </button>
        <button type="button" onClick={() => quickLogin("norole@example.com")}>
          Entrar sem Role
        </button>
      </div>
    </div>
  );
}
