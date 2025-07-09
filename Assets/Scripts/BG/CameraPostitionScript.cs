using UnityEngine;

public class CameraPostitionScript : MonoBehaviour
{
    public Camera mycam;

    public Vector3 camerafuturetransform;
    public Quaternion camerafuturelook;
    public float camerafuturefov;

    public float rotationconstant;
    public float movementconstant;
    public float fovconstant;
    public float fovtime = 0.5f;

    public BoatingScript boating;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     camerafuturetransform = transform.localPosition;
     camerafuturelook = transform.rotation;
     camerafuturefov = mycam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (camerafuturelook != transform.rotation) RotateCamera();
        if (camerafuturetransform != transform.localPosition) MoveCamera();
        if (mycam.fieldOfView != fovconstant) ChangeFov();
    }

    void RotateCamera(){
        transform.rotation = Quaternion.RotateTowards(transform.rotation, camerafuturelook, rotationconstant * Time.deltaTime);
    }
    void MoveCamera(){
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, camerafuturetransform, movementconstant * Time.deltaTime);
    }
    void ChangeFov(){
        mycam.fieldOfView = Mathf.SmoothDamp(mycam.fieldOfView, camerafuturefov, ref fovconstant, fovtime);
    }


    public void ChangePosition1() {
        camerafuturetransform = new Vector3(45,0, 15);
        camerafuturelook = Quaternion.Euler(90, 0, 0);
        camerafuturefov = 120.0f;
        rotationconstant = 40.0f;
        boating.SendMessage("setRotating", 10.0f, SendMessageOptions.DontRequireReceiver);
    }
    public void ChangePosition2() {
        camerafuturetransform = new Vector3(45,0, 15);
        camerafuturelook = Quaternion.Euler(90, 45, 0);
        camerafuturefov = 90.0f;
        rotationconstant = 40.0f;
        boating.SendMessage("setRotating", 7.0f, SendMessageOptions.DontRequireReceiver);
    }
    public void ChangePosition3() {
        camerafuturetransform = new Vector3(45,0, 15);
        camerafuturelook = Quaternion.Euler(90, 180, 0);
        camerafuturefov = 60.0f;
        rotationconstant = 40.0f;
        boating.SendMessage("setBoating", 18.0f, SendMessageOptions.DontRequireReceiver);
    }

    public void ChangePositio4() {
        camerafuturetransform = new Vector3(45,0, 15);
        camerafuturelook = Quaternion.Euler(30, 0, 0);
        camerafuturefov = 120.0f;
        rotationconstant = 40.0f;
        boating.SendMessage("setRotating", 18.0f, SendMessageOptions.DontRequireReceiver);
    }

}
