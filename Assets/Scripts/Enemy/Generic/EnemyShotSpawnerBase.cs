using UnityEngine;

public class EnemyShotSpawnerBase : MonoBehaviour
{

    public Rigidbody2D projetil;

    private GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame

    void Update()
    {
    }

    public void SpawnShotAtPlayer(Vector3 position, float angle, float velfire){

        //projetil = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - position;
        if (angle!=0.0f){
            direction = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
        }

        Rigidbody2D novoTiro = Instantiate(projetil, position, transform.rotation);
        // novoTiro.linearVelocity = transform.TransformDirection(direction);
        novoTiro.linearVelocity = new Vector2(direction.x, direction.y).normalized * velfire;
        novoTiro.transform.parent = transform.parent;
    }

    public void SpawnRandomShot(Vector3 position, float velfire){
        Rigidbody2D novoTiro = Instantiate(projetil, position, transform.rotation);
        var direction = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * new Vector3(0,1,0);
        novoTiro.linearVelocity = new Vector2(direction.x, direction.y).normalized * velfire;
        novoTiro.transform.parent = transform.parent;

    }

    public void SpawnAngledShot(Vector3 position, Vector3 direction, float velfire){
        Rigidbody2D novoTiro = Instantiate(projetil, position, transform.rotation);
        novoTiro.linearVelocity = new Vector2(direction.x, direction.y).normalized * velfire;
        novoTiro.transform.parent = transform.parent;

    }

}
