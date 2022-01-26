using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class opponent : MonoBehaviour
{
    public float speed = 5.2f;
    public double obj_x;
    public double obj_y;
    public double maxVel = 15;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        obj_y = GameObject.FindGameObjectWithTag("ball").transform.position.y;
        obj_x = GameObject.FindGameObjectWithTag("ball").transform.position.x;
        if (obj_x < 0 && rb2d.velocity.y < maxVel){
        if (obj_y < transform.position.y)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, (rb2d.velocity.y - (float) (transform.position.y-obj_y)*speed),0);
        }
        else if (obj_y > transform.position.y)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, (rb2d.velocity.y + (float) (obj_y-transform.position.y)*speed),0);
        }}
    }
}
