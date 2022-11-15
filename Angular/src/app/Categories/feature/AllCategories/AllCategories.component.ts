import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../../data-access/categories.service';
import { Categorie } from '../../data-access/Classes/categorie';

@Component({
  selector: 'app-AllCategories',
  templateUrl: './AllCategories.component.html',
  styleUrls: ['./AllCategories.component.css']
})

export class AllCategoriesComponent implements OnInit {


  constructor(public categorieService:CategoriesService) { }
  categories:Categorie[] = []

  ngOnInit() {
    this.categories = this.categorieService.getAllCategories()
  }

}
