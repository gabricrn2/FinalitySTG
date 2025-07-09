using UnityEngine;

public class EnemyShotCollider : MonoBehaviour
{
    public Vector3 startPos;
    public float maxDistance = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        other.gameObject.SendMessage("TryGraze", gameObject, SendMessageOptions.DontRequireReceiver);
        other.gameObject.SendMessage("PlayerDamage", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    void DestroyBullets(){
        Destroy(gameObject);
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    void ClearScreenALL()
    {
        Destroy(gameObject);
    }


}
