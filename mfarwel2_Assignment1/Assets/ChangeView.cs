using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
 
    public Camera SideView;
    public Camera TopView;
    bool SideViewOn = true;

    // Start is called before the first frame update
    void Start()
    {
        SideView.enabled = true;
        TopView.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("c"))
        {
                TopView.enabled = SideViewOn;
                SideView.enabled = !SideViewOn;
                SideViewOn = !SideViewOn;
        }
    }
}
