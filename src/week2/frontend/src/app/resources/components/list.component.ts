import {
  ChangeDetectionStrategy,
  Component,
  inject,
  resource,
} from '@angular/core';
import { LinkDocsDisplayItemComponent } from './link-docs-display-item.component';
import { ResourceStore } from '../services/resource.store';

@Component({
  selector: 'app-resources-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [LinkDocsDisplayItemComponent],
  template: `
    <div class="flex gap-4">
      @for (link of store.entities(); track link.id) {
        <app-link-docs-display-item [link]="link" />
      } @empty {
        <p>You don't have any resources! Add Some?</p>
      }
    </div>
  `,
  styles: ``,
})
export class ListComponent {
  store = inject(ResourceStore);
}
// links = signal<ResourceListItem[]>([
//   {
//     id: '1',
//     title: 'Hypertheory Applied Angular Materials',
//     description: 'Class Materials for Applied Angular',
//     link: 'https://applied-angular.hypertheory.com',
//     linkText: 'Hypertheory.com',
//     tags: ['Angular', 'TypeScript', 'Training'],
//   },
//   {
//     id: '2',
//     title: 'NGRX',
//     description: 'NGRX Family of Fine Angular Libraries',
//     link: 'https://ngrx.io',
//     linkText: 'NGRX.io',
//     tags: ['Angular', 'TypeScript', 'Training', 'State', 'Signals', 'Redux'],
//   },
// ])
