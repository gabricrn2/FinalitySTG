using UnityEngine;

public class ColisionResponderO3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float life = 50.0f;
    GenericClearEnemyScript clearer;
    public BarController Healthbar;
    public float points = 5;
    GameObject responder;


    void Start()
    {
        clearer = GetComponent<GenericClearEnemyScript>();
        responder = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Healthbar) Healthbar.SetHealth(life);
        if (life <= 0){
            //clearer.ExplodeOBJ();
            GivePoints();
            Destroy(gameObject);
            transform.gameObject.SendMessage("DespawnExtraRoutine", null, SendMessageOptions.DontRequireReceiver);
            transform.gameObject.SendMessage("SpawnItemOnDeath", null, SendMessageOptions.DontRequireReceiver);
            if (Healthbar) Healthbar.deactivateHealth();
        }
    }

    //void OnCollisionEnter2D(Collision2D other){

        //other.gameObject.SendMessage("ClearShot", null, SendMessageOptions.DontRequireReceiver);

    //}

    void ReceiveDamage(GameObject gameObject){

        gameObject.SendMessage("ClearShot", null, SendMessageOptions.DontRequireReceiver);

    }

    void CountDamage(float value){
        ///print(value);
        life = life - value;
    }
    void GivePoints(){

        responder.SendMessage("AddEnemyPoints", points, SendMessageOptions.DontRequireReceiver);
    }

    public void setupHealth(){
        if (Healthbar){
            Healthbar.initializeHealth();
            Healthbar.SetMAXHealth(life);
        }
    }



}
