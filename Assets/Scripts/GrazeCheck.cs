using UnityEngine;

public class GrazeCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryGraze(){
        print("porcaria");
        gameObject.GetComponent<Player_Central>().Graze();
    }

}
