using UnityEngine;

public class BombHandler : MonoBehaviour
{

    public Rigidbody2D projetil;
    public float velfire = 40.0f;
    public float InvincTime = 4.0f;
    public float Angle;
    private float Cooldown = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject father;
    public Start_Handler pauser;

    public AudioClip myClip;

    void Start()
    {
        father = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2") && !pauser.paused && Cooldown <= 0.0f){

            Player_Central c = gameObject.GetComponentInParent<Player_Central>();

            if (c.bombs > 0){

            Cooldown = InvincTime;

            father.SendMessage("GetInvinc", InvincTime, SendMessageOptions.DontRequireReceiver);
            father.SendMessage("ConsumeBomb", null, SendMessageOptions.DontRequireReceiver);


            Rigidbody2D novoTiro = Instantiate(projetil, transform.position, transform.rotation);
            //novoTiro.transform.parent.parent = gameObject.transform;

            novoTiro.linearVelocity = transform.TransformDirection(new Vector3(0,velfire,0));

            novoTiro = Instantiate(projetil, transform.position, transform.rotation);
            novoTiro.linearVelocity = transform.TransformDirection(new Vector3(velfire * Mathf.Sin(Angle),Mathf.Cos(Angle) * velfire,0));

            novoTiro = Instantiate(projetil, transform.position, transform.rotation);
            novoTiro.linearVelocity = transform.TransformDirection(new Vector3(velfire * Mathf.Sin(-Angle), Mathf.Cos(-Angle) * velfire,0));

            GetComponent<AudioSource>().PlayOneShot(myClip);
            }
        }
        Cooldown = Cooldown - Time.deltaTime;
    }
}
