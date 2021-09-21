using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2D : MonoBehaviour
{

    public Transform otherPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.transform.position = otherPortal.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity * 0.1f;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
