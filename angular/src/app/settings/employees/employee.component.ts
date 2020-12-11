import { ChangeDetectionStrategy, Component, Inject, Injector, OnInit, Optional, ViewChild } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { DialogEditEventArgs, EditSettingsModel, FilterSettingsModel, GridComponent, IEditCell, PageSettingsModel, SaveEventArgs, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { EmployeeServiceProxy} from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateEmployeeDialogComponent } from './create-employee/create-employee-dialog.component';
import { finalize } from 'rxjs/operators';
import { EditEmployeeDialogComponent } from './edit-employee/edit-employee-dialog.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployeeComponent extends AppComponentBase implements OnInit {

  // Grid
  @ViewChild('employeeGrid') public grid: GridComponent;
  public employees: DataManager;
  public pageSettings: PageSettingsModel;
  public pageSizes: number[] = [6, 20, 100];
  public toolbar: any;
  public filterOption: FilterSettingsModel = { type: 'Menu' };
  public employeeTypeData: any = [
    {'employeeType': 1 , 'text': 'Coordinator'},
    {'employeeType': 2 , 'text': 'Mis'},
    {'employeeType': 3 , 'text': 'TeamLeader'},
    {'employeeType': 4 , 'text': 'Negotiator'}
  ];
  private baseUrl: string;
  constructor(
    injector: Injector,
    private _employeeAppService: EmployeeServiceProxy,
    private _modalService: BsModalService,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    super(injector);
    this.baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6, pageCount: 10, pageSizes: this.pageSizes};
    this.toolbar = [
      { text: 'Add', tooltipText: 'Add', prefixIcon: 'e-add ', id: 'Add' },
      { text: this.l('Clear Filters'), tooltipText: this.l('ClearFilters'), prefixIcon: 'e-icon-filter', id: 'ClearFilters' },
      { text: this.l('Clear Sorts'), tooltipText: this.l('ClearSorts'), prefixIcon: 'e-icon-ascending', id: 'ClearSorts' },
    ];
    this.employees = new DataManager({
      url: this.baseUrl + '/api/services/app/Employee/GetForGrid',
      adaptor: new UrlAdaptor()
  });
  }
  onClickToolbar(args: any) {
    switch (args.item.id) {
      case 'Add':
          this.showCreateDialog();
          break;
      case 'ClearFilters':
        this.grid.clearFiltering();
        break;
      case 'ClearSorts':
        this.grid.clearSorting();
        break;
  }
}
showCreateDialog() {
  let createEmployeeDialog: BsModalRef;
  createEmployeeDialog = this._modalService.show(
    CreateEmployeeDialogComponent,
    {
      class: 'modal-lg',
    }
  );

  createEmployeeDialog.content.onSave.subscribe(() => {
    this.refresh();
  });

}
showEditDialog(id) {
  let editEmployeeDialog: BsModalRef;
  editEmployeeDialog = this._modalService.show(
    EditEmployeeDialogComponent,
    {
      class: 'modal-lg',
      initialState: {
        id: id,
      },
    }
  );
  editEmployeeDialog.content.onSave.subscribe(() => {
    this.refresh();
  });
}

delete(data): void {
  abp.message.confirm(
    this.l('DoYouWantToRemoveTheEmployee', data.name),
    undefined,
    (result: boolean) => {
      if (result) {
        this._employeeAppService
          .delete(data.id)
          .pipe(
            finalize(() => {
              abp.notify.success(this.l('SuccessfullyDeleted'));
              this.refresh();
            })
          )
          .subscribe(() => {});
      }
    }
  );
}
refresh() {
  this.grid.refresh();
}
clearFilters() {
  this.grid.clearFiltering();
}
clearSorts() {
  this.grid.clearSorting();
}

}


