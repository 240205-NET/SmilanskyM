import { Component } from '@angular/core';
import { Recipe } from '../recipe.model';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent {
  recipes: Recipe[] = [
    new Recipe(
      'A Test Recipe',
      'This is simply a test',
      'https://img.freepik.com/free-psd/pepperoni-isolated-transparent-background_191095-39895.jpg?w=1380&t=st=1711240374~exp=1711240974~hmac=a5de224eb9a61045caa722399f772541794d6925c4b3003f5dc0e4fdb411dece'
    ),
    new Recipe(
      'A Test Recipe',
      'This is simply a test',
      'https://img.freepik.com/free-psd/pepperoni-isolated-transparent-background_191095-39895.jpg?w=1380&t=st=1711240374~exp=1711240974~hmac=a5de224eb9a61045caa722399f772541794d6925c4b3003f5dc0e4fdb411dece'
    ),
  ];
}
