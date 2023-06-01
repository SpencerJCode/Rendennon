using System.ComponentModel.DataAnnotations;
public class Shield
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int ArmorClass { get; set; } = 0;
    public int Value { get; set; } = 0;
    public Shield(string _Name, int _ArmorClass, int _Value)
    {
        Name = _Name;
        ArmorClass = _ArmorClass;
        Value = _Value;
    }
}