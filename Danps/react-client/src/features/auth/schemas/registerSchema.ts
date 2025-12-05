import * as yup from "yup";

export const registerSchema = yup.object({
  name: yup.string().required("O campo Nome é obrigatório"),
  socialNumber: yup.string().required("O campo CPF é obrigatório"),
  email: yup.string().email("Formato inválido").required("O campo Email é obrigatório"),
  password: yup
    .string()
    .min(6, "A senha deve ter no mínimo 6 caracteres")
    .max(100, "A senha deve ter no máximo 100 caracteres")
    .required("O campo Senha é obrigatório"),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password")], "As senhas devem coincidir")
    .required("Confirmação de senha é obrigatória"),
});
