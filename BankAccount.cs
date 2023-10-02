namespace Classes ;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance 
    { 
        get
        {
            decimal balance =0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
        
    }
    private static int s_accountNumberSeed = 1234567890;
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");

        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
           throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrwal must be positive");
        }
        
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrwal");
        }
        var withdrwal = new Transaction (amount, date, note);
        _allTransactions.Add(withdrwal);
    }
    public string GetAccountHistrory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach ( var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t {item.Notes}");
        }
        return report.ToString();
    }
    public BankAccount(string name, decimal initialBalance)
    {
        this.Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        this.Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
       // this.Balance = initialBalance;

    }
    public virtual void PerformMonthEndTransactions()
    {
        
    }
    private List<Transaction> _allTransactions = new List<Transaction>();

}
    
