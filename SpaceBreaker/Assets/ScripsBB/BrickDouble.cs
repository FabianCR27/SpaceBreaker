using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDouble : MonoBehaviour
{

    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;
    public Transform BoomObj;
    public Transform extraLive;

    private int whichpowerup;


    // Start is called before the first frame update
    void Start()
    {
   
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        whichpowerup = Random.Range(1, 5);

        if (hitsToBreak > 1)
        {
            BreakBrick();
 
        }
        else
        {
            if (whichpowerup == 1) //%chance
            {

                Instantiate(extraLive, collision.transform.position, collision.transform.rotation);
                Instantiate(BoomObj, collision.transform.position, BoomObj.rotation);
            }
            Destroy(gameObject);// break dissapears
    
        }
    }


    public void BreakBrick()
    {
        hitsToBreak = hitsToBreak -1;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
