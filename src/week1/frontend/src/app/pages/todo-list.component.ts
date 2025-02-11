import {
  Component,
  ChangeDetectionStrategy,
  signal,
  resource,
} from '@angular/core';
import { TodoListItem } from '../models';

@Component({
  selector: 'app-todo-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: ` @if (itemsResource.error()) {
      <p>Could Not Load Your Data For Reasons. Sorry.</p>
    }
    @for (item of itemsResource.value(); track item.id) {
      <div class="card bg-base-100 w-96 shadow-xl">
        <div class="card-body">
          <h2 class="card-title">{{ item.description }}</h2>
          <p>You Added this on {{ item.createdOn }}</p>
          @if (item.completed === false) {
            <div class="card-actions justify-end">
              <button class="btn btn-primary">Mark Completed</button>
            </div>
          } @else {
            <p>You completed this item on {{ item.completedOn }}</p>
            <button class="btn btn-primary">Remove from List</button>
          }
        </div>
      </div>
    }`,
  styles: ``,
})
export class TodoListComponent {
  /*   items = signal<TodoListItem[]>([
    {
      id: '99',
      completed: false,
      createdOn: '2025-02-11T20:58:47.300Z',
      description: 'Shovel Snow',
    },
    {
      id: '100',
      completed: true,
      createdOn: '2025-02-11T20:58:47.300Z',
      description: 'Make Tacos',
      completedOn: '2025-02-11T20:58:47.300Z',
    },
  ]); */

  itemsResource = resource({
    loader: () => fetch('http://localhost:1337/todos').then((r) => r.json()),
  });
}
