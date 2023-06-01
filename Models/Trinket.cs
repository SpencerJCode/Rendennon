using System.ComponentModel.DataAnnotations;
public class Trinket
{
    [Key]
    public int ID { get; set; }
    public string Name = "";
    public string Description = "";
}