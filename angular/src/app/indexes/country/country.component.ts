import { ChangeDetectionStrategy, Component, Injector, OnInit } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { EditSettingsModel, FilterSettingsModel, IEditCell, PageSettingsModel, SaveEventArgs, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { CountryServiceProxy, CreateIndexDto, IndexDto } from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent extends AppComponentBase implements OnInit {

  // Grid
  public countries: DataManager;
  public pageSettings: PageSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public filterOption: FilterSettingsModel = { type: 'Menu' };

  constructor(injector: Injector, private _countryAppService: CountryServiceProxy) {
    super(injector);
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6};
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    this.countries = new DataManager({
      url: 'http://localhost:21021/api/Country/GetForGrid',
      insertUrl: 'http://localhost:21021/api/Country/Insert',
      updateUrl: 'http://localhost:21021/api/Country/Update',
      removeUrl: 'http://localhost:21021/api/Country/Delete',
      adaptor: new UrlAdaptor()
  });
  }
  
}


