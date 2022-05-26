//import {Skin} from '../../../interfaces/skins.interfaces';
import construct = Reflect.construct;

export class UserInfoModel {
  username!: string;
  role?: string;
  userlevel?: number;
  permissions!: string[];
  skin?: any;
  telegramKey!: string;
  LastSyncTimeStamp?: Date;
  }

