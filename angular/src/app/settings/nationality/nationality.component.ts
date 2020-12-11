import { ChangeDetectionStrategy, Component, Inject, Injector, OnInit, Optional, ViewChild } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { FilterSettingsModel, GridComponent, GroupSettingsModel, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { NationalityServiceProxy} from '@shared/service-proxies/service-proxies';
import { DataManager, UrlAdaptor   } from '@syncfusion/ej2-data';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { EditNationalityDialogComponent } from './edit-nationality/edit-nationality-dialog.component';
import { CreateNationalityDialogComponent } from './create-nationality/create-nationality-dialog.component';


@Component({
  selector: 'app-nationality',
  templateUrl: './nationality.component.html',
  styleUrls: ['./nationality.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NationalityComponent extends AppComponentBase implements OnInit {

  // Grid
  @ViewChild('nationalityGrid') public grid: GridComponent;
  public nationalities: DataManager;
  public pageSettings: PageSettingsModel;
  public pageSizes: number[] = [6, 20, 100];
  public groupOptions: GroupSettingsModel;
  public filterOption: FilterSettingsModel = { type: 'Menu' };
  private baseUrl: string;
  constructor(
    injector: Injector,
    private _nationalityAppService: NationalityServiceProxy,
    private _modalService: BsModalService,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    super(injector);
    this.baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.pageSettings = {pageSize: 6, pageCount: 10, pageSizes: this.pageSizes};
    this.nationalities = new DataManager({
      url: this.baseUrl + '/api/services/app/Nationality/GetForGrid',
      adaptor: new UrlAdaptor()
  });
  }
showCreateDialog() {
  let createNationalityDialog: BsModalRef;
  createNationalityDialog = this._modalService.show(
    CreateNationalityDialogComponent,
    {
      class: 'modal-lg',
    }
  );

  createNationalityDialog.content.onSave.subscribe(() => {
    this.refresh();
  });

}
showEditDialog(id) {
  let editNationalityDialog: BsModalRef;
  editNationalityDialog = this._modalService.show(
    EditNationalityDialogComponent,
    {
      class: 'modal-lg',
      initialState: {
        id: id,
      },
    }
  );
  editNationalityDialog.content.onSave.subscribe(() => {
    this.refresh();
  });
}

delete(data): void {
  abp.message.confirm(
    this.l('DoYouWantToRemoveTheNationality', data.name),
    undefined,
    (result: boolean) => {
      if (result) {
        this._nationalityAppService
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


