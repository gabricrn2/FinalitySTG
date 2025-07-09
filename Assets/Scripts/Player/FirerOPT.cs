using UnityEngine;

public class FirerOPT : MonoBehaviour
{

    public Rigidbody2D projetil;
    public float velfire = 20.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float maxAngle = 0.0f;

    float side = 1.0f;
    float Angle = 0.0f;
    public float AngleOfset = 0.0f;
    public int parity = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Angle = (parity%2 == 0) ? AngleOfset + 1.570796f : AngleOfset;
        side = (parity%2 == 0) ? 1.0f : -1.0f;

        if (Input.GetButton("Fire1") && Time.time > nextFire){

            nextFire = Time.time + fireRate;

            Rigidbody2D novoTiro = Instantiate(projetil, transform.position, transform.rotation);
            //novoTiro.transform.parent.parent = gameObject.transform;




            if (!Input.GetButton("Debug Next")){
                var Shot_angle = ((Time.time*5*side + Angle)); //rad
                //novoTiro.transform.Rotate(new Vector3(0,0,Shot_angle));
                novoTiro.linearVelocity = transform.TransformDirection(new Vector3(velfire * Mathf.Sin(Shot_angle)*Mathf.Sin(1.570796f/8.0f),Mathf.Abs(velfire*Mathf.Cos(Shot_angle)*Mathf.Cos(1.570796f/8.0f)),0));



            }




            else{
                novoTiro.linearVelocity = transform.TransformDirection(new Vector3(0,velfire,0));



            }


        }

    }
}
