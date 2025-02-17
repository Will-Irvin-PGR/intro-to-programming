import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { BankService } from '../services/bank.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-banking-withdrawal',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="doWithdrawal()">
      <div class="form-control">
        <label for="amount" class="label"
          >Amount of Withdrawal
          <input
            formControlName="amount"
            class="input input-bordered input-md"
            type="number"
            id="amount"
          />
        </label>
        <button type="submit" class="btn btn-primary">Make Withdrawal</button>
      </div>
    </form>
  `,
  styles: ``,
})
export class WithdrawalComponent {
  service = inject(BankService);

  form = new FormGroup({
    amount: new FormControl<number>(0, { nonNullable: true }),
  });

  doWithdrawal() {
    // do the deposit here.
    this.service.withdrawal(this.form.controls.amount.value);
  }
}
