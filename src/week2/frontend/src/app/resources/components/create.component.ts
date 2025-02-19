import { JsonPipe } from '@angular/common';
import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ResourceStore } from '../services/resource.store';
import { ResourceListItemCreateModel } from '../types';

@Component({
  selector: 'app-resources-create',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule], // this is going to be replaced "sometime soon" with a signals based forms module.
  template: `
    <p>Create a New Resource</p>
    <form [formGroup]="form" class="w-1/3" (ngSubmit)="addItem()">
      <div class="form-control">
        <label for="title" class="label"
          >Title:

          <input
            type="text"
            id="title"
            class="input input-bordered"
            formControlName="title"
          />
          @let ltfTitle = form.controls.title;
          @if (ltfTitle.invalid && (ltfTitle.dirty || ltfTitle.touched)) {
            <div class="alert alert-error">
              @if (ltfTitle.hasError('required')) {
                <p>You have to give us text to show</p>
              }
              @if (ltfTitle.hasError('minlength')) {
                <p>Text can be no fewer than 3 characters</p>
              }
              @if (ltfTitle.hasError('maxlength')) {
                <p>Text can be no longer than 100 characters</p>
              }
            </div>
          }
        </label>
      </div>
      <div class="form-control">
        <label for="description" class="label"
          >Description:

          <textarea
            id="description"
            class="input input-bordered"
            formControlName="description"
          ></textarea>
        </label>
      </div>
      <div class="form-control">
        <label for="link" class="label"
          >Link:

          <input
            type="url"
            id="link"
            class="input input-bordered"
            formControlName="link"
          />
          @let ltfLink = form.controls.link;
          @if (ltfLink.invalid && (ltfLink.dirty || ltfLink.touched)) {
            <div class="alert alert-error">
              <p>Link must be provided</p>
            </div>
          }
        </label>
      </div>
      <div class="form-control">
        <label for="linkText" class="label"
          >Link Text:

          <input
            type="text"
            id="linkText"
            class="input input-bordered"
            formControlName="linkText"
          />
          @let ltfLinkText = form.controls.linkText;
          @if (
            ltfLinkText.invalid && (ltfLinkText.dirty || ltfLinkText.touched)
          ) {
            <div class="alert alert-error">
              @if (ltfLinkText.hasError('required')) {
                <p>You have to give us text to show</p>
              }
              @if (ltfLinkText.hasError('minlength')) {
                <p>Text can be no fewer than 3 characters</p>
              }
              @if (ltfLinkText.hasError('maxlength')) {
                <p>Text can be no longer than 20 characters</p>
              }
            </div>
          }
        </label>
      </div>
      <div class="form-control">
        <label for="tags" class="label"
          >Tags:

          <input
            type="text"
            id="tags"
            class="input input-bordered"
            formControlName="tags"
          />
        </label>
      </div>
      <button type="submit" class="btn btn-primary">Add This Item</button>
    </form>
  `,
  styles: ``,
})
export class CreateComponent {
  store = inject(ResourceStore);

  form = new FormGroup({
    title: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(100),
      ],
    }),
    description: new FormControl<string>('', { nonNullable: true }),
    link: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
    linkText: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
      ],
    }),
    tags: new FormControl<string>('', { nonNullable: true }),
  });

  addItem() {
    // only do this if it is valid, follows all the rules, etc.
    // send it to our API to add it.
    if (this.form.valid) {
      const itemToSend = this.form
        .value as unknown as ResourceListItemCreateModel;
      this.store.add(itemToSend);

      this.form.reset();
    } else {
      this.form.markAllAsTouched();
      console.log('Invalid form');
    }
  }
}
