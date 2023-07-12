import { Component } from '@angular/core';
import { MercanciasService } from './mercancias.service';

@Component({
  selector: 'app-mercancias',
  templateUrl: './mercancias.component.html',
  styleUrls: ['./mercancias.component.css']
})
export class MercanciasComponent {
  constructor(private mercanciaService: MercanciasService) {}


  ngOnInit():void{
    this.mercanciaService.getAllMercancias().subscribe(
      (successResponse) =>{
        console.log(successResponse);
      },
      (errorResponse) =>{
        console.log(errorResponse);
      }
    );
  }

}
