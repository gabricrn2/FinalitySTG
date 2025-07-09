using UnityEngine;

public class LazerShot : MonoBehaviour
{
    public GameObject projetil;
    public float velfire = 20.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire){

            nextFire = Time.time + fireRate;

            GameObject novoTiro = Instantiate(projetil, transform.position, transform.rotation);


            //novoTiro.linearVelocity = transform.TransformDirection(new Vector3(0,velfire,0));
            novoTiro.gameObject.transform.parent = gameObject.transform;
            novoTiro.GetComponent<LazerShot>().velfire = velfire;

        }

    }
}
