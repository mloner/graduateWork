import { Component, OnInit } from '@angular/core';
import {SortEvent} from "primeng/api";
import {ConfigBuildings} from "../../interfaces/MeteData.interfaces";

@Component({
  selector: 'app-config-buildings',
  templateUrl: './config-buildings.component.html',
  styleUrls: ['./config-buildings.component.css']
})
export class ConfigBuildingsComponent implements OnInit {

  config: ConfigBuildings[]=[
    {buildId:1, name: "111", energySystem:[], scenario:[], check: false},
    {buildId:2, name: "222", energySystem:[], scenario:[], check: false},
  ];
  buildings: any = ["11"];
  checkBuild: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  customSort(event: SortEvent) {
    event.data?.sort((data1, data2) => {
      let value1 = data1[event.field??1];
      let value2 = data2[event.field??2];
      let result = null;

      if (value1 == null && value2 != null)
        result = -1;
      else if (value1 != null && value2 == null)
        result = 1;
      else if (value1 == null && value2 == null)
        result = 0;
      else if (typeof value1 === 'string' && typeof value2 === 'string')
        result = value1.localeCompare(value2);
      else
        result = (value1 < value2) ? -1 : (value1 > value2) ? 1 : 0;

      return (event.order??1 * result);
    });
  }

  getEventValue($event:any) :string {
    return $event.target.value;
  }

  clickCheckBuild(){
    this.checkBuild = !this.checkBuild;
    // активировать все checkboxs на странице
    for(var i=0; i<this.config.length; i++){
      this.config[i].check = this.checkBuild;
    }
  }

}
