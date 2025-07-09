using UnityEngine;

public class MediumEnemyShotScript : MonoBehaviour
{

    public float velfire = 15.0f;
    public float Shottime = 0.3f;
    public bool spammy = false;

    public Vector3 start_destiny;
    public Vector3 exit_destiny;
    public float move_vel;
    public float move_vel2;
    public bool destroyable = false;

    public bool is_awoken = false;
    public bool ended_voley = false;

    private float time = 0.0f;
    public bool is_aimed = true;
    //public int maxshots = 5;

    EnemyShotSpawnerBase shooter;
    GenericClearEnemyScript clearer;

    public AudioClip myClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shooter = GetComponent<EnemyShotSpawnerBase>();
        clearer = GetComponent<GenericClearEnemyScript>();
        //start_destiny = transform.position;
        //exit_destiny = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move_itself();
        if (is_awoken){
        Try_shoot();
        }
    }

    //Shooting subroutine
    void Try_shoot(){

        time = time + Time.deltaTime;
        if (time > Shottime){
            time = 0;

            GetComponent<AudioSource>().PlayOneShot(myClip);

            if (is_aimed){
                shooter.SpawnShotAtPlayer(transform.position, 0, velfire);
                shooter.SpawnShotAtPlayer(transform.position, 30, velfire);
                shooter.SpawnShotAtPlayer(transform.position, -30, velfire);
            } else{
                shooter.SpawnAngledShot(transform.position,  new Vector3(0,-1,0), velfire);
                if (spammy){
                    shooter.SpawnAngledShot(transform.position,  new Vector3(Mathf.Cos(30),-Mathf.Sin(30),0), velfire);
                    shooter.SpawnAngledShot(transform.position,  new Vector3(-Mathf.Cos(30),-Mathf.Sin(30),0), velfire);
                }
                shooter.SpawnAngledShot(transform.position,  new Vector3(Mathf.Cos(45), -Mathf.Sin(45),0), velfire);
                shooter.SpawnAngledShot(transform.position,  new Vector3(-Mathf.Cos(45), -Mathf.Sin(45),0), velfire);
            }
        }
    }

    //Moving subroutine
    void Move_itself(){
        if (!is_awoken){
            if (transform.position != start_destiny){
                transform.position = Vector3.MoveTowards(transform.position, start_destiny, move_vel * Time.deltaTime);
            } else {
                is_awoken = true;
            }
        }
        if (is_awoken){
            if (transform.position != exit_destiny){
                transform.position = Vector3.MoveTowards(transform.position, exit_destiny, move_vel2 * Time.deltaTime);
            } else {
                if (destroyable) Destroy(gameObject);
            }
        }
    }


}
