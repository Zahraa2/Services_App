export interface ResetPasswordDto {
  email: string;
  token: string;
  password: string;
  confirmPassword: string;
}