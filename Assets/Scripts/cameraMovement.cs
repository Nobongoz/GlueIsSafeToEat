using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] targets;
    public static int phase;
    public Transform mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.position = Vector3.Lerp(mainCam.position, targets[phase].position, moveSpeed * Time.deltaTime);
    }
}
