export interface AuthResponseData {
  token: string;
  expirOn: string;
  refreshToken: string;
  refershTokenExpirOn: string;
  message?: string;
}