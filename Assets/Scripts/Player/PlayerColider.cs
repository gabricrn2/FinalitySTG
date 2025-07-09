using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerDamage(){
        gameObject.GetComponent<Player_Central>().Pitchun();
    }

    void GetItem(bool isPower){

        if (isPower){
            gameObject.GetComponent<Player_Central>().PowerUP(1);
        }
        else{
            gameObject.GetComponent<Player_Central>().GivePoints();
        }
    }

    void ItemCollide(GameObject item){
        Destroy(item);
    }
}
