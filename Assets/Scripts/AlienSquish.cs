using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSquish : MonoBehaviour
{
    public GameObject original;
    public GameObject SWOL;
    public float blastForce;
    public Transform groundToMove;
    private bool movingGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingGround == true)
        {
            groundToMove.Translate(Vector3.right * 4f * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        original.SetActive(false);
        SWOL.SetActive(true);
        Collider2D[] blast = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (Collider2D hit in blast)
        {
            if(hit.GetComponent<Rigidbody2D>() != null)
            {
                hit.GetComponent<Rigidbody2D>().AddForce(((hit.transform.position - transform.position).normalized + Vector3.up + Vector3.right) * blastForce);
            }
        }
        StartCoroutine(MoveGround());
    }
    IEnumerator MoveGround()
    {
        yield return new WaitForSeconds(4);
        movingGround = true;
        //cameraMovement.phase = 1;
    }
}
