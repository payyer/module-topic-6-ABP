import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ModuleTopic6Component } from './components/module-topic6.component';
import { ModuleTopic6RoutingModule } from './module-topic6-routing.module';

@NgModule({
  declarations: [ModuleTopic6Component],
  imports: [CoreModule, ThemeSharedModule, ModuleTopic6RoutingModule],
  exports: [ModuleTopic6Component],
})
export class ModuleTopic6Module {
  static forChild(): ModuleWithProviders<ModuleTopic6Module> {
    return {
      ngModule: ModuleTopic6Module,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ModuleTopic6Module> {
    return new LazyModuleFactory(ModuleTopic6Module.forChild());
  }
}
