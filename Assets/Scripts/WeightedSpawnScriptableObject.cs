using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weighted Spawn Config", menuName = "ScriptableObject/Weighted Spawn Config")]
public class WeightedSpawnScriptableObject : ScriptableObject
{
    public GameObject Object;
    [Range(0f,1f)]
    public float MinWeight;
    [Range(0f,1f)]
    public float MaxWeight;

    public float GetWeight(){
        return Random.Range(MinWeight,MaxWeight);
    }
}
