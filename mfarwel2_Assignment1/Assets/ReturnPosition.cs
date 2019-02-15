using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPosition : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
        startPos = gameObject.transform.position;
   
    }

    // MouseClick should be used when the user clicks RIGHT button
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
            gameObject.transform.position = startPos;
    }

}
