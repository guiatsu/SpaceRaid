using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    public int damage = 25;
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
        var orientation = Quaternion.Euler(transform.eulerAngles);
        rig.velocity = orientation*new Vector2(1,0)*speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Despawn"){
            Destroy(gameObject);
        }

    }
}
