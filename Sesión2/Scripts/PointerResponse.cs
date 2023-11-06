using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerResponse : MonoBehaviour
{
    int contador = 0;
    bool poder = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poder)
        {
            contador++;
        }
    }

    public void OnPointerEnter()
    {
        poder = true;
        if (contador >= 1000)
        {
            print("killed");
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
