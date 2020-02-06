using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGenerator
{
    private string leftVowels;
    private string rightVowels;
    private string leftConstanants;
    private string rightConstanants;
    int side;

    List<string> calculatedSyllables;

    public StringGenerator(int side)
    {
        leftVowels = "ea";
        rightVowels = "uio";
        leftConstanants = "qwrtsdfzxcv";
        rightConstanants = "ypghjklbnm";
        this.side = side;
        calculatedSyllables = new List<string>();
        CalculateSyllables();
    }

    private void CalculateSyllables()
    {
        string calculatedSyllable = "";
        if (side == 0)
        {
            foreach (char a in leftConstanants)
            {
                foreach (char b in leftVowels)
                {
                    foreach (char c in leftConstanants)
                    {
                        calculatedSyllable += a + b + c;
                        calculatedSyllables.Add(calculatedSyllable);
                        calculatedSyllable = "";
                    }
                }
            }
        }
        else if (side == 1)
        {
            foreach (char a in rightConstanants)
            {
                foreach (char b in rightVowels)
                {
                    foreach (char c in rightConstanants)
                    {
                        calculatedSyllable += a + b + c;
                        calculatedSyllables.Add(calculatedSyllable);
                        calculatedSyllable = "";
                    }
                }
            }
        }
    }

    public string CalculateSpawnString(int level)
    {
        
        string calculatedString = "";
        for (int i = 0; i < (level+1)*4; i++)
        {
            calculatedString += calculatedSyllables[Random.Range(0, calculatedSyllables.Count)];
        }
        return calculatedString;
    }
}
