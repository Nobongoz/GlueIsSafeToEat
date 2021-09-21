using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExplode : MonoBehaviour
{
    public float fuseTime;
    public int debrisCount;
    public GameObject debris;
    public float minBurstForce;
    public float maxBurstForce;
    public Transform movingObject;
    private bool moveObject;

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
        if (moveObject)
        {
            movingObject.Translate(Vector3.right * 3f * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Contains("Clone"))
        {
            StartCoroutine(explode(collision.gameObject));
        }
    }

    IEnumerator explode(GameObject hitObject)
    {
        yield return new WaitForSeconds(fuseTime);
        for (int i = 0; i < debrisCount; i++)
        {
            GameObject newDust = Instantiate(debris);
            newDust.transform.position = hitObject.transform.position;
            newDust.GetComponent<Rigidbody2D>().velocity = ((new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(minBurstForce, maxBurstForce)));
            //yield return new WaitForSecondsRealtime(0.01f);
        }
        moveObject = true;
        Destroy(hitObject.gameObject);
    }
}
