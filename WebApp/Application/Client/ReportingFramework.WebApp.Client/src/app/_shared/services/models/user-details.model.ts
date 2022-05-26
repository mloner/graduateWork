import { UserModel } from "./user.model";
import { UserFisFunctionalityModel } from "./user-fis-functionality.model";
import { UserSystemModel } from "./user-system.model";

export class UserDetailsModel extends UserModel {
    systems?: UserSystemModel[];
    fisFunctionalities?: UserFisFunctionalityModel[];
}
