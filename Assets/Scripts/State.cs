using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{

    public int difficulty =1;
    public int score =0 ;

    public int current_biome =0 ;
    
    //BUFF ARRay

    public bool isDead = false;
    
    
    public float animDur = 2.0f;


    public Text scoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        scoreText.text = score.ToString()+":"+difficulty.ToString();
        
    }
}
