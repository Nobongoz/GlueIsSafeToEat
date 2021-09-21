using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggyCube : MonoBehaviour
{
    public bool draggable;
    public float dragForce;
    private Rigidbody2D myBody;
    public Vector3 prevVel;
    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //myBody.AddForce((worldPos - gameObject.transform.position) * dragForce);
        myBody.velocity = ((worldPos - gameObject.transform.position) * dragForce);
    }
    private void FixedUpdate()
    {
        StartCoroutine(lastFrameVel());
    }
    IEnumerator lastFrameVel()
    {
        yield return new WaitForFixedUpdate();
        prevVel = myBody.velocity;
    }
}
