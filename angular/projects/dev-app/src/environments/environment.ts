import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ModuleTopic6',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44374/',
    redirectUri: baseUrl,
    clientId: 'ModuleTopic6_App',
    responseType: 'code',
    scope: 'offline_access ModuleTopic6',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44374',
      rootNamespace: 'ModuleTopic6',
    },
    ModuleTopic6: {
      url: 'https://localhost:44338',
      rootNamespace: 'ModuleTopic6',
    },
  },
} as Environment;
