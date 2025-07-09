using UnityEngine;

public class TiroExplosaoScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created;
    public float bombTime = 2.0f;
    private float fuseTime;
    public float damage = 20.0f;
    public float damageInFrame;
    public AudioClip myClip;

    void Start()
    {
        //StartCoroutine("SelfDestruct()");
        fuseTime = bombTime;
        GetComponent<AudioSource>().PlayOneShot(myClip);
    }

    // Update is called once per frame
    void Update()
    {
        damageInFrame = damage * Time.deltaTime;

        if (fuseTime <= 0.0f) {
            Destroy(gameObject);
        } else {
            fuseTime -= Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D other){
        other.gameObject.SendMessage("ReceiveDamage", gameObject, SendMessageOptions.DontRequireReceiver);
        other.gameObject.SendMessage("CountDamage", damageInFrame, SendMessageOptions.DontRequireReceiver);
        other.gameObject.SendMessage("DestroyBullets", null, SendMessageOptions.DontRequireReceiver);
    }

}
