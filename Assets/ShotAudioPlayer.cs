using UnityEngine;

public class ShotAudioPlayer : MonoBehaviour
{
    public AudioClip myClip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShot(){
        GetComponent<AudioSource>().PlayOneShot(myClip);
    }

}
