import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';

// ng-zorro
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule, NZ_ICONS } from 'ng-zorro-antd/icon';
import { IconDefinition } from '@ant-design/icons-angular';
import { AccountBookFill, AlertFill, AlertOutline } from '@ant-design/icons-angular/icons';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import * as AllIcons from '@ant-design/icons-angular/icons';
import { EditService, FilterService, GridModule, GroupService, PagerModule, PageService, SortService, ToolbarService } from '@syncfusion/ej2-angular-grids';
import { CountryComponent } from './settings/country/country.component';
import { EmployeeComponent } from './settings/employees/employee.component';
import { CreateEmployeeDialogComponent } from './settings/employees/create-employee/create-employee-dialog.component';
import { CaseStatusServiceProxy, CountryServiceProxy, EmployeeServiceProxy, NationalityServiceProxy } from '@shared/service-proxies/service-proxies';
import { EditEmployeeDialogComponent } from './settings/employees/edit-employee/edit-employee-dialog.component';
import { EditCountryDialogComponent } from './settings/country/edit-country/edit-country-dialog.component';
import { CreateCountryDialogComponent } from './settings/country/create-country/create-country-dialog.component';
import { NationalityComponent } from './settings/nationality/nationality.component';
import { EditNationalityDialogComponent } from './settings/nationality/edit-nationality/edit-nationality-dialog.component';
import { CreateNationalityDialogComponent } from './settings/nationality/create-nationality/create-nationality-dialog.component';
import { CaseStatusComponent } from './settings/case-status/case-status.component';
import { CreateCaseStatusDialogComponent } from './settings/case-status/create-case-status/create-case-status-dialog.component';
import { EditCaseStatusDialogComponent } from './settings/case-status/edit-case-status/edit-case-status-dialog.component';
import { ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { en_US, NZ_I18N } from 'ng-zorro-antd/i18n';
import { GrudToolbarComponent } from './grud/grud-toolbar.component';
import { GrudColumnComponent } from './grud/grud-column/grud-column.component';

const antDesignIcons = AllIcons as {
  [key: string]: IconDefinition;
};
const icons: IconDefinition[] = Object.keys(antDesignIcons).map(key => antDesignIcons[key]);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent,
    GrudToolbarComponent,
    // employees
    EmployeeComponent,
    CreateEmployeeDialogComponent,
    EditEmployeeDialogComponent,
    // Country
    CountryComponent,
    EditCountryDialogComponent,
    CreateCountryDialogComponent,
    // Nationality
    NationalityComponent,
    EditNationalityDialogComponent,
    CreateNationalityDialogComponent,
    // Case Status
    CaseStatusComponent,
    CreateCaseStatusDialogComponent,
    EditCaseStatusDialogComponent,
    GrudColumnComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    GridModule,
    ToolbarModule,
    // ng-zorro
    NzBreadCrumbModule,
    NzIconModule,
    NzButtonModule,
    NzInputModule,
    NzSelectModule
  ],
  providers: [
    CountryServiceProxy,
    EmployeeServiceProxy,
    PageService,
    SortService,
    FilterService,
    GroupService,
    ToolbarService,
    EditService,
    CountryServiceProxy,
    NationalityServiceProxy,
    CaseStatusServiceProxy,
    { provide: NZ_I18N, useValue: en_US }, { provide: NZ_ICONS, useValue: icons }
  ],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
    // employees
    CreateEmployeeDialogComponent,
    EditEmployeeDialogComponent,

    // Country
    EditCountryDialogComponent,
    CreateCountryDialogComponent,

    // Nationality
    EditNationalityDialogComponent,
    CreateNationalityDialogComponent,

    // Case Status
    CreateCaseStatusDialogComponent,
    EditCaseStatusDialogComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule {}
