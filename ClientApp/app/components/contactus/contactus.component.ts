import { Component } from "@angular/core";
import { ContactUs } from "../../shared/models/contactus.interface";
import { ContactUsService } from "../../services/contactus.service";
import { ToastyService } from "ng2-toasty";

@Component({
    selector: "contactus",
    templateUrl: "contactus.component.html",
    styleUrls: ["contactus.component.css"]
})
export class ContactusComponent{ 
    contactUsData: ContactUs = {
        name: "",
        email: "",
        phoneNumber: "",
        message: ""
    };
    errors: string;
    info: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private contactUsService: ContactUsService,
        private toastyService: ToastyService) {
    }    

    infoClose() {
        this.info = "";
    }

    submit() {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        this.contactUsService.sendMessage(this.contactUsData)
            .finally(() => this.isRequesting = false)
            .subscribe(
            result => {
                var infoMessage = "Your message has been sent";
                this.info = infoMessage;
                this.toastyService.success({
                    title: "Message",
                    msg: infoMessage,
                    theme: "bootstrap",
                    showClose: true,
                    timeout: 5000
                });
            },
            errors => {
                this.errors = errors;
                this.toastyService.error({
                    title: 'Error',
                    msg: `Your message was not sent: ${errors}`,
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });            
    }
}