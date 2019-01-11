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
        path: 'catalog',
        loadChildren: './components/catalog/catalog.module#CatalogModule'
    },
    {
        path: 'order',
        loadChildren: './components/order/order.module#OrderModule'
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
