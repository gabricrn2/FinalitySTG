using UnityEngine;

public class player : MonoBehaviour
{
    public float NormalSpeed = 20.0f;
    public float FocusSpeed = 5.0f;
    //private CharacterController controller;
    //private bool isFocused = false;
    public Camera partialcamera;


    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //pula mas é tipo flappy bird. Deixarei assim, mais facil de testar. nota: estou usando um controle de console para testes.
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        var speed  = (Input.GetButton("Next")) ? FocusSpeed : NormalSpeed;


        transform.Translate(move * speed * Time.deltaTime);

        //halfworks: clamping na camera para não sair do viewport
        Vector3 viewPos = partialcamera.WorldToViewportPoint (this.transform.position);
        viewPos.x = Mathf.Clamp01 (viewPos.x);
        viewPos.y = Mathf.Clamp01 (viewPos.y);
        this.transform.position = partialcamera.ViewportToWorldPoint (viewPos);


    }
        

}
