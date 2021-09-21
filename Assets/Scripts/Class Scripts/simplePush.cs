using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePush : MonoBehaviour
{
    public float pushForce;
    public Rigidbody2D myBody;
    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myBody.AddForce((Vector2.up + Vector2.right) * pushForce);
        }
    }
}
