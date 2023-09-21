import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { FuseCardModule } from '@fuse/components/card';
import { SharedModule } from 'app/shared/shared.module';
import { LogoutRoutes } from './logout.routing';
import { LogoutComponent } from './logout.component';

@NgModule({
    declarations: [
        LogoutComponent
    ],
    imports     : [
        RouterModule.forChild(LogoutRoutes),
        MatButtonModule,
        FuseCardModule,
        SharedModule
    ]
})
export class LogoutModule
{
}
