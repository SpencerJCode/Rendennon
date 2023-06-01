using System.ComponentModel.DataAnnotations;
public class Armor
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int ArmorClass { get; set; } = 0;
    public int Value { get; set; } = 10;
    public Armor(string _Name, int _ArmorClass, int _Value)
    {
        Name = _Name;
        ArmorClass = _ArmorClass;
        Value = _Value;
    }
}