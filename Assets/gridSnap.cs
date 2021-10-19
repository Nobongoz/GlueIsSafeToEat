using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSnap : MonoBehaviour
{
    float snapDist = 1;
    public bool updating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        int xCount = Mathf.RoundToInt(position.x / snapDist);
        int yCount = Mathf.RoundToInt(position.y / snapDist);
        int zCount = Mathf.RoundToInt(position.z / snapDist);

        transform.position = new Vector3(xCount, yCount, zCount);

        if (!updating)
        {
            gameObject.GetComponent<gridSnap>().enabled = false;
        }
    }
}
