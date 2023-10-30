namespace Entities.Models;

public sealed class Category
{
    public int Id { get; set; } //pegeout 3008 orta modeli
    public int? MainCategoryId { get; set; }
    public string Name { get; set; }
}