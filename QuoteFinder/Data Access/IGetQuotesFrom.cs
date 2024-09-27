internal interface IGetQuotesFrom
{
    Task<Root> GetQuotesAsync(int amount);
}
