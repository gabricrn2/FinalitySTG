using UnityEngine;

public class PauseHUDHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Text;
    public Start_Handler Pauser;
    public bool textshown;

    // Update is called once per frame
    void Update()
    {
        if (Pauser.paused && !Pauser.gameovered && !textshown){
            Text.SetActive(true);
            textshown = true;
        }
        else if (!Pauser.paused && textshown){
            Text.SetActive(false);
            textshown = false;
        }

    }
}
