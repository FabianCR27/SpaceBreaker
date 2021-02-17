using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
   private const float Speed = 7f;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Setup(new Vector3(0,1));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Speed * Time.deltaTime;
    }
    private void Setup(Vector3 dir)
    {
        this.dir = dir;
    }
}
