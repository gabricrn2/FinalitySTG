using UnityEngine;

public class BoatingScript : MonoBehaviour
{
    public bool isRotating = false;
    public float rotateBoatVel = 2.0f;
    private float rotateActualVel = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating){
            rotateActualVel = Mathf.Cos(Time.time/2) * rotateBoatVel;
        }
        else {
            rotateActualVel = rotateBoatVel;
        }
        //rotateActualVel = Mathf.Cos(Time.time/2) * rotateBoatVel;
        transform.Rotate(0,0, rotateActualVel * Time.deltaTime);
    }

    public void setRotating(float vel){
        isRotating = true;
        rotateBoatVel = vel;
    }

    public void setBoating(float vel){
        isRotating = false;
        rotateBoatVel = vel;
    }
}
