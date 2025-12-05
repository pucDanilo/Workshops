import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useNavigate } from "react-router-dom";
import { registerSchema } from "../schemas/registerSchema";
import type { NewUser } from "../types";
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
    <div className="container flex-col flex-center full-height">
      <div className="card" style={{ width: '100%', maxWidth: '400px' }}>
        <h2 style={{ textAlign: 'center', marginBottom: '24px' }}>Registrar</h2>

        <form onSubmit={handleSubmit(onSubmit)} className="flex-col">
          <div className="input-group">
            <input placeholder="Nome" {...register("name")} className="input-field" />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.name?.message}</p>
          </div>

          <div className="input-group">
            <input placeholder="CPF" {...register("socialNumber")} className="input-field" />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.socialNumber?.message}</p>
          </div>

          <div className="input-group">
            <input type="email" placeholder="E-mail" {...register("email")} className="input-field" />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.email?.message}</p>
          </div>

          <div className="input-group">
            <input type="password" placeholder="Senha" {...register("password")} className="input-field" />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.password?.message}</p>
          </div>

          <div className="input-group">
            <input type="password" placeholder="Confirmar Senha" {...register("confirmPassword")} className="input-field" />
            <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{errors.confirmPassword?.message}</p>
          </div>

          <button type="submit" className="btn btn-primary">Criar Conta</button>

          <div style={{ marginTop: '16px', textAlign: 'center' }}>
            <Link to="/login" style={{ color: 'var(--primary-color)', textDecoration: 'none' }}>
              Já tem conta? Faça login
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}
