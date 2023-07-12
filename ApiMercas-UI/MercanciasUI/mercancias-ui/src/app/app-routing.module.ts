import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MercanciasComponent } from './mercancias/mercancias.component';

const routes: Routes = [
  {
    path: '',
    component: MercanciasComponent
  },
  {
    path: 'mercancias',
    component: MercanciasComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
