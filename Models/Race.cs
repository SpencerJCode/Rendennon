using System.ComponentModel.DataAnnotations;
public class Race
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int StrengthModifier { get; set; } = 0;
    public  int DexterityModifier { get; set; } = 0;
    public  int ConstitutionModifier { get; set; } = 0;
    public int IntelligenceModifier { get; set; } = 0;
    public int WisdomModifier { get; set; } = 0;
    public int CharismaModifier { get; set; } = 0;

    public Race(string _Name, int _StrengthModifier, int _DexterityModifier, int _ConstitutionModifier, int _IntelligenceModifier, int _WisdomModifier, int _CharismaModifier)
    {
        Name = _Name;
        StrengthModifier = _StrengthModifier;
        DexterityModifier = _DexterityModifier;
        ConstitutionModifier = _ConstitutionModifier;
        IntelligenceModifier = _IntelligenceModifier;
        WisdomModifier = _WisdomModifier;
        CharismaModifier = _CharismaModifier;
    }
}