using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class generic2DTrigger : MonoBehaviour
{
    public UnityEvent triggerEntered;
    public string tagCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(tagCheck != "")
        {
            if(collision.gameObject.tag == tagCheck)
            {
                triggerEntered.Invoke();
                Debug.Log("Triggered With Tag");
            }
        }
        else
        {
            triggerEntered.Invoke();
            Debug.Log("Triggered");
        }
    }
}
