import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ModuleTopic6Service {
  apiName = 'ModuleTopic6';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/ModuleTopic6/sample' },
      { apiName: this.apiName }
    );
  }
}
