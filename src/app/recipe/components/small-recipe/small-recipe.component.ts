import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../../../entities/recipe.model'; 
import { Router } from '@angular/router';
import { recipeRoutingModule } from '../../recipe-routing.module';
import { User } from '../../../../entities/user.model';
import { UserService } from '../../../user.service';

@Component({
  selector: 'app-small-recipe',
  templateUrl: './small-recipe.component.html',
  styleUrls: ['./small-recipe.component.css'] 
})
export class SmallRecipeComponent implements OnInit  {
  constructor(private router:Router,private recipeRouter:recipeRoutingModule,private userService:UserService) { }
 writer:User;
 users?: User[];

  @Input()
  public recipe?: Recipe; 
  toEdit()
  {
    
      this.router.navigate(['/recipe/editRecipe', this.recipe?.recipeId]);
     
  }
  ngOnInit(): void {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
      console.log(this.recipe)
      this.writer = this.users?.find(user => user.id === this.recipe.userId);
      console.log(this.writer)
    });
    
    
    
  }
  toDetails():void
  {
    var username = sessionStorage.getItem('name');
     if (username !== null) {
      this.router.navigate(['/recipe/detailsRecipe', this.recipe?.recipeId]);
    } 
    else
    this.router.navigate(['/login/login']);
    ;
  }
  }
