using UnityEngine;

public class SubBossShotSpawner : MonoBehaviour
{
    ColisionResponderO3 colider;
    EnemyShotSpawnerBase shooter;
    GameObject player;
    public GameObject spawner;

    public float velfire_stage1_1 = 3.0f;
    public float velfire_stage1_2 = 15.0f;
    public float Shottime1 = 0.5f;
    public float curtaintime = 0.2f;
    public float windowDist = 2.5f;

    public Vector3 curtainangle;
    Vector3 finalcurtainangle;
    public float curtainclosespeed;

    public float Shottime2 = 0.3f;
    public float velfire_stage2 = 3.0f;
    public float shotRampup = 1.0f;

    float Shottime;
    float velfire;
    float velfire2;

    public bool isalive = false;
    private float time = 0.0f;
    private float time2 = 0.0f;
    public bool phaseChanged = false;

    public float move_vel = 3.0f;
    public bool is_awoken = false;
    public Vector3 start_destiny;
    public Vector3 stay_destiny;

    public AudioClip myClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        shooter = GetComponent<EnemyShotSpawnerBase>();
        colider = GetComponent<ColisionResponderO3>();
        velfire = velfire_stage1_1;
        velfire2 = velfire_stage1_2;
        Shottime = Shottime1;

        finalcurtainangle = new Vector3(0,-1,0);

    }

    // Update is called once per frame
    void Update()
    {
        Move_itself();
        if (is_awoken){
            if (colider.life < 3000 && !phaseChanged)
            {
                phaseChanged = true;
                velfire = velfire_stage2;
                Shottime = Shottime2;
                stay_destiny = new Vector3(0.0f, transform.position.y, transform.position.z); //x center

            }
            if (phaseChanged) {
                Stage2Shot();
            }

            else {
                Stage1Shot();
                Stage1Move();
            };


        }


    }

    void Stage1Shot(){
        curtainangle = Vector3.RotateTowards(curtainangle, finalcurtainangle, curtainclosespeed * Time.deltaTime, 0);



        time2 = time2 + Time.deltaTime;
        if (time2 > curtaintime){
            GetComponent<AudioSource>().PlayOneShot(myClip);
            time2 = 0;
            var shotpos1 = new Vector3(transform.position.x + windowDist, transform.position.y, transform.position.z);
            var shotpos2 = new Vector3(transform.position.x - windowDist, transform.position.y, transform.position.z);

            shooter.SpawnAngledShot(shotpos1, new Vector3(curtainangle.x,curtainangle.y,0), velfire2);
            shooter.SpawnAngledShot(shotpos2, new Vector3(-curtainangle.x,curtainangle.y,0), velfire2);
        }

        time = time + Time.deltaTime;
        if (time > Shottime){
            time = 0;
            GetComponent<AudioSource>().PlayOneShot(myClip);
            shooter.SpawnShotAtPlayer(transform.position, 0, velfire);
        }
    }


    void Stage1Move(){
        stay_destiny = new Vector3( player.transform.position.x, transform.position.y, transform.position.z);

    }


    void Stage2Shot(){
        velfire = velfire + Time.deltaTime * shotRampup;
        time2 = time2 + Time.deltaTime;
        if (time2 > Shottime){
            time2 = 0;
            GetComponent<AudioSource>().PlayOneShot(myClip);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
                shooter.SpawnRandomShot(transform.position, velfire);
        }
    }

    //TODO: lib this!
    void Move_itself(){
        if (!is_awoken){
            if (transform.position != start_destiny){
                transform.position = Vector3.MoveTowards(transform.position, start_destiny, move_vel * Time.deltaTime);
            } else {
                is_awoken = true;
            }
        }
        if (is_awoken){
            if (transform.position != stay_destiny){
                transform.position = Vector3.MoveTowards(transform.position, stay_destiny, move_vel * Time.deltaTime);
            }
        }
    }

    public void DespawnExtraRoutine(){
        if (spawner){
            spawner.SendMessage("BossKilled", null, SendMessageOptions.DontRequireReceiver);
        }
    }

}
