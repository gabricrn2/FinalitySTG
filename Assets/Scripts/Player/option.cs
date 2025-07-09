using UnityEngine;

public class option : MonoBehaviour
{
    public float AngleOfset = 0.0f;
    private CharacterController controller;
    private bool isFocused = false;
    //private float distOffset = 0;
    public float normalDist = 6.0f;
    public float focusDist = 4.0f;
    public int parity = 0;
    public float unfY = 2.0f;
    public float unfX = 3.5f;
    float X = 0.0f;
    float Y = 0.0f;
    float radius = 0.0f;
    float Angle = 0.0f;
    float side = 1.0f;
    public float maxDistChange = 140.0f;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //pula mas é tipo flappy bird. Deixarei assim, mais facil de testar. nota: estou usando um controle de console para testes.

        // var dist  = (Input.GetButton("Debug Next")) ? focusDist : normalDist;
        if (!Input.GetButton("Next")){
            Y = -unfY;
            radius = normalDist;
            X = (parity%2 == 0) ? unfX : -unfX;
            Angle = (parity%2 == 0) ? AngleOfset + 1.570796f : AngleOfset;
            side = (parity%2 == 0) ? 1.0f : -1.0f;
        } else {
            radius = focusDist;
            X = 0.0f;
            Y = 0.0f;
            Angle = AngleOfset;
            side = 1.0f;
        }


        Vector3 move = new Vector3(Mathf.Cos(Time.time*5*side + Angle)*radius + X, Mathf.Sin(Time.time*5*side + Angle)*radius + Y, 0);
        //controller.Move(move);

        move = Vector3.MoveTowards(transform.localPosition, move, maxDistChange * Time.deltaTime);

        transform.localPosition = move;


    }
}
