using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePaddle : MonoBehaviour
{

    [SerializeField] private Slider Slider = null;
    [SerializeField] private float positionLimit = 2f;
    //limits paddle
    public float rightscreenedge;
    public float leftscereenedge;
    private static GameManager gm;
    bool resetPowerUp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Slider.value;
        transform.position = new Vector2(pos * positionLimit, transform.position.y);

        //limits paddle
        if (transform.position.x < leftscereenedge)
        {
            transform.position = new Vector2(leftscereenedge, transform.position.y);
        }

        if (transform.position.x > rightscreenedge)
        {
            transform.position = new Vector2(rightscreenedge, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
            if (other.CompareTag("ExtraLife"))
            {
                gm = GameManager.instance;
                gm.UpdateLives(1);
                Destroy(other.gameObject);
            }
            if (other.CompareTag("fireball"))
            {
                gm = GameManager.instance;
                gm.UpdateLives(1);
                Destroy(other.gameObject);
            }
            if (other.CompareTag("bigpaddle"))
            {
                GetComponent<Transform>().localScale = new Vector2(0.5f, 0.15f);
                Destroy(other.gameObject);

            }
            if (other.CompareTag("smallpaddle"))
            {
                GetComponent<Transform>().localScale = new Vector2(0.16f, 0.11f);
                Destroy(other.gameObject);
            }

        
    }   

}

