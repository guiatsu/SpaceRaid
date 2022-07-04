using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<WeightedSpawnScriptableObject> spawnPool;
    [SerializeField] 
    public float[] Weights;
    public float spawnRate;
    [SerializeField]
    private Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = ScriptableObject.CreateInstance<Timer>();
        Weights = new float[spawnPool.Count];
        ResetWeights();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer.Update();
        if(spawnTimer.Get() >= (1/spawnRate)){
            Spawn();
            spawnTimer.Reset();
        }   
    }
    void ResetWeights(){
        float TotalWeight = 0;
        for (int i = 0; i<spawnPool.Count;i++){
            Weights[i] = spawnPool[i].GetWeight();
            TotalWeight+=Weights[i];

        }
        for(int i = 0; i < Weights.Length;i++){
            Weights[i] = Weights[i]/TotalWeight;
        }
    }
    WeightedSpawnScriptableObject EnemyToSpawn(){
        float value = Random.Range(0f, 1f);
        for(int i =0; i<Weights.Length;i++){
            if(value < Weights[i])
                return spawnPool[i];
            value -= Weights[i];
            
        }
        Debug.Log(value);
        return spawnPool[0];
    }
    void Spawn()
    {
        bool colliderHere = true;
        GameObject toSpawn = EnemyToSpawn().Object;
        Vector2 scale = toSpawn.GetComponent<Transform>().localScale;
        Vector2 size = toSpawn.GetComponent<BoxCollider2D>().size;
        Vector2 scaledSize = size*scale;
        Vector2 rotatedSize = new Vector2(0,0);
        rotatedSize.x = Mathf.Abs(toSpawn.GetComponent<Transform>().InverseTransformVector(scaledSize*scale).x);
        rotatedSize.y = Mathf.Abs(toSpawn.GetComponent<Transform>().TransformVector(size).y);
        float screenY = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 0.0005f)).y+(rotatedSize.y/2),Camera.main.ViewportToWorldPoint(new Vector2(0, 0.95195f)).y-(rotatedSize.y/2));
        float screenX = Camera.main.ViewportToWorldPoint(new Vector2(1f,0f)).x+(rotatedSize.x/2)+1f;
        Vector2 initialPos = new Vector2(screenX,screenY);
        Vector2 spawnPosition = initialPos;
        float angle = toSpawn.GetComponent<Transform>().localEulerAngles.z;
        for(float i = screenY; i >= (Camera.main.ScreenToWorldPoint(new Vector2(0, 0.0005f)).y+(rotatedSize.y/2)); i-=0.01f){
            colliderHere = Physics2D.OverlapBox(spawnPosition, scaledSize, angle) != null;
            if(!colliderHere)
                break;
            spawnPosition = new Vector2(screenX,screenY);
        }
        if(colliderHere)
            for(float i = screenY+0.01f; i<=(Camera.main.ViewportToWorldPoint(new Vector2(0, 0.95195f)).y-(rotatedSize.y/2));i+=0.01f){
                colliderHere = Physics2D.OverlapBox(spawnPosition, scaledSize, angle) != null;
                if(!colliderHere)
                    break;
                spawnPosition = new Vector2(screenX,screenY);
            }
        if(colliderHere)
            return;
        var newObj = Instantiate(toSpawn,spawnPosition,toSpawn.transform.rotation);
        newObj.transform.parent = GameObject.Find("SpawnedEntities").transform;

    }
    void DebugDrawBox( Vector2 point, Vector2 size, float angle, Color color, float duration) {

        var orientation = Quaternion.Euler(0, 0, angle);

        // Basis vectors, half the size in each direction from the center.
        Vector2 right = orientation * Vector2.right * size.x/2f;
        Vector2 up = orientation * Vector2.up * size.y/2f;

        // Four box corners.
        var topLeft = point + up - right;
        var topRight = point + up + right;
        var bottomRight = point - up + right;
        var bottomLeft = point - up - right;

        // Now we've reduced the problem to drawing lines.
        Debug.DrawLine(topLeft, topRight, color, duration);
        Debug.DrawLine(topRight, bottomRight, color, duration);
        Debug.DrawLine(bottomRight, bottomLeft, color, duration);
        Debug.DrawLine(bottomLeft, topLeft, color, duration);
    }
}
