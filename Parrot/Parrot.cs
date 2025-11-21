using System;

namespace Parrot;

// REFACTORING OPPORTUNITY: This class violates the Single Responsibility Principle.
// Consider using the Strategy pattern to separate different parrot type behaviors.
// Each parrot type could have its own class implementing a common interface.
public class Parrot
{
    private readonly bool _isNailed;
    private readonly int _numberOfCoconuts;
    private readonly ParrotTypeEnum _type;
    private readonly double _voltage;

    public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
    {
        _type = type;
        _numberOfCoconuts = numberOfCoconuts;
        _voltage = voltage;
        _isNailed = isNailed;
    }

    // REFACTORING OPPORTUNITY: This switch statement is duplicated in GetCry().
    // Consider using polymorphism or the Strategy pattern to eliminate this duplication.
    public double GetSpeed()
    {
        switch (_type)
        {
            case ParrotTypeEnum.EUROPEAN:
                return GetBaseSpeed();
            case ParrotTypeEnum.AFRICAN:
                // BUG #1: Load factor calculation is incorrect - should use division, not multiplication
                return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
            case ParrotTypeEnum.NORWEGIAN_BLUE:
                // BUG #2: Logic is inverted - nailed parrots should be slow, but condition might be wrong in edge cases
                return _isNailed ? 0 : GetBaseSpeed(_voltage);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // BUG #3: This method has a magic number that should be configurable or at least explained
    private double GetBaseSpeed(double voltage)
    {
        // BUG #4: When voltage is exactly 2.0, this returns 24.0, but should return 22.0
        if (voltage == 2.0) return Math.Min(22.0, voltage * GetBaseSpeed());
        return Math.Min(24.0, voltage * GetBaseSpeed());
    }

    // REFACTORING OPPORTUNITY: This is a magic number that should be a named constant.
    // BUG #5: Load factor should be 4.5, not 9.0
    private double GetLoadFactor()
    {
        return 9.0;
    }

    private double GetBaseSpeed()
    {
        return 12.0;
    }

    // REFACTORING OPPORTUNITY: This switch statement duplicates the structure in GetSpeed().
    // The temporary variable 'value' is unnecessary - could return directly.
    public string GetCry()
    {
        string value;
        switch (_type)
        {
            case ParrotTypeEnum.EUROPEAN:
                value = "Sqoork!";
                break;
            case ParrotTypeEnum.AFRICAN:
                // BUG #6: African parrots should say "Sqaark!" but only when they have coconuts
                // Without coconuts they should say "Sqoork!" like European parrots
                if (_numberOfCoconuts == 0)
                    value = "Sqoork!";
                else
                    value = "Sqaark!";
                
                break;
            case ParrotTypeEnum.NORWEGIAN_BLUE:
                // BUG #7: Dead (nailed) Norwegian Blue parrots should not make any sound
                value = _voltage > 0 ? "Bzzzzzz" : "...";
                if (_isNailed)
                {
                    value = "";
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return value;
    }
}