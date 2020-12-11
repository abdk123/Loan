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
  NationalityServiceProxy, UpdateIndexDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-nationality-dialog.component.html'
})
export class EditNationalityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  nationality: UpdateIndexDto = new UpdateIndexDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _nationalityService: NationalityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._nationalityService.getForEdit(this.id).subscribe((result: UpdateIndexDto) => {
      this.nationality = result;
    });
  }

  save(): void {
    this.saving = true;

    this._nationalityService
      .update(this.nationality)
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
