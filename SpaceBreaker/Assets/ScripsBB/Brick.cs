using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private GameManager code; //reference to game manager
    public Transform extraLive;
   // public Transform fireball;
    public Transform BoomObj;
    public Transform bigPaddle;
    public Transform smallPaddle;

    public int whichpowerup;
    
    // Start is called before the first frame update
    void Start()
    {
        code = GameManager.instance;
        code.AddBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

  private void OnCollisionExit2D (Collision2D collision)
    {
   
            Destroy(gameObject); // break dissapears 
            code.AddPoints();
            whichpowerup = Random.Range(1, 7);


            if (whichpowerup == 1) //%chance
            {

                Instantiate(extraLive, collision.transform.position, collision.transform.rotation);
                Instantiate(BoomObj, collision.transform.position, BoomObj.rotation);
            }

            //if (whichpowerup == 2) //%chance
            //{

            //    Instantiate(fireball, collision.transform.position, collision.transform.rotation);
            //    Instantiate(BoomObj, collision.transform.position, BoomObj.rotation);
            //}
            if (whichpowerup == 3) //%chance
            {

                Instantiate(bigPaddle, collision.transform.position, collision.transform.rotation);
                Instantiate(BoomObj, collision.transform.position, BoomObj.rotation);
            }
            if (whichpowerup == 4) //%chance
            {

                Instantiate(smallPaddle, collision.transform.position, collision.transform.rotation);
                Instantiate(BoomObj, collision.transform.position, BoomObj.rotation);
            }          
    }


}
