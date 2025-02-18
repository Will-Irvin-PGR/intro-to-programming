import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
// Angular handles deciding dev vs production
import { environment } from '../../../environments/environment';

export class ResourceDataService {
  private readonly URL = environment.apiUrl;

  private client = inject(HttpClient);

  getResource() {
    return this.client.get<ResourceListItem[]>(this.URL + 'resources');
  }

  addResource(item: ResourceListItemCreateModel) {
    return this.client.post<ResourceListItem>(this.URL + 'resources', item);
  }
}
2;
