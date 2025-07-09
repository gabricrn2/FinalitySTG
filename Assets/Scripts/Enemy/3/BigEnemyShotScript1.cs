using UnityEngine;

public class BigEnemyShotScript : MonoBehaviour
{

    public float velfire = 5.0f;
    public float Shottime = 0.3f;
    public bool spammy = false;

    public Vector3 start_destiny;
    public Vector3 exit_destiny;
    public float move_vel;
    public bool destroyable = false;

    public bool is_awoken = false;
    public bool ended_voley = false;

    private float time = 0.0f;
    public bool is_random = true;
    //public int maxshots = 5;
    public Vector3 shot_up;

    public GameObject spawner;
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
        shot_up = new Vector3(0, -1, 0);
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
        shot_up = Quaternion.AngleAxis(Random.Range(1.0f, 5.0f), Vector3.forward) * shot_up;
        time = time + Time.deltaTime;
        
        if (time > Shottime){
            time = 0;
            GetComponent<AudioSource>().PlayOneShot(myClip);

            if (is_random){
                if (spammy)
                {
                    shooter.SpawnRandomShot(transform.position, velfire);
                    shooter.SpawnRandomShot(transform.position, velfire);
                    shooter.SpawnRandomShot(transform.position, velfire);
                    shooter.SpawnRandomShot(transform.position, velfire);
                    shooter.SpawnRandomShot(transform.position, velfire);
                    shooter.SpawnRandomShot(transform.position, velfire);   
                }
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
            } else{
                var realvel = velfire + velfire * -Mathf.Cos(Time.time) / 4;
                shooter.SpawnAngledShot(transform.position, shot_up, velfire);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(60.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(-60.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(30.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(-30.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(90, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position, shot_up, velfire);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(120.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(-120.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(-90.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(-30.0f, Vector3.forward) * shot_up, realvel);
                shooter.SpawnAngledShot(transform.position,  Quaternion.AngleAxis(180.0f, Vector3.forward) * shot_up, realvel);
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
                transform.position = Vector3.MoveTowards(transform.position, exit_destiny, move_vel * Time.deltaTime);
            } else {
                if (destroyable) Destroy(gameObject);
            }
        }
    }

    void DespawnExtraRoutine(){
        if (spawner){
            spawner.SendMessage("SubBossKilled", null, SendMessageOptions.DontRequireReceiver);
        }
    }


}
