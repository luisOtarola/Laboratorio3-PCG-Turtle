using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    //b->a a->ab
    //int 0 a, 1 b
    public GameObject prefab;
    int contador;
    float rotacionA;
    float rotacionB;
    [SerializeField] private int limite = 5;

    void Start()
    {
        contador = 0;
        GameObject primeraRama = Instantiate(prefab);
        primeraRama.transform.SetParent(transform);
        rotacionA = -30f;
        rotacionB = rotacionA-1;
        nextBranch(primeraRama, 1);
    }

    void nextBranch(GameObject a, int ramaAnterior)
    {
        if (contador>=limite)
        {
            return;
        }
        //rotacionA += 3;
        //rotacionB = rotacionA -1;
        //a
        if (ramaAnterior == 1)
        {


            GameObject ramaa = Instantiate (prefab,a.transform.position,Quaternion.identity,a.transform);
            ramaa.transform.localRotation = Quaternion.Euler(0f,0f,Random.Range(-30f,31f));
            ramaa.transform.localPosition = new Vector3(0f, 3f, 0f);
            GameObject ramab = Instantiate(prefab, a.transform.position, Quaternion.identity, a.transform);
            ramab.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-30f, 31f));
            ramab.transform.localPosition = new Vector3(0f, 3f, 0f);
            contador++;
            nextBranch(ramaa, 1);
            nextBranch(ramab, 0);
        }
        //b
        else if(ramaAnterior == 0)
        {
            GameObject rama = Instantiate(prefab, a.transform.position, Quaternion.identity, a.transform);
            rama.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-30f, 31f));
            rama.transform.localPosition = new Vector3(0f, 3f, 0f);
            contador++;
            nextBranch(rama, 0);
        }

    }

    void Update()
    {

    }
}