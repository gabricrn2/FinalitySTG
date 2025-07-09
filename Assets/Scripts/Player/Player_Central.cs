using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Player_Central : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int lives;
    public int bombs;
    public int power;

    public int points;
    public int pointBaseValue;
    public int piv;

    public int grazenumber; //0-inf;
    public int grazebar; //0-20;
    public int maxgraze;

    public float deathTime = 5.0f;
    public float invincTime = 5.0f;
    public GameObject shipSprite;
    public Start_Handler gameOverHandler;
    public AudioClip pitchun;

    public TextMeshProUGUI displayPoints;
    public TextMeshProUGUI displayhp;
    public TextMeshProUGUI displaybomb;
    public TextMeshProUGUI displaygrazenumber;
    public Slider displaygrazebar;


    void Start()
    {
        displaygrazebar.maxValue = maxgraze;
    }

    // Update is called once per frame
    void Update()
    {
        invincTime = (invincTime <= 0) ? 0 : invincTime - Time.deltaTime;
        UpdateUI();

    }

    void UpdateUI(){
        displayhp.text = lives.ToString();
        displaybomb.text = bombs.ToString();
        displaygrazenumber.text = grazenumber.ToString();
        displaygrazebar.value = grazebar;
        displayPoints.text = (points * 100).ToString();
    }

    public void Pitchun(){
        if (invincTime > 0) return;

        lives = lives - 1;
        power = (power > 100) ? power - 100 : 0;

        bombs = bombs >= 3 ? bombs + 1 : 3;

        if (pitchun) GetComponent<AudioSource>().PlayOneShot(pitchun);

        GetInvinc(5.0f);
        if (lives == -1){
            lives = 0;
            gameOverHandler.GameOver();
        }
    }

    public void GetInvinc(float time){
        invincTime = time;
        shipSprite.SendMessage("BlinkSprite", time, SendMessageOptions.DontRequireReceiver);
    }

    public void PowerUP(int value){
        power = (power == 400) ? 400 : power + value;
    }
    public void GivePoints(){
        points = points + piv * pointBaseValue;
    }
    public void ConsumeBomb(){
        bombs = bombs - 1;
    }
    public void Graze(){
        grazenumber = grazenumber + 1;
        grazebar = (grazebar == maxgraze) ? maxgraze : grazebar + 1;
    }
    public void AddEnemyPoints(int x){
        points = points + x;
    }

}
