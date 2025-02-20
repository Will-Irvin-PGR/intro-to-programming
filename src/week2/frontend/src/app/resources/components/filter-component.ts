import {
  Component,
  ChangeDetectionStrategy,
  signal,
  inject,
} from '@angular/core';
import { ResourceStore } from '../services/resource.store';
import { Router } from '@angular/router';

@Component({
  selector: 'app-resource-filter',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div>
      <select (change)="changeTheFilter($event)" class="input input-bordered">
        @for (tag of store.tags(); track tag) {
          <option value="{{ tag }}">{{ tag }}</option>
        }
      </select>
    </div>
  `,
  styles: ``,
})
export class FilterComponent {
  store = inject(ResourceStore);
  router = inject(Router);

  changeTheFilter(event: any): void {
    // TODO: fix hardcoded link here
    this.router.navigate(['/resources/list'], {
      queryParams: { filter: event.target.value },
    });
  }
}
