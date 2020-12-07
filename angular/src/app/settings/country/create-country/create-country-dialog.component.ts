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
  CountryServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-country-dialog.component.html'
})
export class CreateCountryDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  country: CreateIndexDto = new CreateIndexDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _countryService: CountryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._countryService
      .create(this.country)
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
