import { Injectable } from '@angular/core';
import { Categorie } from './Classes/categorie';
import { Service } from './Classes/Service';

@Injectable(
    {
        providedIn: 'root'
    }
)
export class CategoriesService {

    categories: Categorie[] = [
        new Categorie("نجاره"),
        new Categorie("حدادة"),
        new Categorie("طبخ"),
        new Categorie("تشطيب"),
    ]



    getAllCategories() {
        return this.categories
    }



    constructor() { }

}
