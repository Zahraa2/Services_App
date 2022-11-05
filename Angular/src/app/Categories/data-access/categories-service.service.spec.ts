/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CategoriesServiceService } from './categories-service.service';

describe('Service: CategoriesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CategoriesServiceService]
    });
  });

  it('should ...', inject([CategoriesServiceService], (service: CategoriesServiceService) => {
    expect(service).toBeTruthy();
  }));
});
