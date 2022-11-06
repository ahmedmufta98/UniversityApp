import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthResponse } from "../dtos/authResponseDto";
import { UserLoginRequest } from "../dtos/userLoginDto";

@Injectable()
export class AuthService{
   constructor(private http: HttpClient){}

   public Login(request: UserLoginRequest):Promise<any>{
      return this.http.post("https://localhost:7272/api/tokens/login", request).toPromise().then(x=>{
         if(x){
            this.saveAuthData(x);
         }
      });
   }

   saveAuthData(authData: any){
      localStorage.setItem('accessToken', authData.accessToken);
      localStorage.setItem('refreshToken', authData.refreshToken);
      localStorage.setItem('userId', authData.userId.toString());
      localStorage.setItem('role', authData.role);
      localStorage.setItem('refreshTokenCreated', authData.refreshTokenCreated.toString());
      localStorage.setItem('refreshTokenExpires', authData.refreshTokenExpires.toString());
   }
}