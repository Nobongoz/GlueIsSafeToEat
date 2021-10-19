using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePlacer : MonoBehaviour
{
    /*
    public bool placed;
    public bool canPlace;
    
    public SpriteRenderer mySprite;
    private BoxCollider2D myCol;
    public LayerMask blockingLayers;

    // Start is called before the first frame update
    void Start()
    {
        myCol = gameObject.GetComponent<BoxCollider2D>();
        myCol.isTrigger = true;
        mySprite.color = valid;
        gameObject.layer = 8;
        canPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!placed)
        {
           
        }
    }

    private void LateUpdate()
    {
        if(!placed)
        {
            Vector2 senseScale = new Vector2(0.9f, 0.9f);
            Collider2D touching = Physics2D.OverlapBox(transform.position, senseScale, 0, blockingLayers);

            if (touching == null)
            {
                canPlace = true;
                mySprite.color = valid;
            }
            else
            {
                canPlace = false;
                mySprite.color = invalid;
            }
        }
    }

    public void place()
    {
        placed = true;
        Camera.main.GetComponent<objectSpawner>().holdingObject = false;
        mySprite.color = Color.white;
        myCol.isTrigger = false;
        gameObject.layer = 9;
    }

    void delete()
    {
        Camera.main.GetComponent<objectSpawner>().holdingObject = false;
        Destroy(gameObject);
    }
    */
}
