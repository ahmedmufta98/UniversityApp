import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ConfigurationService } from "./configuration.service";

@Injectable()
export abstract class BaseCrudService<T>{
    apiUrl: string = 'http://localhost:59720/api/';
    constructor(private configurationService: ConfigurationService, private http: HttpClient, private controller: string) {

    }
    
}