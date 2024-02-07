namespace Banking
{
    class Account
    {
    // fields (properties and state)
        // pin
        // account owner
        private string owner;
        // type (checking/savings)
        // account number 

        // Access Modifiers
            // public
            // private - * default access modifier
            // protected
            // internal 

        
        //getter/setter - special methods that allow you to modify the value of a field
            // private int accountNumber 
            // public int getAccountNumber()
            // {
            //     return this.accountNumber;
            // }
            // public void setAccountNumber(int number)
            // {
            //     this.accountNumber = number;
            // }

        public int accountNumber { get; }

        public void setAccountNumber( int number)
        { 
            if (value == null)
            {
                throw new Exception(MessageProcessingHandler: "value cannot be null", paramName :nameof(ValueTask));
            }
            this.accountNumber = value;
        }

        // balance
        protected double balance;

        private static int accountNumberSeed = 123;
        
    // constructor - a specific method that details how to make an Account object.
        public Account(string ownersName, double initialBalance)
        { 
            //create account num
            this.accountNumber = this.accountNumberSeed;
            this.accountNumberSeed++;

            this.owner = ownerName;
            MakeDeposit(intialBalance);
        }

        // Overloading - two methods with the same name, with two different functionalities
        public Account(string ownersName)
        { 
            //create account num
            this.accountNumber = this.accountNumberSeed;
            this.accountNumberSeed++;

            this.owner = ownerName;
            MakeDeposit(0);
        }

    // methods (behavior)

        // account balance
        // withdrawls
        // deposits
        // associate with another account
        // transfer to other accounts
        // closing account (remove account info)

    }
}
