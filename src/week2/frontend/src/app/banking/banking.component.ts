import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-banking',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <p>Banking Stuff Coming Soon</p>
    <div>
      <p>Your balance is $5,000.00</p>
    </div>

    <div>
      <input type="number" class="input input-bordered" id="amount" />
      <button class="btn btn-warning">Withdraw</button>
      <button class="btn btn-primary">Deposit</button>
    </div>
  `,
  styles: ``,
})
export class BankingComponent {}
