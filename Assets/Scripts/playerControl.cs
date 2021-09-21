using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerControl : MonoBehaviour
{
    public float speed;
    private float x;
    private Rigidbody2D playerBody;

    public GameObject debugSquare;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.name.Contains("Clone"))
        {
            x = Input.GetAxisRaw("Horizontal");
            playerBody.velocity = new Vector3(x * speed, playerBody.velocity.y);
            //playerBody.angularVelocity = x * speed;

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                GameObject newCube = Instantiate(gameObject);
                newCube.transform.position = new Vector3(newCube.transform.position.x, newCube.transform.position.y - 0.5f, 0);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                //playerBody.AddForce((Vector2.right + Vector2.up) * 1000);
            }

            debugSquare.transform.position = (playerBody.position + (playerBody.velocity.normalized));
        }
        else
        {
            if(gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale -= Vector3.one * 0.005f;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
