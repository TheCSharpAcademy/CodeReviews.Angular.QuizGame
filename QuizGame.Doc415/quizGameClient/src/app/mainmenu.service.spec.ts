import { TestBed } from '@angular/core/testing';

import { MainmenuService } from './mainmenu.service';

describe('MainmenuService', () => {
  let service: MainmenuService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MainmenuService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
