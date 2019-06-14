namespace Models
{
    public interface IArticleNutrient : IArticle
    {
        int Amount { get; }     
    }
}