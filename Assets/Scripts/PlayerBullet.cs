using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        rig.velocity = new Vector2(1,0)*speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Fuel"){
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Despawn"){
            Destroy(gameObject);
        }

    }
}
