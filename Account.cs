using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Chk_Bank_Account
{
    public class Account: INotifyPropertyChanged
    {
        public int _accountID;
        public int AccountID
        {
            get => this._accountID;
            set
            {
                this._accountID = value;
                this.OnPropertyChanged(nameof(AccountID));
            }
        }

        public string _accountType;
        public string AccountType
        {
            get => this._accountType;
            set
            {
                this._accountType = value;
                this.OnPropertyChanged(nameof(AccountType));

            }
        }

        public string _accountNumber;
        public string AccountNumber
        {
            get => this._accountNumber;
            set
            {
                this._accountNumber = value;
                this.OnPropertyChanged(nameof(AccountNumber));

            }
        }


        public string _amount;
        public string Amount
        {
            get => this._amount;
            set
            {
                this._amount = value;
                this.OnPropertyChanged(nameof(Amount));

            }
        }

        public string _numberOfAccount;
        public string NumberOfAccount
        {
            get => this._numberOfAccount;
            set
            {
                this._numberOfAccount = value;
                this.OnPropertyChanged(nameof(NumberOfAccount));

            }
        }

        public string _isActive;


        public string IsActive
        {
            get => this._isActive;
            set
            {
                this._isActive = value;
                this.OnPropertyChanged(nameof(IsActive));

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
