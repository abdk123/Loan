import { Component, Injector, OnInit, ViewEncapsulation, NgZone, ViewChild, TemplateRef } from '@angular/core';
import { IFormattedUserNotification, UserNotificationHelper } from './UserNotificationHelper';
import { AppComponentBase } from '@shared/app-component-base';
import * as _ from 'lodash';
import { NotificationServiceProxy, UserNotification } from '@shared/service-proxies/service-proxies';
import { NzDrawerRef, NzDrawerService } from 'ng-zorro-antd/drawer';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
    templateUrl: './header-notifications.component.html',
    styleUrls: ['./header-notifications.component.css'],
    selector: '[headerNotifications]',
    encapsulation: ViewEncapsulation.None
})
export class HeaderNotificationsComponent extends AppComponentBase implements OnInit {
    @ViewChild('drawerTemplate', { static: false }) drawerTemplate?: TemplateRef<{
        $implicit: { value: string };
        drawerRef: NzDrawerRef<string>;
      }>;
      @ViewChild('fotterTemplate', { static: false }) fotterTemplate?: TemplateRef<any>;
    notifications: IFormattedUserNotification[] = [];
    currentNotification: IFormattedUserNotification = {title:"", creationTime: new Date(), data:null, icon :"", isUnread :false, state :"", text: "", time: "", url: "", userNotificationId: null};
    unreadNotificationCount = 0;
    visible = false;
    isVisible = false;
    title = "Notifications (5)";

    constructor(
        injector: Injector,
        private _notificationService: NotificationServiceProxy,
        private _userNotificationHelper: UserNotificationHelper,
        private drawerService: NzDrawerService,
        private modalService: NzModalService,
        public _zone: NgZone
    ) {
        super(injector);
    }

    ngOnInit(): void {
        debugger;
        this.loadNotifications();
        this.registerToEvents();
    }
    showModal(notification:IFormattedUserNotification): void {
        this.setNotificationAsRead(notification);
        this.currentNotification = notification;
        this.visible = false;
        this.isVisible = true;
      }
    
      handleOk(): void {
        this.isVisible = false;
      }
    openTemplate(): void {
        const drawerRef = this.drawerService.create({
          nzTitle: 'Template',
          nzFooter: this.fotterTemplate,
          nzContent: this.drawerTemplate,
          nzContentParams: {
            value: "test"
          }
        });
    
        drawerRef.afterOpen.subscribe(() => {
          console.log('Drawer(Template) open');
        });
    
        drawerRef.afterClose.subscribe(() => {
          console.log('Drawer(Template) close');
        });
      }
    
    open(): void {
      this.visible = true;
    }
  
    close(): void {
      this.visible = false;
    }
    loadNotifications(): void {
        this._notificationService.getUserNotifications(undefined, 10, 0).subscribe(result => {
            this.unreadNotificationCount = result.unreadCount;
            this.notifications = [];
            _.forEach(result.items, (item: UserNotification) => {
                this.notifications.push(this._userNotificationHelper.format(<any>item));
                console.log(this.notifications);
            });
        });
    }

    registerToEvents() {
        let self = this;

        function onNotificationReceived(userNotification) {
            self._userNotificationHelper.show(userNotification);
            self.loadNotifications();
        }

        abp.event.on('abp.notifications.received', userNotification => {
            self._zone.run(() => {
                onNotificationReceived(userNotification);
            });
        });

        function onNotificationsRefresh() {
            self.loadNotifications();
        }

        abp.event.on('app.notifications.refresh', () => {
            self._zone.run(() => {
                onNotificationsRefresh();
            });
        });

        function onNotificationsRead(userNotificationId) {
            for (let i = 0; i < self.notifications.length; i++) {
                if (self.notifications[i].userNotificationId === userNotificationId) {
                    self.notifications[i].state = 'READ';
                }
            }

            self.unreadNotificationCount -= 1;
        }

        abp.event.on('app.notifications.read', userNotificationId => {
            self._zone.run(() => {
                onNotificationsRead(userNotificationId);
            });
        });
    }

    setAllNotificationsAsRead(): void {
        this._userNotificationHelper.setAllAsRead();
    }

    // openNotificationSettingsModal(): void {
    //     this._userNotificationHelper.openSettingsModal();
    // }

    setNotificationAsRead(userNotification: IFormattedUserNotification): void {
        this._userNotificationHelper.setAsRead(userNotification.userNotificationId);
    }

    gotoUrl(url): void {
        if (url) {
            location.href = url;
        }
    }
}
