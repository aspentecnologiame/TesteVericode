import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { TaskModel } from './models/task.model';
import { Task, TaskLabelMapping } from './models/enums/task.enum';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { DashboardService } from './dashboard.service';

const ELEMENT_DATA: TaskModel[] = [
    {id: 1, description: 'Hydrogen', status: 'H', date: '2023-09-22'},
    {id: 2, description: 'Helium', status: 'He', date: '2023-09-22'},
    {id: 3, description: 'Lithium', status: 'Li', date: '2023-09-22'},
    {id: 4, description: 'Beryllium', status: 'Be', date: '2023-09-22'},
    {id: 5, description: 'Boron', status: 'B', date: '2023-09-22'},
    {id: 6, description: 'Carbon', status: 'C', date: '2023-09-22'},
    {id: 7, description: 'Nitrogen', status: 'N', date: '2023-09-22'},
    {id: 8, description: 'Oxygen', status: 'O', date: '2023-09-22'},
    {id: 9, description: 'Fluorine', status: 'F', date: '2023-09-22'},
    {id: 10, description: 'Neon', status: 'Ne', date: '2023-09-22'},
];

@Component({
    selector     : 'dashboard',
    templateUrl  : './dashboard.component.html',
    encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit
{
    public tasks = Object.values(Task).filter(value => typeof value === 'number');
    public TaskLabelMapping = TaskLabelMapping;

    displayedColumns: string[] = ['id', 'description', 'status', 'date'];
    dataSource = ELEMENT_DATA;

    alert: any;
    taskForm: UntypedFormGroup;
    configForm: UntypedFormGroup;

    id: string = '00000000-0000-0000-0000-000000000000';

    /**
     * Constructor
     */
    constructor(
        private _formBuilder: UntypedFormBuilder,
        private _fuseConfirmationService: FuseConfirmationService,
        private _dashboardService: DashboardService)
    {
    }

    ngOnInit(): void
    {
        // Create the support form
        this.taskForm = this._formBuilder.group({
            id: [this.id],
            description : ['', Validators.required],
            status : ['', Validators.required],
            date : ['', Validators.required]
        });

        // Build the config form
        this.configForm = this._formBuilder.group({
            title      : 'Task Manager',
            message    : 'You want to save the task? <span class="font-medium">This action cannot be undone!</span>',
            icon       : this._formBuilder.group({
                show : true,
                name : 'heroicons_outline:exclamation',
                color: 'accent'
            }),
            actions    : this._formBuilder.group({
                confirm: this._formBuilder.group({
                    show : true,
                    label: 'Confirm',
                    color: 'primary'
                }),
                cancel : this._formBuilder.group({
                    show : true,
                    label: 'Cancel'
                })
            }),
            dismissible: true
        });

        this._dashboardService.startHubTaskConnection();
        this._dashboardService.addTransferTaskDataListener();
        const teste = this._dashboardService.getAll().subscribe({
            next: (response) => {
                this.dataSource = response.data;
            },
            error: (err) => {
                console.log(err);
            }
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
        //this.taskForm.reset();
        //this.taskForm.controls['id'].setValue(this.id);
    }

    /**
     * Send the form
     */
    sendForm(): void
    {
        // Open the dialog and save the reference of it
        const dialogRef = this._fuseConfirmationService.open(this.configForm.value);

        // Subscribe to afterClosed from the dialog reference
        dialogRef.afterClosed().subscribe((result) => {

            this._dashboardService.save(this.taskForm.value)
            .subscribe({
                next: (response) => {

                    console.log(response);

                    // Clear the form
                    this.clearForm();
                },
                error: (err) => {
                    console.log(err);
                }
            });
            console.log(result);
        });  
    }
}
