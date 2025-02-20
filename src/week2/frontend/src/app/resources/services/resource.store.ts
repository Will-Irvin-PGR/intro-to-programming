import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { addEntities, addEntity, withEntities } from '@ngrx/signals/entities';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { mergeMap, pipe, switchMap, tap } from 'rxjs';
import { ResourceDataService } from './resource-data.service';
import { computed, inject } from '@angular/core';
import { withDevtools } from '@angular-architects/ngrx-toolkit';

export const ResourceStore = signalStore(
  withDevtools('resources'),
  withState<{ filteredBy: string | null }>({
    filteredBy: null,
  }),
  withState<{ tags: string[] }>({
    tags: [],
  }),
  withEntities<ResourceListItem>(),
  withComputed((store) => {
    return {
      filteredResourceList: computed(() => {
        const filteredBy = store.filteredBy();
        if (filteredBy === null) {
          return store.entities();
        }
        return store.entities().filter((r) => r.tags.includes(filteredBy));
      }),
    };
  }),
  withMethods((store) => {
    const service = inject(ResourceDataService);
    return {
      setFilteredBy: (filteredBy: string | null) =>
        patchState(store, { filteredBy: filteredBy }),
      add: rxMethod<ResourceListItemCreateModel>(
        pipe(
          mergeMap((item) =>
            service
              .addResource(item)
              .pipe(tap((r) => patchState(store, addEntity(r)))),
          ),
        ),
      ),
      _load: rxMethod<void>(
        pipe(
          switchMap(() =>
            service.getResource().pipe(
              tap((r) => patchState(store, addEntities(r))),
              tap((items) => {
                const tags = items.map((item) => item.tags).flat();

                const uniqueTags = Array.from(new Set(tags));

                const tagList = store.tags();
                const newTags = uniqueTags.filter(
                  (tag) => !tagList.includes(tag),
                );
                patchState(store, { tags: [...newTags] });
              }),
            ),
          ),
        ),
      ),
    };
  }),
  withHooks({
    onInit(store) {
      store._load();
    },
  }),
);
