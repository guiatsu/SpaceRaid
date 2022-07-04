using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private Transform[] firepoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Timer coolDownTimer;
    [SerializeField]
    private float weaponCooldown;
    [SerializeField]
    private bool autoShoot = false;
    void Start(){
        coolDownTimer = ScriptableObject.CreateInstance<Timer>();
    }
    void Update()
    {   
        coolDownTimer.Update();
        if(GetComponent<Player>()){
            if(Input.GetButton("Fire1") || autoShoot){
                if(coolDownTimer.Get() >= weaponCooldown){
                    Shoot();
                    coolDownTimer.Reset();
                }   
            }
            if(Input.GetKeyDown(KeyCode.I))
                autoShoot = !autoShoot;

        }
        else{
            if(autoShoot)
                if(coolDownTimer.Get() >= weaponCooldown){
                    Shoot();
                    coolDownTimer.Reset();
                }   
        }
        
    }
    void Shoot(){
        for(int i = 0; i < firepoint.Length;i++){
            var newObj = Instantiate(bulletPrefab,firepoint[i].position,firepoint[i].rotation);
            newObj.transform.parent = GameObject.Find("SpawnedEntities").transform;
        }
        
    }
}
