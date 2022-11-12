import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { RequestService } from "./requestService";

@Injectable()
export abstract class BaseCrudService<T, Tkey>{
    constructor(protected requestService: RequestService, @Inject(String) protected controller: string) {}

    public get(): Observable<T[]> {
        return <Observable<T[]>>this.requestService.get(this.controller);
    }

    public getById(param: Tkey): Observable<T> {
        return <Observable<T>>this.requestService.get(this.controller.concat(param.toString()));
    }

    public post(body: T): Observable<T> {
        return <Observable<T>>this.requestService.post(this.controller, body);
    }

    public put(body: T, param: Tkey): Observable<T> {
        return <Observable<T>>this.requestService.put(this.controller.concat(param.toString()), body, param);
    }

    public delete(param: Tkey): Observable<T> {
        return <Observable<T>>this.requestService.delete(this.controller.concat(param.toString()), param);
    }
}