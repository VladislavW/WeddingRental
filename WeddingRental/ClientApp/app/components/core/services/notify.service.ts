import { Injectable } from '@angular/core';

import { ToastyService, ToastyConfig, ToastOptions } from 'ng2-toasty';

@Injectable()
export class NotifyService {
    private closeTimeOut = 5000;

    private toastOptions: ToastOptions = {
        title: '',
        showClose: true,
        timeout: this.closeTimeOut
    };

    private getOptions(msg: string | string[]) {
        let message: string;
        if (Array.isArray(msg)) {
            message = msg.join('\r\n');
        } else {
            message = msg;
        }

        return Object.assign(this.toastOptions, { msg: message });
    }

    constructor(
        private toastyService: ToastyService,
        private toastyConfig: ToastyConfig
    ) {
        this.toastyConfig.theme = 'bootstrap';
        this.toastyConfig.showClose = true;
        this.toastyConfig.limit = 25;
    }

    public alertSuccess(msg: string | string[]) {
        if(msg === undefined){
            msg = "";
        }
        this.toastyService.success(this.getOptions(msg));
    }

    public alertWarning(msg: string | string[]) {
        if(msg === undefined){
            msg = "";
        }
        this.toastyService.warning(this.getOptions(msg));
    }

    public alertFail(msg: string | string[]) {
        if(msg === undefined){
            msg = "";
        }
        this.toastyService.error(this.getOptions(msg));
    }
}