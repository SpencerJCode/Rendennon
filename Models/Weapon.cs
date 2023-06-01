using System.ComponentModel.DataAnnotations;
public class Weapon
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int DamageDiceSize { get; set; } = 0;
    public int DamageDiceNumber { get; set; } = 0;
    public bool IsTwoHanded { get; set; } = false;
    public int CriticalRate { get; set; } = 0;
    public int Value { get; set; } = 0;
    public Weapon(string _Name, int _DamageDiceSize, int _DamageDiceNumber, bool _IsTwoHanded, int _CriticalRate, int _Value)
    {
        Name = _Name;
        DamageDiceSize = _DamageDiceSize;
        DamageDiceNumber = _DamageDiceNumber;
        IsTwoHanded = _IsTwoHanded;
        CriticalRate = _CriticalRate;
        Value = _Value;
    }
}