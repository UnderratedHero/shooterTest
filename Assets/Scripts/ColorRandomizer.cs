using System.Text;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    private static System.Random _random = new();

    public string GenerateRandomColor(int length)
    {
        const string symbols = "ABCDEF0123456789";
        var result = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            result.Append(symbols[_random.Next(symbols.Length)]);
        }

        return result.ToString(); 
    }
}
