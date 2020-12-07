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
  CountryServiceProxy, UpdateIndexDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-country-dialog.component.html'
})
export class EditCountryDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  country: UpdateIndexDto = new UpdateIndexDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _countryService: CountryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._countryService.getForEdit(this.id).subscribe((result: UpdateIndexDto) => {
      this.country = result;
    });
  }

  save(): void {
    this.saving = true;

    this._countryService
      .update(this.country)
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
