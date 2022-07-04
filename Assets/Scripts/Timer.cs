using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Timer", menuName = "ScriptableObject/Timer")]
public class Timer : ScriptableObject
{
    private float time;


    // Start is called before the first frame update
    void Awake()
    {

        time = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        time += Time.deltaTime;
    }
    public void Reset()
    {
        time = 0;
    }
    public float Get()
    {
        return time;
    }

}
