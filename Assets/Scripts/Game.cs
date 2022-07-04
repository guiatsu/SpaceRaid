using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{   
    private static Game instance;
    [SerializeField] private float score;
    [SerializeField] private float fuel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text fuelText;
    [SerializeField]
    private Timer scoreTimer;
    [SerializeField]
    private Timer fuelTimer;
    [SerializeField] private float fuelSpendRate;
    [SerializeField] private float scoreEarnRate;
    // Start is called before the first frame update

    void Start()
    {   
        instance = this;
        scoreTimer = ScriptableObject.CreateInstance<Timer>();
        fuelTimer = ScriptableObject.CreateInstance<Timer>();
        UpdateFuel(fuel);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene("Menu");

        UpdateTimers();
    }
    void UpdateTimers(){
        scoreTimer.Update();
        fuelTimer.Update();
        if(scoreTimer.Get() >= 1f/(scoreEarnRate)){
            UpdateScore(score+1f);
            scoreTimer.Reset();
        }   
        if(fuelTimer.Get() >= 1f/(fuelSpendRate)){
            if(fuel>0f)
                UpdateFuel(fuel-1f);
            fuelTimer.Reset();
        }   
    }
    public void UpdateScore(float score){
        this.score = score;
        scoreText.text = "Score:" + Mathf.Floor(this.score).ToString();
    }
    public void UpdateFuel(float fuel){
        this.fuel = fuel;
        fuelText.text = "Fuel:" + Mathf.Floor(this.fuel).ToString();
    }
    public float GetScore(){
        return score;
    }
    public float GetFuel(){
        return fuel;
    }
    public static Game GetInstance(){
        return instance;
    }
  
}
