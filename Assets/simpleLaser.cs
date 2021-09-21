using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleLaser : MonoBehaviour
{
    public GameObject Dust;
    public int amountOfDust;
    public float minBurstForce;
    public float maxBurstForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.name.Contains("Clone"))
        {
            for(int i = 0; i < amountOfDust; i++)
            {
                GameObject newDust = Instantiate(Dust);
                newDust.transform.position = collision.transform.position;
                newDust.GetComponent<Rigidbody2D>().velocity = ((new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(minBurstForce, maxBurstForce)));
            }
            Destroy(collision.gameObject);
        }
    }
}
