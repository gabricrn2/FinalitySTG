using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip stageMusic;
    public AudioClip bossMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayStageMusic(){
        if (stageMusic) GetComponent<AudioSource>().PlayOneShot(stageMusic);
    }
    public void PlayBossMusic(){
        if (stageMusic) GetComponent<AudioSource>().Stop();
        if (bossMusic) GetComponent<AudioSource>().PlayOneShot(bossMusic);
    }
    public void FinishMusic(){
        if (bossMusic) GetComponent<AudioSource>().Stop();
    }
}
