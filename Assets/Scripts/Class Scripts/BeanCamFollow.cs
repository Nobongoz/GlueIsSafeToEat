using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCamFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), followSpeed * Time.fixedDeltaTime);
    }
}
