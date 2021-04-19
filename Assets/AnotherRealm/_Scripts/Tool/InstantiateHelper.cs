using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHelper : MonoBehaviour
{

    public static GameObject InstatiateObject(GameObject g, Transform parent)
    {
        GameObject newG = Instantiate(g);
        Transform newGTran = newG.transform;
        newGTran.SetParent(parent);
        newGTran.localScale = Vector3.one;
        newGTran.localPosition = Vector3.zero;

        return newG;
    }
}
