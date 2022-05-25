using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab : MonoBehaviour
{
    
    private Vector2 cordenada;

    // Start is called before the first frame update
    void Start()
    {
        cordenada = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cordenada = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Debug.Log("Cordenades:" + cordenada);
        }
        transform.position = cordenada;
    }
}
