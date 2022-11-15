import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthResponse } from "../dtos/authResponseDto";
import { UserLoginRequest } from "../dtos/userLoginDto";
import { RequestService } from "./requestService";

@Injectable()
export class AuthService {
   constructor(private requestService: RequestService) { }

   public Login(request: UserLoginRequest): Observable<AuthResponse> {
      return this.requestService.post("tokens/login", request);
   }

   public saveAuthData(authData: AuthResponse) {
      localStorage.setItem('accessToken', authData.AccessToken);
      localStorage.setItem('refreshToken', authData.RefreshToken);
      localStorage.setItem('userId', authData.UserId.toString());
      localStorage.setItem('role', authData.Role);
      localStorage.setItem('refreshTokenCreated', authData.RefreshTokenCreated.toString());
      localStorage.setItem('refreshTokenExpires', authData.RefreshTokenExpires.toString());
   }
}