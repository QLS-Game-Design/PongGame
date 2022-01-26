using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticks : MonoBehaviour
{
    public float speed = 0.03f;
    private GameObject stick;
    private double lastInterval;
    private double currentTime;
    private Vector3 scaleChange = new Vector3(0,0.002f,0);
    // Start is called before the first frame update
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        stick = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.y < 2.5f)
        {
            transform.Translate(new Vector2(0, speed));
        }
        if (Input.GetKey(KeyCode.D) && transform.position.y > -2.5f)
        {
            transform.Translate(new Vector2(0, -speed));
        }
        currentTime = Time.realtimeSinceStartup;
        if ((currentTime > lastInterval + 5) && (stick.transform.localScale.y > 2)){
            stick.transform.localScale -= scaleChange;
        }
        
    }
}
