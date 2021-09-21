using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishySquare : MonoBehaviour
{
    public bool squishable;
    public float minScale;
    public float scanDist;
    public LayerMask statics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(squishable)
        {
            //Debug.Log("Collided");
            ContactPoint2D[] contacts = collision.contacts;
            Vector3 hitDirection = Vector3.one;
            /*
            foreach (ContactPoint2D contact in contacts)
            {
                Vector3 pointPos = contact.point;
                //Debug.DrawRay(pointPos, (pointPos - transform.position).normalized * 2, Color.green, 10);
                //Debug.DrawRay(pointPos, collision.relativeVelocity, Color.green, 10);
                hitDirection = hitDirection * collision.relativeVelocity;
            }
            */

            Debug.DrawRay(gameObject.transform.position, hitDirection.normalized / collision.contactCount, Color.green, 2);



            if(collision.gameObject.GetComponent<DraggyCube>() != null)
            {
                hitDirection = collision.gameObject.GetComponent<DraggyCube>().prevVel;
            }
            else
            {
                hitDirection = gameObject.transform.position - collision.transform.position;
            }
            
            
            RaycastHit2D[] hit;
            hit = Physics2D.RaycastAll(gameObject.transform.position, hitDirection.normalized, scanDist, statics);

            Debug.DrawRay(gameObject.transform.position, (hitDirection.normalized / collision.contactCount) * scanDist, Color.red, 2);

            foreach (RaycastHit2D otherHit in hit)
            {
                if(otherHit.collider != null)
                {
                    Vector3 squishDir = hitDirection.normalized;
                    Vector3 squishCalc = new Vector3(Mathf.Abs(squishDir.x) * 0.1f, Mathf.Abs(squishDir.y) * 0.1f, 0);
                    squish(squishCalc);
                }
            }
        }
    }

    public void squish(Vector3 squishAmount)
    {
        gameObject.transform.localScale = gameObject.transform.localScale - squishAmount;
    }
}
