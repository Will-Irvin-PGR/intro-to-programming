import { Routes } from '@angular/router';
import { BankingComponent } from './banking.component';
import { WithdrawalComponent } from './components/withdrawal.component';
import { DepositComponent } from './components/deposit.component';
import { BankStore } from './services/bank.store';
export const BANKING_ROUTES: Routes = [
  {
    path: '',
    component: BankingComponent,
    providers: [BankStore],
    children: [
      {
        path: 'withdrawal', // banking/withdrawal
        component: WithdrawalComponent,
      },
      {
        path: 'deposit', // banking/deposit
        component: DepositComponent,
      },
    ],
  },
];
