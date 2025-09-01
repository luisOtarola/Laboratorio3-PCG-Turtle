using System.Collections.Generic;
using UnityEngine;

public class LSystemGenerator : MonoBehaviour
{
    [System.Serializable]
    public class Rule
    {
        public char symbol;
        public string replacement;
    }
    public string axiom = "F";
    public int iterations = 4;
    public List<Rule> rules;

    public string Generate()
    {
        string currentString = axiom;

        for (int i = 0; i < iterations; i++)
        {
            string newString = "";
            foreach (char c in currentString)
            {
                bool replaced = false;
                foreach (Rule rule in rules)
                {
                    if (c == rule.symbol)
                    {
                        newString += rule.replacement;
                        replaced = true;
                        break;
                    }
                }
                if (!replaced)
                    newString += c.ToString();
            }
            currentString = newString;
        }

        return currentString;
    }
}
