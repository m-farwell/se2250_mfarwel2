using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject prefab;
    public int numPrefabs = 10;
    public float radius = 3.0f;
    public Material material1;
    public Material material2;
    public Material material3;

    // Start is called before the first frame update
    void Start()
    {
        int switchCase;
        for (int i = 0; i < numPrefabs; i++)
        {
            float angle = i * Mathf.PI *2 / numPrefabs;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0.1f, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.Euler(45f, 45f, 45f));

            // use mod to instantiate a different ball colour each time
            switchCase = i % 3;
            switch (switchCase)
            {
                case 0:
                    prefab.GetComponent<MeshRenderer>().material = material1;
                    prefab.transform.tag = "Blue";
                    break;
                case 1:
                    prefab.GetComponent<MeshRenderer>().material = material2;
                    prefab.transform.tag = "Green";
                    break;
                case 2:
                    prefab.GetComponent<MeshRenderer>().material = material3;
                    prefab.transform.tag = "Yellow";
                    break;
            }
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
