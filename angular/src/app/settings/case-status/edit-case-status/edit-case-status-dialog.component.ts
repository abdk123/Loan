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
  CaseStatusServiceProxy, UpdateIndexDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-case-status-dialog.component.html'
})
export class EditCaseStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  caseStatus: UpdateIndexDto = new UpdateIndexDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _caseStatusService: CaseStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._caseStatusService.getForEdit(this.id).subscribe((result: UpdateIndexDto) => {
      this.caseStatus = result;
    });
  }

  save(): void {
    this.saving = true;

    this._caseStatusService
      .update(this.caseStatus)
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
