using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int maxDepth = 5;
    public float branchLength = 3f;
    public float angle = 30f;
    public float scaleFactor = 0.7f;

    void Start()
    {
        GameObject root = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        GenerateBranch(root, 0);
    }

    void GenerateBranch(GameObject parent, int depth)
    {
        if (depth >= maxDepth) return;

        // Crear dos ramas
        for (int i = -1; i <= 1; i += 2) // -1 = izquierda, 1 = derecha
        {
            GameObject branch = Instantiate(prefab, parent.transform);

            // Posición en la punta de la rama anterior
            branch.transform.localPosition = new Vector3(0f, branchLength, 0f);

            // Rotación con ángulo
            branch.transform.localRotation = Quaternion.Euler(0f, 0f, i * angle);

            // Escalar un poco más pequeño
            branch.transform.localScale *= scaleFactor;

            // Recursión
            GenerateBranch(branch, depth + 1);
        }
    }
}
