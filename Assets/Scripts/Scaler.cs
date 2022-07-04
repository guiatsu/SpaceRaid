using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    public float minSize;
    public float maxSize;
    public float speed;
    private float actualSize;
    private bool increasing ;
    private Vector3 initialSize;
    public float offset = -1;
    
    [SerializeField]
    private Timer timer;

    void Start()
    {
        increasing = true;
        actualSize = 1;
        initialSize = transform.localScale;
        timer = ScriptableObject.CreateInstance<Timer>();
        if(offset == -1){
            offset = Random.Range(0,2f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer.Update();
        if(timer.Get() >= offset){
            if(increasing){
                actualSize += 0.001f*speed*Time.deltaTime;
                if(actualSize >= maxSize){
                    actualSize = maxSize;
                    increasing = !increasing;
                }
                transform.localScale = (initialSize*actualSize);
            }
            else{
                actualSize -= 0.001f*speed*Time.deltaTime;
                if(actualSize <= minSize){
                    actualSize = minSize;
                    increasing = !increasing;
                }
                transform.localScale = (initialSize*actualSize);
        }
        }   
    }
}
