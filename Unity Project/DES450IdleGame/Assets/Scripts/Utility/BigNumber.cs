using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Does not support negative numbers (shouldn't need to)
[System.Serializable]
public class BigNumber
{
    public enum DisplayType { SCIENTIFIC, NAMES }

    [SerializeField]
    private float multiplier = 1.0f;

    [SerializeField]
    private int tenpow = 0;

    public BigNumber(BigNumber other)
    {
        multiplier = other.multiplier;
        tenpow = other.tenpow;
    }

    public BigNumber() { }

    public BigNumber(float mult, int tp)
    {
        multiplier = mult;
        tenpow = tp;
    }

    //Display stuff
    private static DisplayType disp = DisplayType.SCIENTIFIC;
    private readonly static string[] powNames =
        { "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion",
          "Undecillion", "Dodecillion", "Tredicillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septen-decillion", "Octodecillion",
          "Novemdecillion", "Vigintillion" };
    public override string ToString()
    {
        if (tenpow <= 5)
        {
            return ((int)(multiplier * Mathf.Pow(10, tenpow))).ToString();
        }

        if (disp == DisplayType.SCIENTIFIC)
        {
            return multiplier.ToString("0.####") + $"e+{tenpow}";
        }
        else if (disp == DisplayType.NAMES)
        {
            int index = (tenpow - 6) / 3;
            if (index >= powNames.Length)
            {
                return multiplier.ToString("0.####") + $"e+{tenpow}";
            }

            int numZeros = (tenpow - 6) % 3;
            string formatString = "0";
            for (int i = 0; i < numZeros; ++i)
            {
                formatString += "0";
            }
            formatString += ".";
            for (int i = 0; i < 4 - numZeros; ++i)
            {
                formatString += "#";
            }

            return (multiplier * Mathf.Pow(10, numZeros)).ToString(formatString) + " " + powNames[index];
        }

        return "";
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static void SetDisplayType(DisplayType d)
    {
        disp = d;
    }

    public static DisplayType GetDisplayType()
    {
        return disp;
    }

    public BigNumber Assign(BigNumber rhs)
    {
        multiplier = rhs.multiplier;
        tenpow = rhs.tenpow;

        return this;
    }

    public static BigNumber Zero()
    {
        BigNumber n = new BigNumber();
        n.tenpow = 0;
        n.multiplier = 0;
        return n;
    }

    //Casting
    public static explicit operator BigNumber(int i)
    {
        BigNumber n = new BigNumber();
        n.tenpow = (int)Mathf.Log10(i);
        n.multiplier = (float)i / Mathf.Pow(10, n.tenpow);

        return n;
    }

    public static explicit operator BigNumber(float f)
    {
        BigNumber n = new BigNumber();
        n.tenpow = (int)Mathf.Log10(f);
        n.multiplier = f / Mathf.Pow(10, n.tenpow);

        return n;
    }

    //Comparison
    public static bool operator ==(BigNumber lhs, BigNumber rhs)
    {
        if (ReferenceEquals(lhs, rhs))
        {
            return true;
        }
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
        {
            return false;
        }

        return (lhs.multiplier == rhs.multiplier) && (lhs.tenpow == rhs.tenpow);
    }

    public static bool operator !=(BigNumber lhs, BigNumber rhs)
    {
        if (ReferenceEquals(lhs, rhs))
        {
            return false;
        }
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
        {
            return true;
        }

        return (lhs.multiplier != rhs.multiplier) || (lhs.tenpow != rhs.tenpow);
    }

    public static bool operator <(BigNumber lhs, BigNumber rhs)
    {
        return (lhs.tenpow < rhs.tenpow) || ((lhs.tenpow == rhs.tenpow) && (lhs.multiplier < rhs.multiplier));
    }

    public static bool operator >(BigNumber lhs, BigNumber rhs)
    {
        return (lhs.tenpow > rhs.tenpow) || ((lhs.tenpow == rhs.tenpow) && (lhs.multiplier > rhs.multiplier));
    }

    public static bool operator >=(BigNumber lhs, BigNumber rhs)
    {
        return (lhs == rhs) || (lhs > rhs);
    }

    public static bool operator <=(BigNumber lhs, BigNumber rhs)
    {
        return (lhs == rhs) || (lhs < rhs);
    }

    //Addition, Subtraction
    public static BigNumber operator +(BigNumber lhs, int rhs)
    {
        if (lhs.tenpow > 8)
        {
            return lhs + (BigNumber)rhs;
        }

        BigNumber n = new BigNumber();
        n.Assign(lhs);

        n.multiplier += (float)rhs / Mathf.Pow(10, n.tenpow);
        int extra = (int)Mathf.Log10(n.multiplier);
        n.multiplier /= Mathf.Pow(10, extra);
        n.tenpow += extra;

        return n;
    }

    public static BigNumber operator +(BigNumber lhs, float rhs)
    {
        if (lhs.tenpow > 8)
        {
            return lhs + (BigNumber)rhs;
        }

        BigNumber n = new BigNumber();
        n.Assign(lhs);

        n.multiplier += rhs / Mathf.Pow(10, n.tenpow);
        int extra = (int)Mathf.Log10(n.multiplier);
        n.multiplier /= Mathf.Pow(10, extra);
        n.tenpow += extra;

        return n;
    }

    public static BigNumber operator +(BigNumber lhs, BigNumber rhs)
    {
        if (lhs.tenpow - rhs.tenpow > 8)
        {
            return lhs;
        }
        else if (lhs.tenpow - rhs.tenpow < -8)
        {
            return rhs;
        }

        BigNumber n = new BigNumber();
        n.Assign(lhs);

        n.multiplier += rhs.multiplier * Mathf.Pow(10, rhs.tenpow - lhs.tenpow);
        int extra = (int)Mathf.Log10(n.multiplier);
        n.multiplier /= Mathf.Pow(10, extra);
        n.tenpow += extra;

        return n;
    }

    public static BigNumber operator -(BigNumber lhs, int rhs)
    {
        return lhs - (BigNumber)rhs;
    }

    public static BigNumber operator -(BigNumber lhs, float rhs)
    {
        return lhs - (BigNumber)rhs;
    }

    public static BigNumber operator -(BigNumber lhs, BigNumber rhs)
    {
        //We don't support negative numbers - lowest possible BigNumber is 0
        if (rhs >= lhs)
        {
            return Zero();
        }

        BigNumber n = new BigNumber(lhs);

        n.multiplier -= rhs.multiplier / Mathf.Pow(10, lhs.tenpow - rhs.tenpow);
        while (n.multiplier < 1 && n.tenpow > 0)
        {
            n.multiplier *= 10;
            n.tenpow -= 1;
        }

        return n;
    }

    //Multiplication, division
    public static BigNumber operator *(BigNumber lhs, int rhs)
    {
        return lhs * (BigNumber)rhs;
    }

    public static BigNumber operator *(BigNumber lhs, float rhs)
    {
        return lhs * (BigNumber)rhs;
    }

    public static BigNumber operator *(BigNumber lhs, BigNumber rhs)
    {
        BigNumber n = new BigNumber(lhs);

        n.tenpow += rhs.tenpow;
        n.multiplier *= rhs.multiplier;
        int extra = (int)Mathf.Log10(n.multiplier);
        n.multiplier /= Mathf.Pow(10, extra);
        n.tenpow += extra;

        return n;
    }

    public static BigNumber operator /(BigNumber lhs, int rhs)
    {
        return lhs / (BigNumber)rhs;
    }

    public static BigNumber operator /(BigNumber lhs, float rhs)
    {
        return lhs / (BigNumber)rhs;
    }

    public static BigNumber operator /(BigNumber lhs, BigNumber rhs)
    {
        if (lhs.tenpow - rhs.tenpow < -7)
        {
            return Zero();
        }

        BigNumber n = new BigNumber(lhs);

        n.tenpow -= rhs.tenpow;
        n.multiplier /= rhs.multiplier;
        while (n.multiplier < 1 && n.tenpow > 0)
        {
            n.multiplier *= 10;
            n.tenpow -= 1;
        }
        while (n.tenpow < 0)
        {
            n.multiplier /= 10;
            n.tenpow += 1;
        }

        return n;
    }

    public static BigNumber RandomRange(BigNumber min, BigNumber max)
    {
        if (min.tenpow == max.tenpow)
        {
            return new BigNumber(Random.Range(min.multiplier, max.multiplier), min.tenpow);
        }

        int pow = Random.Range(min.tenpow, max.tenpow + 1);
        float mult;

        if (pow == min.tenpow)
        {
            mult = Random.Range(min.multiplier, 9.9999f);
        }
        else if (pow == max.tenpow)
        {
            mult = Random.Range(1.0f, max.multiplier);
        }
        else
        {
            mult = Random.Range(1.0f, 9.9999f);
        }

        return new BigNumber(mult, pow);
    }

    public float GetMultiplier()
    {
        return multiplier;
    }

    public int GetTenPow()
    {
        return tenpow;
    }
}
