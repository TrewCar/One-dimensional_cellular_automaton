using System;
using System.Linq;

static class ConvertNumberSystemM
{
    /// <summary>
    /// Только для восьбитный чисел (0..255)
    /// </summary>
    /// <param name="Number">Число в десятичной системе стичсления</param>
    /// <returns></returns>
    static public string ToBinary(this int Number)
    {
        var number = Convert.ToString(Number, 2);
        while (number.Count() < 8)
        {
            number = "0" + number;
        }
        return number;
    }
    static public int ToDecimal(this int Number) => Convert.ToInt32(Number.ToString(), 2);
    static public int ToDecimal(this string Number) => Convert.ToInt32(Number, 2);
}