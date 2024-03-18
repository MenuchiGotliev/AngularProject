import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Recipe } from '../../../../entities/recipe.model';
import { RecipeService } from '../../../recipe.service';
import { CategoryService } from '../../../category.service';
import { UserService } from '../../../user.service';
import { User } from '../../../../entities/user.model';
import { Category } from '../../../../entities/category.model';
@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  recipeId: number;
  recipe: Recipe;
  isOwner: boolean = false;
  user?:User;
  category?: Category
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private recipeService: RecipeService,
    private _categoryService: CategoryService,
    private userService:UserService
  ) {}

  ngOnInit(): void {

    this.recipeId = Number(this.route.snapshot.paramMap.get('recipeId'));
 
    this.recipeService.getRecipeById(this.recipeId).subscribe({

      next: (recipe: Recipe) => {
        this.recipe = recipe; 
        this.isOwner = this.recipe?.userId===Number(sessionStorage.getItem('id'));
        console.log(recipe?.imageRouting)
            // Check if the current user is the owner of the recipe
            this.initCategory();
      },
      error: (error) => {
        console.error('Error fetching recipe details:', error);
      }
    });

    
   
  }
 initCategory() {
  console.log(this.recipe.categoryId)
    this._categoryService.getCategoryById(this.recipe?.categoryId).subscribe({
      next: (res) => {
        this.category = res;
        console.log(this.category)
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        console.log('finish category');
      }
    });
  }
  deleteRecipe(): void {
    
    if (confirm('Are you sure you want to delete this recipe?')) {
      this.recipeService.deleteRecipe(this.recipeId).subscribe({
        next: () => {
          console.log('Recipe deleted successfully.');
          // Redirect to a different page after deletion
          this.router.navigate(['/recipes']);
        },
        error: (error) => {
          console.error('Error deleting recipe:', error);
        }
      });
    }
  }
}
