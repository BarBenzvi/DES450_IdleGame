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

    //Copy constructor
    public BigNumber(BigNumber other)
    {
        multiplier = other.multiplier;
        tenpow = other.tenpow;
    }

    //Default constructor (uses default values for vars declared above)
    public BigNumber() { }

    //Explicit constructor
    public BigNumber(float mult, int tp)
    {
        multiplier = mult;
        tenpow = tp;
    }

    //Static variable used to control display type (can be either scientific notation, or named notation)
    private static DisplayType disp = DisplayType.SCIENTIFIC;

    //String array of names for each 10^3x power starting at million
    private readonly static string[] powNames =
        { "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion",
          "Undecillion", "Dodecillion", "Tredicillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septen-decillion", "Octodecillion",
          "Novemdecillion", "Vigintillion" };

    //Converts a BigNumber to a string using either scientific, numeric, or named notation
    public override string ToString()
    {
        //Always use numeric notation if we are less than 1 million
        if (tenpow <= 5)
        {
            return ((int)(multiplier * Mathf.Pow(10, tenpow))).ToString();
        }

        //Sample scientific notation number (sci notation always follows this format):
        //123450000 = 123.45 million = 1.2345e+8
        if (disp == DisplayType.SCIENTIFIC)
        {
            return multiplier.ToString("0.####") + $"e+{tenpow}";
        }
        //Converts the big number to named notation
        else if (disp == DisplayType.NAMES)
        {
            //Find the index of our correct name
            int index = (tenpow - 6) / 3;
            //If the index is outside of the array (currently at 66+ zeroes), just use scientific notation
            if (index >= powNames.Length)
            {
                return multiplier.ToString("0.####") + $"e+{tenpow}";
            }
            
            //Currently this is set up to always have 4 digits followed by the name
            //The number of non-decimal digits is determined by the difference between the tenpow of the number and the tenpow of 
            //the name at our index + 1, e.g. 100 million has a tenpow of 8, 8 - 6 = 2, 2 + 1 = 3 (100 has 3 non-decimal digits)
            int numZeros = (tenpow - 6) % 3;
            string formatString = "0";
            for (int i = 0; i < numZeros; ++i)
            {
                formatString += "0";
            }
            //Any remaining digits will be decimal up to a total of 4 digits
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

    //Allows you to change the display type of ALL big numbers (there is no local display type)
    public static void SetDisplayType(DisplayType d)
    {
        disp = d;
    }

    //Gets the current display type of ALL big numbers (there is no local display type)
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

    //Creates and returns a BigNumber equivalent to 0
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
        if(i == 0)
        {
            return Zero();
        }

        BigNumber n = new BigNumber();
        n.tenpow = (int)Mathf.Log10(i);
        n.multiplier = (float)i / Mathf.Pow(10, n.tenpow);

        return n;
    }

    public static explicit operator BigNumber(float f)
    {
        if (f == 0)
        {
            return Zero();
        }

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
        if (lhs.tenpow - rhs.tenpow > 8 || rhs == Zero())
        {
            return lhs;
        }
        else if (lhs.tenpow - rhs.tenpow < -8 || lhs == Zero())
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
        if(lhs == Zero() || rhs == Zero())
        {
            return Zero();
        }

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
        if (lhs == Zero() || rhs == Zero())
        {
            return Zero();
        }

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

    //Creates and returns a random BigNumber between min and max
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