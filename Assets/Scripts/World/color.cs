using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    public Color c1 = new Color(255f, 0f, 0f, 0f);

    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = c1;
    }
}
