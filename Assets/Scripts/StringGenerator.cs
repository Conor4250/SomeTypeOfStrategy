using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGenerator
{
    private static string leftVowels = "ea";
    private static string rightVowels = "uio";
    private static string leftConstanants = "qwrtsdfzxcv";
    private static string rightConstanants = "ypghjklbnm";
    List<string> calculatedSyllables;



    public StringGenerator(int player)
    {
        calculatedSyllables = new List<string>();
        CalculateSyllables(player);

    }

    private void CalculateSyllables(int player)
    {
        string calculatedSyllable = "";
        if (player == 1)
        {
            foreach (char a in leftConstanants)
            {
                foreach (char b in leftVowels)
                {
                    foreach (char c in leftConstanants)
                    {
                        calculatedSyllable = "" + a + b + c;
                        calculatedSyllables.Add(calculatedSyllable);
                    }
                }
            }
        }
        else if (player == 2)
        {
            foreach (char a in rightConstanants)
            {
                foreach (char b in rightVowels)
                {
                    foreach (char c in rightConstanants)
                    {
                        calculatedSyllable = "" + a + b + c;
                        calculatedSyllables.Add(calculatedSyllable);
                    }
                }
            }
        }
    }

    public string CalculateSpawnString(int complexity)
    {
        
        string calculatedString = "";
        for (int i = 0; i < (complexity+1); i++)
        {
            calculatedString += calculatedSyllables[Random.Range(0, calculatedSyllables.Count)];
        }
        return calculatedString;
    }
}
