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
    private readonly double _loadFactor = 4.5;
    private readonly double _baseSpeed = 12.0;
    private readonly double _minBaseSpeed = 24.0;

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
                return _baseSpeed;
            case ParrotTypeEnum.AFRICAN:
                if(_numberOfCoconuts > 1) return 0;
                return Math.Max(0, _baseSpeed - _loadFactor * _numberOfCoconuts);
            case ParrotTypeEnum.NORWEGIAN_BLUE:
                return _isNailed ? 0 : GetBaseSpeed(_voltage);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private double GetBaseSpeed(double voltage)
    {
        if (voltage == 2.0) return 22.0;
        return Math.Min(_minBaseSpeed, voltage * _baseSpeed);
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
                if (_numberOfCoconuts == 0)
                    value = "Sqoork!";
                else
                    value = "Sqaark!";
                break;
            case ParrotTypeEnum.NORWEGIAN_BLUE:
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