import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../../data-access/categories.service';
import { Categorie } from '../../data-access/Classes/categorie';

@Component({
  selector: 'app-AllCategories',
  templateUrl: './AllCategories.component.html',
  styleUrls: ['./AllCategories.component.css']
})

export class AllCategoriesComponent implements OnInit {


  constructor(public categorieService: CategoriesService , public route:Router ) { }
  categories: Categorie[] = []

  ngOnInit() {
    this.categorieService.getAllCategories().subscribe(a => {
      this.categories = a
    })
  }
  routeTo(id:any){
    this.route.navigateByUrl(`Categories/${id}`)
  }

}
