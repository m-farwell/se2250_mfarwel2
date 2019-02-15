using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gameObject.transform.Rotate(7, 0, 0);
    }*/
    void OnMouseDown()
    {
        gameObject.transform.Rotate(7,0,0);
    }
}
