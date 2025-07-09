using UnityEngine;

public class PopcornShotScript : MonoBehaviour
{

    public float velfire = 15.0f;
    public float Shottime = 0.3f;

    public Vector3 start_destiny;
    public Vector3 exit_destiny;
    public float move_vel;
    public bool is_awoken = false;
    public bool ended_voley = false;

    private float time = 0.0f;
    public int maxshots = 5;

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
        if (maxshots > 0){
            time = time + Time.deltaTime;
            if (time > Shottime){
                maxshots = maxshots - 1;
                time = 0;
                shooter.SpawnShotAtPlayer(transform.position, 0, velfire);
                GetComponent<AudioSource>().PlayOneShot(myClip);
            }
        } else {
            ended_voley = true;
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
        if (ended_voley){
            if (transform.position != exit_destiny){
                transform.position = Vector3.MoveTowards(transform.position, exit_destiny, move_vel * Time.deltaTime);
            }
            else {
                //clearer.ExplodeOBJ();
                Destroy(gameObject);
            }
        }
    }


}
