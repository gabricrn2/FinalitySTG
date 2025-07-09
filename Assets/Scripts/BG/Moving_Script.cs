using UnityEngine;

public class Moving_Script : MonoBehaviour
{

    public float vel;
    public Vector3 endpoint;
    public Vector3 startpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = (endpoint == transform.localPosition) ? startpoint : Vector3.MoveTowards(transform.localPosition, endpoint, vel * Time.deltaTime);




    }
}
