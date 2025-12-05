import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useNavigate } from "react-router-dom";
import { registerSchema } from "../validation/registerSchema";
import type { NewUser } from "../api/models";
import { register as registerApi } from "../api/authService";
import { useAuth } from "../context/AuthContext";

export default function Register() {
  const navigate = useNavigate();
  const { setToken } = useAuth();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<NewUser>({
    resolver: yupResolver(registerSchema),
  });

  async function onSubmit(data: NewUser) {
    try {
      const response = await registerApi(data);
      setToken(response.data); // salva token no contexto
      navigate("/token");      // redireciona para página de token
    } catch (err: any) {
      alert("Erro ao registrar: " + err.message);
    }
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h2>Registrar</h2>

      <input placeholder="Nome" {...register("name")} />
      <p>{errors.name?.message}</p>

      <input placeholder="CPF" {...register("socialNumber")} />
      <p>{errors.socialNumber?.message}</p>

      <input type="email" placeholder="E-mail" {...register("email")} />
      <p>{errors.email?.message}</p>

      <input type="password" placeholder="Senha" {...register("password")} />
      <p>{errors.password?.message}</p>

      <input type="password" placeholder="Confirmar Senha" {...register("confirmPassword")} />
      <p>{errors.confirmPassword?.message}</p>

      <button type="submit">Criar Conta</button>
      <Link to="/login">
        <button type="button">Login</button>
      </Link>
    </form>    
  );
}
