using UnityEngine;
using UnityEngine.UI;

public class ScoringGeneralScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int pointvalue;
    public Player_Central scorehome;

    public void addPoints(){
        scorehome.AddEnemyPoints(pointvalue);
    }
}
