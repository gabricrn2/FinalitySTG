using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{

    public GameObject Item;
    public float radius;
    public int amount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItemOnDeath (){
        var n = 0;
        while (n < amount){
            n = n + 1;
            var randomx = Random.Range(-radius,radius);
            var randomy = Random.Range(-radius,radius);
            GameObject item = Instantiate(Item, new Vector3(transform.position.x+randomx, transform.position.y + randomy, transform.position.z), transform.rotation);
            item.transform.parent = transform.parent;
        }

    }

}
