import { ChangeDetectionStrategy, Component, Inject, Injector, OnInit, Optional } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { DialogEditEventArgs, EditSettingsModel, FilterSettingsModel, IEditCell, PageSettingsModel, SaveEventArgs, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { CountryServiceProxy} from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';

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
  private baseUrl: string;
  constructor(injector: Injector, private _countryAppService: CountryServiceProxy, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    super(injector);
    this.baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6};
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    this.countries = new DataManager({
      url: this.baseUrl + '/api/Country/GetForGrid',
      insertUrl: this.baseUrl + '/api/Country/Insert',
      updateUrl: this.baseUrl + '/api/Country/Update',
      removeUrl: this.baseUrl + '/api/Country/Delete',
      adaptor: new UrlAdaptor()
  });
  }
  actionBegin(args: SaveEventArgs) {
    if (args.requestType === 'beginEdit' || args.requestType === 'add') {
        //console.log(args.requestType);
    }
    if (args.requestType === 'save') {
      //console.log(args);
    }
}
// actionComplete(args: DialogEditEventArgs): void {
//   if ((args.requestType === 'beginEdit' || args.requestType === 'add')) {
//     console.log(args);
//       args.form.ej2_instances[0].rules = {};
      
//       // Set initail Focus
//       if (args.requestType === 'beginEdit') {
//           (args.form.elements.namedItem('Id') as HTMLInputElement).focus();
//           console.log(args);
//       }
//   }
// }

}


