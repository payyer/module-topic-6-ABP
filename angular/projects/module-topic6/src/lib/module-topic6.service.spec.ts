import { TestBed } from '@angular/core/testing';
import { ModuleTopic6Service } from './services/module-topic6.service';
import { RestService } from '@abp/ng.core';

describe('ModuleTopic6Service', () => {
  let service: ModuleTopic6Service;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(ModuleTopic6Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
