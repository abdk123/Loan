import { ChangeDetectionStrategy, Component, Injector, OnInit } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '../../../shared/app-component-base';
import { EditSettingsModel, FilterSettingsModel, IEditCell, PageSettingsModel, SaveEventArgs, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { NationalityServiceProxy, CreateIndexDto, IndexDto } from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-nationality',
  templateUrl: './nationality.component.html',
  styleUrls: ['./nationality.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NationalityComponent extends AppComponentBase implements OnInit {

  // Grid
  public nationalities: DataManager;
  public pageSettings: PageSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public filterOption: FilterSettingsModel = { type: 'Menu' };

  constructor(injector: Injector, private _nationalityAppService: NationalityServiceProxy) {
    super(injector);
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6};
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    this.nationalities = new DataManager({
      url: 'http://localhost:21021/api/services/app/Nationality/GetAllForGrid',
      insertUrl: 'http://localhost:21021/api/services/app/Nationality/Insert',
      updateUrl: 'http://localhost:21021/api/services/app/Nationality/Update',
      removeUrl: 'http://localhost:21021/api/services/app/Nationality/Delete',
      adaptor: new UrlAdaptor()
  });
  }
  
}


