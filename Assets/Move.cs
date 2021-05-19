using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 speed, acc;
    private Rigidbody2D body;
    public float SPEED_LIMIT = 0.08F;
    public float SPEED = 0.1F;
    public float FORCE = 10f;
    public float THRESHOLD = .008f;
    public float ARENA_RADIUS = 20;
    public float PUNISH = .002f;

    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        speed = new Vector3(0, 0, 0);
        acc = new Vector3(0, 0, 0);
    }

    void Awake()
    {
      body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      posUpdate(SPEED);
    }

    void FixedUpdate()
    {
      entripetal(THRESHOLD);

      envbound();
    }

    private void envbound()
    {
      // Vector3 pos = transform.position;
      // if(pos.x * pos.x)
    }

    private void entripetal(float entriForce){
      Vector3 pos = transform.position;

      // 向心力
      float rad2 = ARENA_RADIUS * ARENA_RADIUS;
      float sin0 = (float)Math.Sqrt((rad2 - pos.x * pos.x) / rad2 );
      float cos0 = (float)pos.x / ARENA_RADIUS;

      float sin1 = (float)Math.Sqrt((rad2 - pos.y * pos.y) / rad2 );
      float cos1 = (float)pos.y / ARENA_RADIUS;


      // 离心惩罚
      float angle = Vector3.Angle(new Vector3(-1 * pos.x, -1 * pos.y, 0), body.velocity);

      if(Math.Abs(pos.x) > 0.1 || Math.Abs(pos.y) > 0.1){
        Vector3 cent = new Vector3(-1 * pos.x, -1 * pos.y, 0) * entriForce;
        Vector3 anti = new Vector3(-1 * body.velocity.x, -1 * body.velocity.y, 0) * PUNISH;
        body.AddForce(
          cent + anti
        );
        //Debug.Log(cent-anti);
        // if(angle > 90){
        //   body.AddForce(new Vector3(-1 * body.velocity.x, -1 * body.velocity.y, 0) * PUNISH);
        // } else {
        //   body.AddForce(new Vector3(-1 * sin0 * cos0, -1 * sin1 * cos1, 0) * entriForce);
        // }
      }

      if(Math.Abs(body.velocity.x) > 0.1 || Math.Abs(body.velocity.y) > 0.1) {
        body.velocity = new Vector3(0, 0, 0);
      }
    }

    private void posUpdate(float speed){
      if (Input.GetKeyDown("w")) {
          acc.y += speed;
          Debug.Log("press W");
      }

      if (Input.GetKeyDown("s"))
      {
          acc.y -= speed;
          Debug.Log("press S");
      }

      if (Input.GetKeyDown("a"))
      {
          acc.x -= speed;
          Debug.Log("press A");
      }

      if (Input.GetKeyDown("d"))
      {
          acc.x += speed;
          Debug.Log("press D");
      }

      if (Input.GetKeyUp("w"))
      {
         acc.y -= speed;
          Debug.Log("release W");
      }

      if (Input.GetKeyUp("s"))
      {
         acc.y += speed;
          Debug.Log("release s");
      }

      if (Input.GetKeyUp("a"))
      {
          acc.x += speed;
          Debug.Log("release a");
      }

      if (Input.GetKeyUp("d"))
      {
          acc.x -= speed;
          Debug.Log("release d");
      }

      body.AddForce(acc * FORCE);
      if(acc.x != 0){
        Debug.Log(transform.right * 1f);
      }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collisioon");
    }
}
