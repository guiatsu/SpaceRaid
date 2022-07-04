using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    public float health;
    [SerializeField] private TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: "+ health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
            
        Move();

    }
    void LateUpdate()
    {
        if(health <= 0f || Game.GetInstance().GetFuel() <= 0f){
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void Move()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy"){
            Enemy enemy  = col.gameObject.GetComponent<Enemy>();
            health -= enemy.damage;
            healthText.text = "Health: "+ health.ToString();
            Destroy(col.gameObject);

        }
        if(health <= 0f){
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnemyBullet"){
            EnemyBullet bullet  = col.gameObject.GetComponent<EnemyBullet>();
            health -= bullet.damage;
            healthText.text = "Health: "+ health.ToString();
            Destroy(col.gameObject);
        }
    }
}
