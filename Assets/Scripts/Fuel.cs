using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] public float fuel;
    [SerializeField] public float speed;
    [SerializeField] public Rigidbody2D rig;
    [SerializeField] public float spawnChance;

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
        if(col.gameObject.tag == "Player"){
            Game.GetInstance().UpdateFuel(Game.GetInstance().GetFuel()+ fuel);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Despawn"){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlayerBullet"){
            Destroy(gameObject);
        }

    }
}
