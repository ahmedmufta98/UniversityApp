import { Injectable } from "@angular/core";
import { Role } from "../models/role";
import { BaseCrudService } from "./baseCrudService";
import { RequestService } from "./requestService";

@Injectable()
export class RoleService extends BaseCrudService<Role, string>{
    constructor(protected requestService: RequestService) {
        super(requestService, "roles/");
    }
}