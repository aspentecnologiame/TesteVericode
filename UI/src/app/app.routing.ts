import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { NoAuthGuard } from 'app/core/auth/guards/noAuth.guard';
import { LayoutComponent } from 'app/layout/layout.component';
import { InitialDataResolver } from 'app/app.resolvers';


export const appRoutes: Route[] = [

    // Redirect routes
    {
        path: '', 
        pathMatch : 'full', 
        redirectTo: 'login'
    },

    {
        path: 'login-redirect', 
        pathMatch : 'full', 
        redirectTo: 'dashboard'
    },

    // Auth routes for guests
    {
        path: '',
        canMatch: [NoAuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'login', loadChildren: () => import('app/pages/auth/login/login.module').then(m => m.LoginModule)},
        ]
    },

    // Auth routes for authenticated users
    {
        path: '',
        canMatch: [AuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'logout', loadChildren: () => import('app/pages/auth/logout/logout.module').then(m => m.LogoutModule)},
        ]
    },

    //#Marcao - ROUTES - Aqui é onde vc irá assinar as rotas SIM autenticadas 
    // Pages routes
    {
        path: '',
        canMatch: [AuthGuard],
        component: LayoutComponent,
        resolve: {
            initialData: InitialDataResolver,
        },
        children: [
            {path: 'dashboard', loadChildren: () => import('app/pages/dashboard/dashboard.module').then(m => m.DashboardModule)},
            {path: 'about', loadChildren: () => import('app/pages/about/about.module').then(m => m.AboutModule)},
        ]
    },

    // Auth routes for guests
    //#Marcao - ROUTES - Aqui é onde vc irá assinar as rotas NÃO autenticadas caso necessario
    // {
    //     path: '',
    //     canMatch: [NoAuthGuard],
    //     component: LayoutComponent,
    //     data: {
    //         layout: 'empty'
    //     },
    //     children: [
    //         {path: 'landinpages', loadChildren: () => import('app/pages/landinpages/landinpages/landinpages.module').then(m => m.LandinPagesModule)},
    //     ]
    // }
];
