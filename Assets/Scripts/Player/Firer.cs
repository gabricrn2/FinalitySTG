using UnityEngine;

public class Firer : MonoBehaviour
{

    public Rigidbody2D projetil;
    public float velfire = 20.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float upPos = 0.5f;

    public Start_Handler pauser;
    public AudioClip myClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && !pauser.paused){

            nextFire = Time.time + fireRate;


            Vector3 temp = transform.position;
            temp.y += upPos;

            Rigidbody2D novoTiro = Instantiate(projetil, temp, transform.rotation);
            //novoTiro.transform.parent.parent = gameObject.transform;
            novoTiro.linearVelocity = transform.TransformDirection(new Vector3(0,velfire,0));

            if (myClip) GetComponent<AudioSource>().PlayOneShot(myClip);
            }


    }
        
}

