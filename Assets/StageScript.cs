using UnityEngine;

public class StageScript : MonoBehaviour
{
	public GameObject EnemySmall;
	public GameObject EnemyMedium;
	public GameObject EnemyBig;
	public GameObject SubBoss;
	public GameObject Boss;

	public float start_time;
	public float general_interval;
	public float general_interval2;
	public float elap_time;

	public float volleyside = -1.0f;
	public bool lastvolley = false;


	public bool firstWaveInit = false;
	public bool subBossSpawned;
	public bool subBossDead;
	public bool prelastvoley = false;
	public bool bossSpawned = false;
	public bool bossDead = false;
	public bool stageEnded = false;


	public GameObject threedeecamera;
	public BarController bossBar;
	public GameObject endtext;

	public MusicPlayer musicPlayer;

	int camerastage = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		threedeecamera = GameObject.FindGameObjectsWithTag("ThreeDeeCamera")[0];
		start_time = Time.time;
		musicPlayer.PlayStageMusic();

    }

    // Update is called once per frame
    void Update()
    {
		UpdateTimings();
		EnemyShower();
    }

	void UpdateTimings(){
        elap_time = Time.time - start_time;
		general_interval = general_interval - Time.deltaTime;
		general_interval2 = general_interval2 - Time.deltaTime;
	}

	void SpawnVoley(int X, int side){ //Spawn 6 enemies, no shotting.

		var n = -0.5f;
		while (n < 3){
			n = n + 1;

			GameObject enemy = Instantiate(EnemySmall, new Vector3(side * n + X, 7 + n/2, 0), transform.rotation);
			enemy.transform.parent = transform;
			PopcornShotScript popcorn = enemy.GetComponent<PopcornShotScript>();
			popcorn.maxshots = 0;
			popcorn.start_destiny = new Vector3(side * n + X, -10, 0);
			popcorn.exit_destiny = popcorn.start_destiny;
			popcorn.move_vel = 1;

		}
	}
	void SpawnVoleyALT2(int X, float side){ //Spawn 6 enemies, shotting.

		var n = -0.5f;
		while (n < 3){
			n = n + 1;

			GameObject enemy = Instantiate(EnemySmall, new Vector3(side * n + X, 7 + n/2, 0), transform.rotation);
			enemy.transform.parent = transform;
			PopcornShotScript popcorn = enemy.GetComponent<PopcornShotScript>();
			popcorn.maxshots = 5;
			popcorn.start_destiny = new Vector3(side * n + X, 1, 0);
			popcorn.exit_destiny = popcorn.transform.position;
			popcorn.move_vel = 2;
			popcorn.velfire = 2.0f;

		}
	}

    void EnemyShowerSpawn(int times, float vel){
		var n = 0;
		while (n < times){
			n = n + 1;
			float w = Random.Range(-4.2f,4.2f);

			GameObject enemy = Instantiate(EnemySmall, new Vector3(w, 7 + n/4, 0), transform.rotation);	
			enemy.transform.parent = transform;
			PopcornShotScript popcorn = enemy.GetComponent<PopcornShotScript>();
			popcorn.maxshots = 0; 
			popcorn.start_destiny = new Vector3(w, -10, 0); 
			popcorn.exit_destiny = popcorn.start_destiny;
			popcorn.move_vel = 1;
		
		}
	}

	void SpawnVoleyALT(int X){ //Spawn 6 enemies, no shotting.
		var side = Random.Range(-4.2f,4.2f);
		var n = -0.5f;
		while (n < 3){
			n = n + 1;

			GameObject enemy = Instantiate(EnemySmall, new Vector3(side * n + X, 7 + n/2, 0), transform.rotation);
			enemy.transform.parent = transform;
			PopcornShotScript popcorn = enemy.GetComponent<PopcornShotScript>();
			popcorn.maxshots = 0;
			popcorn.start_destiny = new Vector3(side * n + X, -10, 0);
			popcorn.exit_destiny = popcorn.start_destiny;
			popcorn.move_vel = 1;

		}
	}

	void MediumEnemyShowerSpawn(int times){
		var n = 0;
		while (n < times){
			n = n + 1;
			float w = Random.Range(-4.2f,4.2f);
			float z = Random.Range(-0.2f,0.2f);

			GameObject enemy = Instantiate(EnemyMedium, new Vector3(w, 7 + n/4, 0), transform.rotation);	
			enemy.transform.parent = transform;
			MediumEnemyShotScript medium = enemy.GetComponent<MediumEnemyShotScript>();
			medium.velfire = 1.0f;
			medium.start_destiny = new Vector3(w, 3+z, 0); 
			medium.exit_destiny = new Vector3(w, 3+z, 0);
			medium.move_vel = 3.0f;
			medium.Shottime = 0.5f;
		}
	}

	void BigEnemyShowerSpawn(int times){
		var n = 0;
		while (n < times){
			n = n + 1;
			float w = Random.Range(-4.2f,4.2f);
			float z = Random.Range(-0.2f,0.2f);

			GameObject enemy = Instantiate(EnemyBig, new Vector3(0, 9, 0), transform.rotation);
			enemy.transform.parent = transform;
			BigEnemyShotScript subboss = enemy.GetComponent<BigEnemyShotScript>();
			subboss.velfire = 3.0f;
			subboss.start_destiny = new Vector3(w, 3+z, 0);
			subboss.exit_destiny = new Vector3(w, 3+z, 0);
			subboss.move_vel = 2.0f;
		}
	}

	void BigEnemyStationarySpawn(float X, float z){
		GameObject enemy = Instantiate(EnemyBig, new Vector3(X, 9, 0), transform.rotation);
		enemy.transform.parent = transform;
		BigEnemyShotScript subboss = enemy.GetComponent<BigEnemyShotScript>();
		subboss.velfire = 3.0f;
		subboss.start_destiny = new Vector3(X, 6, 0);
		subboss.exit_destiny = new Vector3(X, 3+z, 0);
		subboss.move_vel = 4.0f;
	}

	void SubBossSpawn(){
		GameObject enemy = Instantiate(SubBoss, new Vector3(0, 9, 0), transform.rotation);
		enemy.transform.parent = transform;
		BigEnemyShotScript subboss = enemy.GetComponent<BigEnemyShotScript>();
		subboss.velfire = 4.0f;
		subboss.start_destiny = new Vector3(0, 5, 0);
		subboss.exit_destiny = new Vector3(0, 5, 0);
		subboss.move_vel = 3.0f;
		subboss.spawner = gameObject;
		var bosshealth = enemy.GetComponent<ColisionResponderO3>();
		bosshealth.Healthbar = bossBar;
		bosshealth.setupHealth();
	}

	void SpawnBoss(){
		GameObject enemy = Instantiate(Boss, new Vector3(0, 9, 0), transform.rotation);
		enemy.transform.parent = transform;
		var boss = enemy.GetComponent<SubBossShotSpawner>();
		boss.start_destiny = new Vector3(0.0f, 5.0f, 0.0f);
		boss.spawner = gameObject;
		var bosshealth = enemy.GetComponent<ColisionResponderO3>();
		bosshealth.Healthbar = bossBar;
		bosshealth.setupHealth();
	}

    void EnemyShower(){

		if ((general_interval < 0) && (10 < elap_time) && (elap_time < 40)) {
			if (!firstWaveInit){
				SpawnVoley(0,1);
				SpawnVoley(0, -1);
				firstWaveInit = true;
			}
			EnemyShowerSpawn(1, 1.0f);
			general_interval = 0.5f;
		}

		if ((general_interval2 < 0) && (20 < elap_time) && (elap_time < 30)) {
			MediumEnemyShowerSpawn(1);
			general_interval2 = 4.0f;
		}

		if ((general_interval2 < 0) && (30 < elap_time) && (elap_time < 40)) {
			MediumEnemyShowerSpawn(1);
			general_interval2 = 2.0f;
		}

		if ((general_interval2 < 0) && (30 < elap_time) && (elap_time < 40)) {
			MediumEnemyShowerSpawn(1);
			general_interval2 = 1.0f;
		}

		if ((general_interval < 0) && (40 < elap_time) && (elap_time < 50)) {
			SpawnVoleyALT(1);
			general_interval = 2.5f;
		}

		if ((general_interval2 < 0) && (40 < elap_time) && (elap_time < 50)) {
			MediumEnemyShowerSpawn(1);
			general_interval2 = 0.7f;
		}

		//Camera2
		if ((elap_time > 50) && (elap_time < 80)){
			if (!subBossSpawned){
				if(camerastage == 0){threedeecamera.SendMessage("ChangePosition1", null, SendMessageOptions.DontRequireReceiver); camerastage = 1;}
				BroadcastMessage("ClearScreenALL", null, SendMessageOptions.DontRequireReceiver);
				SubBossSpawn();
				subBossSpawned = true;
			} else if (subBossDead && ((general_interval < 0))){
				if(camerastage == 1){threedeecamera.SendMessage("ChangePosition2", null, SendMessageOptions.DontRequireReceiver); camerastage = 2;}
				EnemyShowerSpawn(1, 4.0f);
				general_interval = 0.5f;
			}
		}

		if ((elap_time > 80) && (elap_time < 107)){
			if (!subBossDead) BroadcastMessage("ClearScreenALL", null, SendMessageOptions.DontRequireReceiver);
			subBossDead = true;
			if(camerastage == 1){threedeecamera.SendMessage("ChangePosition2", null, SendMessageOptions.DontRequireReceiver); camerastage = 2;}

			if ((general_interval < 0)){
				general_interval = 5.0f;
				BigEnemyShowerSpawn(1);
			}
			if ((general_interval2 < 0)){
				general_interval2 = 2.0f;
				volleyside = volleyside * -1;
				SpawnVoleyALT2(0, volleyside);
			}
		}

		if ((elap_time > 107) && !prelastvoley){
			BroadcastMessage("ClearScreenALL", null, SendMessageOptions.DontRequireReceiver);
			prelastvoley = true;
		}

		if ((elap_time > 110) && (elap_time < 120) && (!lastvolley)){
			BroadcastMessage("ClearScreenALL", null, SendMessageOptions.DontRequireReceiver);
			lastvolley = true;
			if(camerastage == 2){threedeecamera.SendMessage("ChangePosition3", null, SendMessageOptions.DontRequireReceiver); camerastage = 3;}
			BigEnemyStationarySpawn(0,-0.5f);
			BigEnemyStationarySpawn(-2,1.5f);
			BigEnemyStationarySpawn(2,1.5f);
		}

		if (elap_time > 130){
			if (!bossSpawned){
				musicPlayer.PlayBossMusic();
				if(camerastage == 3){threedeecamera.SendMessage("ChangePosition4", null, SendMessageOptions.DontRequireReceiver); camerastage = 4;}
				BroadcastMessage("ClearScreenALL", null, SendMessageOptions.DontRequireReceiver);
				SpawnBoss();
			}
			bossSpawned = true;
		}

		if  (bossDead && !stageEnded ) {
			stageEnded = true;
			general_interval2 = 3.0f;
		}
		if (bossDead && general_interval2 < 0){
			EndStage();
		}
    }

    ///Mensagens
    public void SubBossKilled(){
		subBossDead = true;
	}
	public void BossKilled(){
		bossDead = true;
	}
	void EndStage(){
		musicPlayer.FinishMusic();
		endtext.SetActive(true);
	}


}
