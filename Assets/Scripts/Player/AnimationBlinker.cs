using UnityEngine;
using System.Collections;

public class AnimationBlinker : MonoBehaviour
{

    public float timedelta;
    public float blinktime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timedelta = timedelta + Time.deltaTime;
    }
    public void BlinkSprite(float time) {
        blinktime = time;
        StartCoroutine("doBlinkAnimation");
    }
    IEnumerator doBlinkAnimation() {
        timedelta = 0;
        while (timedelta < blinktime){
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(.1f);

            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<Renderer>().enabled = true;
    }




}
