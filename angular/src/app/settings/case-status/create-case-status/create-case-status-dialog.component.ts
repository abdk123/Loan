import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CreateIndexDto,
  CaseStatusServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-case-status-dialog.component.html'
})
export class CreateCaseStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  caseStatus: CreateIndexDto = new CreateIndexDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _caseStatusService: CaseStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._caseStatusService
      .create(this.caseStatus)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
