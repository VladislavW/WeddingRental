import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        loadChildren: './components/home/home.module#HomeModule'
    },
    {
        path: 'auth',
        loadChildren: './components/auth/auth.module#AuthModule'
    },
    {
        path: 'fetch-data',
        loadChildren: './components/fetchdata/fetchdata.module#FetchDataModule'
    },
    {
        path: 'signup',
        loadChildren: './components/signup/signup.module#SignUpModule'
    },
    {
        path: '**',
        redirectTo: ''
    }
];

export const AppRoutes = RouterModule.forRoot(routes);
