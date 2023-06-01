using System.ComponentModel.DataAnnotations;
public class Class
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int HPDieRoll { get; set; } = 4;
    public double BaseAttackModifier { get; set; } = .5;
    public bool DoubleAttack { get; set; } = false;
    public Class(string _Name, int _HPDieRoll, double _BaseAttackModifier, int _CriticalRate, bool _DoubleAttack)
    {
        Name = _Name;
        HPDieRoll = _HPDieRoll;
        BaseAttackModifier = _BaseAttackModifier;
        DoubleAttack = _DoubleAttack;
    }
    
}