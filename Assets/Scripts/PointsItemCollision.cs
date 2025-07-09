using UnityEngine;

public class PointsItemCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool IsPower = false;
    private Rigidbody2D Rb;
    public float acel = 5;
    public float floor = -20.0f;
    public float startvel = 1.0f;

    bool autocollect = false;
    GameObject player;
    float move_vel = 5.0f;


    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.linearVelocity  =  new Vector2(0.0f, startvel);

        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < floor){
            Destroy(gameObject);
        }
        if (!autocollect) Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, Rb.linearVelocity.y - Time.deltaTime * acel);

        if (autocollect){
            Rb.linearVelocity = new Vector2(0.0f,0.0f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, move_vel * Time.deltaTime);
        }





    }

    void OnCollisionEnter2D(Collision2D other){
        print("hit");
        other.gameObject.SendMessage("GetItem", IsPower, SendMessageOptions.DontRequireReceiver);
        other.gameObject.SendMessage("ItemCollide", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    void ClearScreenALL()
    {
        autocollect = true;
    }

}
