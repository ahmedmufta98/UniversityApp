import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable()
export class RequestService {

    constructor(private http: HttpClient) { }
    apiUrl: string = environment.apiUrl;
    httpHeader = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem('accessToken'));

    public get(path: string): Observable<any> {
        return this.http.get(this.apiUrl.concat(path), { headers: this.httpHeader });
    }

    public post(path: string, body: any): Observable<any> {
        return this.http.post(this.apiUrl.concat(path), body, { headers: this.httpHeader });
    }

    public put(path: string, body: any, param: any): Observable<any> {
        return this.http.put(this.apiUrl.concat(path), body, { headers: this.httpHeader, params: param });
    }

    public delete(path: string, param: any): Observable<any> {
        return this.http.delete(this.apiUrl.concat(path), { headers: this.httpHeader, params: param });
    }
}