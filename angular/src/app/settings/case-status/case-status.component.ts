import { ChangeDetectionStrategy, Component, Inject, Injector, OnInit, Optional, ViewChild } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { FilterSettingsModel, GridComponent, GroupSettingsModel, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { CaseStatusServiceProxy} from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { EditCaseStatusDialogComponent } from './edit-case-status/edit-case-status-dialog.component';
import { CreateCaseStatusDialogComponent } from './create-case-status/create-case-status-dialog.component';

@Component({
  selector: 'app-case-status',
  templateUrl: './case-status.component.html',
  styleUrls: ['./case-status.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CaseStatusComponent extends AppComponentBase implements OnInit {

  // Grid
  @ViewChild('caseStatusGrid') public grid: GridComponent;
  public allCaseStatus: DataManager;
  public pageSettings: PageSettingsModel;
  public pageSizes: number[] = [6, 20, 100];
  public groupOptions: GroupSettingsModel;
  public filterOption: FilterSettingsModel = { type: 'Menu' };
  private baseUrl: string;
  constructor(
    injector: Injector,
    private _caseStatusAppService: CaseStatusServiceProxy,
    private _modalService: BsModalService,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    super(injector);
    this.baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6, pageCount: 10, pageSizes: this.pageSizes};
    this.allCaseStatus = new DataManager({
      url: this.baseUrl + '/api/services/app/CaseStatus/GetForGrid',
      adaptor: new UrlAdaptor()
  });
  }
showCreateDialog() {
  let createCaseStatusDialog: BsModalRef;
  createCaseStatusDialog = this._modalService.show(
    CreateCaseStatusDialogComponent,
    {
      class: 'modal-lg',
    }
  );

  createCaseStatusDialog.content.onSave.subscribe(() => {
    this.refresh();
  });

}
showEditDialog(id) {
  let editCaseStatusDialog: BsModalRef;
  editCaseStatusDialog = this._modalService.show(
    EditCaseStatusDialogComponent,
    {
      class: 'modal-lg',
      initialState: {
        id: id,
      },
    }
  );
  editCaseStatusDialog.content.onSave.subscribe(() => {
    this.refresh();
  });
}

delete(data): void {
  abp.message.confirm(
    this.l('DoYouWantToRemoveTheCaseStatus', data.name),
    undefined,
    (result: boolean) => {
      if (result) {
        this._caseStatusAppService
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




