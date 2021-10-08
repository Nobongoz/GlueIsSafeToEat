using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float range;
    public LayerMask hitAble;
    private AudioSource mySource;
    private AudioClip tempClip;

    // Start is called before the first frame update
    void Start()
    {
        mySource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        faceMouse(mousePos);

        if(Input.GetAxisRaw("Vertical") != 0)
        {
            move(mousePos * Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            mousePos = transform.up * 180;
            move(mousePos * Input.GetAxisRaw("Horizontal"));
        }

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        if (Input.GetMouseButton(0))
        {
            laser(direction);
        }
    }

    void faceMouse(Vector3 mousePos)
    {
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = direction;
    }

    void move(Vector3 mousePos)
    {
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, step);
    }

    void laser(Vector3 dir)
    {
        Debug.DrawRay(transform.position, dir.normalized * range, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, hitAble);
        if(hit.collider != null)
        {
            if(hit.transform.gameObject.GetComponent<classSound>() != null)
            {
                tempClip = hit.transform.gameObject.GetComponent<classSound>().myClip;
                mySource.PlayOneShot(tempClip);
            }
        }
    }
}
