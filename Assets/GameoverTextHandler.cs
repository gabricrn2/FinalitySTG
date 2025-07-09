using UnityEngine;

public class GameoverTextHandler : MonoBehaviour
{
    public Start_Handler Pauser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pauser.gameovered){
            gameObject.SetActive(true);
        }
    }
}
