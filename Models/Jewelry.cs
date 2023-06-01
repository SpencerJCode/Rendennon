using System.ComponentModel.DataAnnotations;
public class Jewelry
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int Value { get; set; } = 10;
}