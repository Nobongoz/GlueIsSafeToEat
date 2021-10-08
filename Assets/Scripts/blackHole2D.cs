using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHole2D : MonoBehaviour
{
    public float pullForce;
    public float pullRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] blast = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (Collider2D hit in blast)
        {
            if (hit.GetComponent<Rigidbody2D>() != null)
            {
                float dist = Vector2.Distance(transform.position, hit.transform.position);
                float pullForceMod = (pullForce * (pullRadius / dist));
                Mathf.Clamp(pullForceMod, 0, pullForce);
                hit.GetComponent<Rigidbody2D>().AddForce(((transform.position - hit.transform.position).normalized) * pullForceMod);
            }
        }
    }
}
