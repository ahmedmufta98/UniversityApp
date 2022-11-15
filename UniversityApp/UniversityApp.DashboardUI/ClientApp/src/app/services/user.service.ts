import { Injectable } from "@angular/core";
import { User } from "../models/user";
import { BaseCrudService } from "./baseCrudService";
import { RequestService } from "./requestService";

@Injectable()
export class UserService extends BaseCrudService<User, number>{
  constructor(protected requestService: RequestService) {
    super(requestService, "users/");
  }
}