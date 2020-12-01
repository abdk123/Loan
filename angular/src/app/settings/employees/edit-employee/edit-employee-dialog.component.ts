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
  EmployeeServiceProxy,
  EmployeeDto,
  UpdateEmployeeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-employee-dialog.component.html'
})
export class EditEmployeeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  employee: UpdateEmployeeDto = new UpdateEmployeeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _employeeService: EmployeeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._employeeService.getForEdit(this.id).subscribe((result: UpdateEmployeeDto) => {
      this.employee = result;
    });
  }

  save(): void {
    this.saving = true;

    this._employeeService
      .update(this.employee)
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
