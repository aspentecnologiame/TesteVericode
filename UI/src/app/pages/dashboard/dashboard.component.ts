import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
    selector     : 'dashboard',
    templateUrl  : './dashboard.component.html',
    encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit
{
    @ViewChild('supportNgForm') supportNgForm: NgForm;
    
    alert: any;
    accountForm: UntypedFormGroup;
    /**
     * Constructor
     */
    constructor(private _formBuilder: UntypedFormBuilder,)
    {
    }

    ngOnInit(): void
    {
        // Create the support form
        this.accountForm = this._formBuilder.group({
            name   : ['', Validators.required],
            email   : ['', Validators.required],
            country   : ['', Validators.required],
            username   : ['', Validators.required],
            title  : ['', [Validators.required]],
            company: ['', Validators.required],
            about: ['', Validators.required],
            phone: ['', Validators.required]
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Clear the form
     */
    clearForm(): void
    {
        // Reset the form
        this.supportNgForm.resetForm();
    }

    /**
     * Send the form
     */
    sendForm(): void
    {
        // Send your form here using an http request
        console.log('Your message has been sent!');

        // Show a success message (it can also be an error message)
        // and remove it after 5 seconds
        this.alert = {
            type   : 'success',
            message: 'Your request has been delivered! A member of our support staff will respond as soon as possible.'
        };

        setTimeout(() => {
            this.alert = null;
        }, 7000);

        // Clear the form
        this.clearForm();
    }
}
