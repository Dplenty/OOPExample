using Classes;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance): base (name, initialBalance)
    {
        
    }
    public override void PerformMonthEndTransactions ()
    {
        if (Balance < 0)
        {
            //negate the balance
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal (interest, DateTime.Now, "Charge montly interest");
            
        }
    }
}