using UnityEngine;

public class InsideEnemyColider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        other.gameObject.SendMessage("PlayerDamage", gameObject, SendMessageOptions.DontRequireReceiver);
    }
}
