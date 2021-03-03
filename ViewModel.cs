using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Chk_Bank_Account
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Account> accounts;

        public Command NextAccount { get; private set; }
        public Command PreviousAccount { get; private set; }


        private int currentAccount;
        public ViewModel()
        {

            this.currentAccount = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;

            this.NextAccount = new Command(this.Next, () => this.accounts.Count > 1 && !this.IsAtEnd);

            this.PreviousAccount = new Command(this.Previous, () => this.accounts.Count > 0 && !this.IsAtStart);



            this.accounts = new List<Account>
            {
                new Account
                {
                    AccountID=1,
                    AccountType="Saving",
                    AccountNumber="123456",
                    Amount="100000",
                    NumberOfAccount="2",
                    IsActive="Yes"
                },

                new Account
                {
                    AccountID=2,
                    AccountType="Student",
                    AccountNumber="234567",
                    Amount="80000",
                    NumberOfAccount="1",
                    IsActive="No"
                },

                new Account
                {
                    AccountID=3,
                    AccountType="Business",
                    AccountNumber="345678",
                    Amount="50000",
                    NumberOfAccount="2",
                    IsActive="Yes"
                }


            };
        }


        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }


        public Account Current
        {
            get => this.accounts.Count > 0 ? this.accounts[currentAccount] : null;
        }

        private void Next()
        {
            if (this.accounts.Count - 1 > this.currentAccount)
            {
                this.currentAccount++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.accounts.Count - 1 == this.currentAccount);
            }
        }

        private void Previous()
        {
            if (this.accounts.Count > 0)
            {
                this.currentAccount--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentAccount == 0);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
