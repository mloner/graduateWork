export interface NewEditComponentRow {
  componentId: number;
  componentName: string;
  componentTypeId: number;
  dateTime: string;
  paramValueRowModels: ParamValueRowModels[];
}

export interface NewEditComponentCreate {
  componentId: number;
  componentName: string;
  componentTypeId: number;
  dateTime: Date;
  paramValueRowModels: ParamValueRowModels[];
}

export interface ParamValueRowModels{
  componentParameterId: number;
  componentParameterName: string;
  pythonParam: string;
  unit: string;
  desctiption:string;
  validity: boolean;
  componentValueId: number;
  value?: string;
  valueTypeId: number;
}

export interface ComponentModel{
  componentId: number;
  name: string;
  componentTypeId: number;
  dateAdded: string;
  notDeleted: boolean;
}

export interface Type{
  componentTypeId: number;
  name: string;
  haveParent: boolean;
  notDeleted: boolean;
}

export interface ComponentConfiguration {
  componentTypeId: number;
  componentId: number;
  parentId: number;
  componentsByType: ComponentModel[];
  types: Type[];
  parents: ComponentConfiguration[];
}

export interface ConfigurationModel {
  configurationId: number;
  name: string;
  dateTime: string;
  link: string;
  notDeleted: boolean;
}

export interface ConfigurationsComponentsModel {
  configurationComponentId: number;
  configurationId: number;
  componentId: number;
  parentId: number;
}

export interface ConfigurationElemModel {
  configurationModel: ConfigurationModel,
  configurationsComponentsModel: ConfigurationsComponentsModel;
}

export interface ComponentProperty {
  componentPropertyId: number;
  componentId: number;
  timeStamp: string;
  value: string;
  notDeleted: boolean;
}

export interface Cug {
  guid: string;
  name: string;
}

export interface Building {
  guid: string;
  name: string;
}

export interface Measurement {
  guid: string;
  name: string;
}

export interface MeasurementFull {
  guid: string;
  name: string;
  buildingGuid: string;
}

export interface ConfigBuildings {
  buildId: number;
  name: string;
  energySystem: any;
  scenario:any;
  check: boolean;
}

export interface ConfigurationPropertyModel {
  configurationPropertyId: number;
  name: string;
  componentTypeId: number;
}

export interface ConfigComponentProperty {
  configurationPropertiesComponents: ConfigurationPropertiesComponents[];
  properties: ConfigurationPropertyModel[];
}

export interface ConfigurationPropertiesComponents {
  configurationPropertyComponentId: number;
  configurationPropertyId: number;
  configurationComponentId: number;
  value: string;
}

export interface EditSaveConfiguration {
  componentConfigurations: ComponentConfiguration[];
  configurationPropertiesComponents: any;
}


export interface CugsList {
  name: string;
  guid: string;
}

export interface UserShortInfo {
  userId: number;
  responsible: string;
  userGuid: string;
  userKey: string;
  lastSync: Date;
}

export interface MainData {
  userShortInfo?: UserShortInfo;
  cugsList: CugsList[];
}

