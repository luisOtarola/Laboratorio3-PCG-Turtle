using System.Collections.Generic;
using UnityEngine;

public class LSystemTurtle : MonoBehaviour
{
    public LSystemGenerator generator;
    public float length = 2f;
    public float angle = 25f;
    public GameObject branchPrefab;

    void Start()
    {
        string sequence = generator.Generate();
        Debug.Log("Generated Sequence: " + sequence);
        Interpret(sequence);
    }

    void Interpret(string sequence)
    {
        Stack<TransformInfo> stack = new Stack<TransformInfo>();

        foreach (char c in sequence)
        {
            if (c == 'F')
            {
                Vector3 startPos = transform.position;
                transform.Translate(Vector3.up * length);

                if (branchPrefab != null)
                {
                    GameObject branch = Instantiate(branchPrefab);
                    branch.transform.position = (startPos + transform.position) / 2f;
                    branch.transform.up = transform.position - startPos;
                    branch.transform.localScale = new Vector3(0.1f, length / 2f, 0.1f);
                }
            }
            else if (c == '+')
            {
                transform.Rotate(Vector3.forward * angle);
            }
            else if (c == '-')
            {
                transform.Rotate(Vector3.forward * -angle);
            }
            else if (c == '[')
            {
                stack.Push(new TransformInfo(transform.position, transform.rotation));
            }
            else if (c == ']')
            {
                TransformInfo ti = stack.Pop();
                transform.position = ti.position;
                transform.rotation = ti.rotation;
            }
        }
    }

    private struct TransformInfo
    {
        public Vector3 position;
        public Quaternion rotation;

        public TransformInfo(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }
}
