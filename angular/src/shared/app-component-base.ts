import { Injector, ElementRef } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import {
    LocalizationService,
    PermissionCheckerService,
    FeatureCheckerService,
    NotifyService,
    SettingService,
    MessageService,
    AbpMultiTenancyService
} from 'abp-ng2-module';

import { AppSessionService } from '@shared/session/app-session.service';
import { AppUrlService } from './nav/app-url.service';

export abstract class AppComponentBase {

    localizationSourceName = AppConsts.localization.defaultLocalizationSourceName;

    localization: LocalizationService;
    permission: PermissionCheckerService;
    feature: FeatureCheckerService;
    notify: NotifyService;
    setting: SettingService;
    message: MessageService;
    multiTenancy: AbpMultiTenancyService;
    appSession: AppSessionService;
    appUrlService:AppUrlService;
    constructor(injector: Injector) {
        this.localization = injector.get(LocalizationService);
        this.permission = injector.get(PermissionCheckerService);
        this.feature = injector.get(FeatureCheckerService);
        this.notify = injector.get(NotifyService);
        this.setting = injector.get(SettingService);
        this.message = injector.get(MessageService);
        this.appUrlService = injector.get(AppUrlService);
        this.multiTenancy = injector.get(AbpMultiTenancyService);
        this.appSession = injector.get(AppSessionService);
    }

    l(key: string, ...args: any[]): string {
        let localizedText = this.localization.localize(key, this.localizationSourceName);

        if (!localizedText) {
            localizedText = key;
        }

        if (!args || !args.length) {
            return localizedText;
        }

        args.unshift(localizedText);
        return abp.utils.formatString.apply(this, args);
    }
    appRootUrl(): string {
        return this.appUrlService.appRootUrl;
    }
    isGranted(permissionName: string): boolean {
        return this.permission.isGranted(permissionName);
    }
}
