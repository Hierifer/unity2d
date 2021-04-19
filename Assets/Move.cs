using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 speed, acc;
    public float SPEED_LIMIT = 0.1F;
    public float SPEED_LIMIT_REV = -0.1F;
    public float ACC = 0.06F;
    public float fraction = 0.02F;

    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        speed = new Vector3(0, 0, 0);
        acc = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            acc.y += ACC;
            Debug.Log("press W");
        }

        if (Input.GetKeyDown("s"))
        {
            acc.y -= ACC;
            Debug.Log("press S");
        }

        if (Input.GetKeyDown("a"))
        {
            acc.x -= ACC;
            Debug.Log("press A");
        }

        if (Input.GetKeyDown("d"))
        {
            acc.x += ACC;
            Debug.Log("press D");
        }

        if (Input.GetKeyUp("w"))
        {
           acc.y -= ACC;
            Debug.Log("release W");
        }

        if (Input.GetKeyUp("s"))
        {
           acc.y += ACC;
            Debug.Log("release s");
        }

        if (Input.GetKeyUp("a"))
        {
            acc.x += ACC;
            Debug.Log("release a");
        }

        if (Input.GetKeyUp("d"))
        {
            acc.x -= ACC;
            Debug.Log("release d");
        }

        transform.position += acc;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collisioon");
    }
}
