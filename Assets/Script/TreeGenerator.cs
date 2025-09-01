using UnityEngine;
using System.Collections.Generic;

public class GrammarTree : MonoBehaviour
{
    [Header("Prefab de la rama (ej: Cube alargado)")]
    public GameObject prefab;

    [Header("Parámetros del árbol")]
    public int iterations = 5;     // Cuántas veces aplicar las reglas
    public float branchLength = 3f;
    public float angle = 30f;

    private string axiom = "b";
    private Dictionary<char, string> rules = new Dictionary<char, string>();

    void Start()
    {
        // Definimos reglas: a -> ab, b -> a
        rules['a'] = "ab";
        rules['b'] = "a";

        // Generar la secuencia
        string sequence = Generate(iterations);
        Debug.Log("Secuencia generada: " + sequence);

        // Interpretar la secuencia en Unity
        Interpret(sequence);
    }

    // Genera la secuencia aplicando reglas
    string Generate(int iterations)
    {
        string current = axiom;

        for (int i = 0; i < iterations; i++)
        {
            string next = "";
            foreach (char c in current)
            {
                if (rules.ContainsKey(c))
                    next += rules[c];
                else
                    next += c;
            }
            current = next;
        }

        return current;
    }

    // Interpreta la secuencia y crea ramas en Unity
    void Interpret(string sequence)
    {
        Vector3 currentPosition = Vector3.zero;
        Quaternion currentRotation = Quaternion.identity;

        foreach (char c in sequence)
        {
            if (c == 'a')
            {
                // Rama recta hacia arriba
                GameObject rama = Instantiate(prefab, transform);
                rama.transform.localPosition = currentPosition;
                rama.transform.localRotation = currentRotation;

                // Avanza hacia arriba
                currentPosition += currentRotation * Vector3.up * branchLength;
            }
            else if (c == 'b')
            {
                // Rama con inclinación
                GameObject rama = Instantiate(prefab, transform);
                rama.transform.localPosition = currentPosition;
                rama.transform.localRotation = currentRotation * Quaternion.Euler(0f, 0f, angle);

                // Avanza con inclinación
                currentPosition += (currentRotation * Quaternion.Euler(0f, 0f, angle)) * Vector3.up * branchLength;
            }
        }
    }
}
