using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float speed;

    public int animDir;
    public bool moving;
    public Animator myAnim;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        animDir = 2;
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        int profanityNum = Random.Range(0, 4);
        string[] profanity = new string[4] { "egg", "pie", "mango", "cake" };
        Debug.Log("Eat a  " + profanity[profanityNum] + " " + Time.time);
        */
    }

    void FixedUpdate()
    {
        #region Movement
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * speed * xInput);
        //transform.Translate(Vector3.up * speed * yInput);
        myBody.velocity = new Vector3(speed * xInput, speed * yInput, 0);
        #endregion

        #region Animations
        moving = true;
        if(yInput > 0)
        {
            animDir = 1;
        }
        else if (yInput < 0)
        {
            animDir = 2;
        }
        else if (xInput > 0)
        {
            animDir = 3;
        }
        else if (xInput < 0)
        {
            animDir = 4;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            myAnim.SetFloat("Blend", animDir - 1);
        }
        else
        {
            myAnim.SetFloat("Blend", (animDir - 1) + 4);
        }
        if (animDir == 4)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        #endregion
    }
}
