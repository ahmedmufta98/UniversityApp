import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class ConfigurationService {
    configUrl = 'assets/config/localhost.json';

    constructor(private http: HttpClient) {}

    getBaseUrl() {
        return this.http.get<JSON>(this.configUrl);
    }
}