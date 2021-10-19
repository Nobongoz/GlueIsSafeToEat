using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public bool canPlace;
    public GameObject heldObject;
    public SpriteRenderer objectSprite;
    public int selectedObject;
    public GameObject[] objects;
    public Vector2[] hitBoxSizes;
    public int objectLayer;
    public LayerMask blockingLayers;
    public Color invalid;
    public Color valid;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (heldObject == null && selectedObject > 0)
        {
            heldObject = Instantiate(objects[selectedObject]);
            heldObject.transform.position = mousePos;
            if(heldObject.GetComponent<Collider2D>() != null)
            {
                heldObject.GetComponent<Collider2D>().isTrigger = true;
            }
            objectSprite = heldObject.GetComponent<SpriteRenderer>();
            objectLayer = heldObject.layer;
            heldObject.layer = 8;
        }
        else
        {
            
            heldObject.transform.position = mousePos;

            Vector3 position = heldObject.transform.position;

            int xCount = Mathf.RoundToInt(position.x / 1);
            int yCount = Mathf.RoundToInt(position.y / 1);
            int zCount = Mathf.RoundToInt(position.z / 1);

            heldObject.transform.position = new Vector3(xCount, yCount, zCount);
            Collider2D touching = Physics2D.OverlapBox(heldObject.transform.position, hitBoxSizes[selectedObject], 0, blockingLayers);

            if (touching == null)
            {
                canPlace = true;
                objectSprite.color = valid;
            }
            else
            {
                canPlace = false;
                objectSprite.color = invalid;
            }

            if (canPlace && Input.GetMouseButton(0))
            {
                place();
            }
            if (Input.GetMouseButtonDown(1))
            {
                //delete();
            }
        }
    }

    void place()
    {
        heldObject.GetComponent<Collider2D>().isTrigger = false;
        heldObject.layer = objectLayer;
        objectSprite.color = Color.white;
        heldObject = null;
    }
}
