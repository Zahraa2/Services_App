/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProfileServiceService } from './profile-service.service';

describe('Service: ProfileService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfileServiceService]
    });
  });

  it('should ...', inject([ProfileServiceService], (service: ProfileServiceService) => {
    expect(service).toBeTruthy();
  }));
});
