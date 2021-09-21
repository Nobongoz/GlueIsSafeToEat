using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMassHide : MonoBehaviour
{
    public GameObject[] objectsToHide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MassHide()
    {
        foreach(GameObject objectToHide in objectsToHide)
        {
            objectToHide.SetActive(false);
        }
    }
}
