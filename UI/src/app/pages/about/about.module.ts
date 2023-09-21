import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from 'app/shared/shared.module';
import { AboutComponent } from './about.component';
import { AboutRoutes } from './about.routing';

@NgModule({
    declarations: [
        AboutComponent
    ],
    imports     : [
        RouterModule.forChild(AboutRoutes),
        MatButtonModule,
        MatIconModule,
        SharedModule
    ]
})
export class AboutModule
{
}
