import { Injectable } from "@angular/core";
import { UserLoginRequest } from "../dtos/userLoginDto";
import { RequestService } from "./requestService";

@Injectable()
export class AuthService {
   constructor(private requestService: RequestService) { }

   public Login(request: UserLoginRequest) {
      return this.requestService.post("tokens/login", request);
   }

   public saveAuthData(authData: any) {
      localStorage.setItem('accessToken', authData.accessToken);
      localStorage.setItem('refreshToken', authData.refreshToken);
      localStorage.setItem('userId', authData.userId.toString());
      localStorage.setItem('role', authData.role);
      localStorage.setItem('refreshTokenCreated', authData.refreshTokenCreated.toString());
      localStorage.setItem('refreshTokenExpires', authData.refreshTokenExpires.toString());
   }
}