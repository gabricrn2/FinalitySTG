using UnityEngine;

public class TiroNaveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Trashy
    public Vector3 startPos;
    public float maxDistance = 20;
    public float damage = 5.0f;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      if (Vector3.Distance(transform.position, startPos) > maxDistance){
          Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        other.gameObject.SendMessage("ReceiveDamage", gameObject, SendMessageOptions.DontRequireReceiver);
        other.gameObject.SendMessage("CountDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    void ClearShot(){
        Destroy(gameObject);
    }

}
