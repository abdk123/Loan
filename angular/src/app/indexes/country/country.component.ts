import { ChangeDetectionStrategy, Component, Injector, OnInit } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent extends AppComponentBase {

  constructor(injector: Injector) {
    super(injector);
  }

  createCountry(){

  }
}
