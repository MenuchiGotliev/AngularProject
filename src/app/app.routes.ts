import { Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', loadChildren: () => import('./login-page/login-page.module').then(c => c.LoginPageModule) },
    { path: 'recipe', loadChildren: () => import('./recipe/recipe.module').then(r => r.RecipeModule) },
     { path: '**', component:NotFoundComponent },

];
