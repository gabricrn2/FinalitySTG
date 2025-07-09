using UnityEngine;

public class TiroBombaScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 startPos;
    public float maxDistance = 20;
    public GameObject Bomb;
    private float elapTime;




    void Start()
    {
        startPos = transform.position;
        elapTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        elapTime = elapTime + Time.deltaTime;

        if (Vector3.Distance(transform.position, startPos) > maxDistance){
            SpawnBomb();
            Destroy(gameObject);
        }

        if (Input.GetButtonUp("Fire2") && elapTime > 0.15f){
            SpawnBomb();
            Destroy(gameObject);
        }

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 ||
            screenPos.x > Screen.width || screenPos.y > Screen.height)
        {
            SpawnBomb();
            Destroy (gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other){

        other.gameObject.SendMessage("ReceiveDamage", gameObject, SendMessageOptions.DontRequireReceiver);

    }

    void ClearShot(){
        SpawnBomb();
        Destroy(gameObject);
    }

    void SpawnBomb(){



        GameObject novoTiro = Instantiate(Bomb, transform.position, transform.rotation);

    }
}
