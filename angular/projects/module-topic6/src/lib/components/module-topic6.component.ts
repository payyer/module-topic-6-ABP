import { Component, OnInit } from '@angular/core';
import { ModuleTopic6Service } from '../services/module-topic6.service';

@Component({
  selector: 'lib-module-topic6',
  template: ` <p>module-topic6 works!</p> `,
  styles: [],
})
export class ModuleTopic6Component implements OnInit {
  constructor(private service: ModuleTopic6Service) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
