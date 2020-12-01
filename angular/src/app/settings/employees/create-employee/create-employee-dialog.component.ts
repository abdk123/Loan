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
  CreateEmployeeDto,
  EmployeeServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-employee-dialog.component.html'
})
export class CreateEmployeeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  employee: CreateEmployeeDto = new CreateEmployeeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _employeeService: EmployeeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._employeeService
      .create(this.employee)
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
