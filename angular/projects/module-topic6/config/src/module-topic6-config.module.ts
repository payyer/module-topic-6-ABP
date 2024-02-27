import { ModuleWithProviders, NgModule } from '@angular/core';
import { MODULE_TOPIC6_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ModuleTopic6ConfigModule {
  static forRoot(): ModuleWithProviders<ModuleTopic6ConfigModule> {
    return {
      ngModule: ModuleTopic6ConfigModule,
      providers: [MODULE_TOPIC6_ROUTE_PROVIDERS],
    };
  }
}
