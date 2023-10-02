// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Classes;
var account = new BankAccount("Oladipo", 1000);

Console.WriteLine ($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");

account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
Console.WriteLine(account.Balance);

account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine (account.Balance);

Console.WriteLine(account.GetAccountHistrory());

return;
// Test for negative balance

try{
    account.MakeWithdrawal(2700, DateTime.Now,"Attempt to overdraw");

}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
    
}


//Test that the intial balance must be  positive
BankAccount invalidAccount;
try{
    invalidAccount = new BankAccount("invalid account",-55);

}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}

