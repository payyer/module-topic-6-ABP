import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { ModuleTopic6Component } from './components/module-topic6.component';
import { ModuleTopic6Service } from '@module-topic6';
import { of } from 'rxjs';

describe('ModuleTopic6Component', () => {
  let component: ModuleTopic6Component;
  let fixture: ComponentFixture<ModuleTopic6Component>;
  const mockModuleTopic6Service = jasmine.createSpyObj('ModuleTopic6Service', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ModuleTopic6Component],
      providers: [
        {
          provide: ModuleTopic6Service,
          useValue: mockModuleTopic6Service,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuleTopic6Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
