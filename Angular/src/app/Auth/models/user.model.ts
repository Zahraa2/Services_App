export class User {
  constructor(
    private token: string,
    private expirOn: string,
    private refreshToken: string,
    private refershTokenExpirOn: string,
    private message?: string
  ) {}
}
