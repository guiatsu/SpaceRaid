using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rig;
    public int damage = 20;
    public int health;
    public float score;
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
        rig.velocity = new Vector2(-1,0)*speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Despawn"){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlayerBullet"){
            PlayerBullet bullet  = col.gameObject.GetComponent<PlayerBullet>();
            health -= bullet.damage;
            Destroy(col.gameObject);
        }
        if(health <= 0){
            Game.GetInstance().UpdateScore(Game.GetInstance().GetScore()+score);
            Destroy(gameObject);
        }

    }
}
