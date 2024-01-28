using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{   private Rigidbody rb;
    private Vector2 inputMov,inputRot;
    [SerializeField] private float velocidadCaminata,velAgachado,velParado,sensibilidadMouse = 1,rotacionCamX;
    private  Transform cam;
    [SerializeField] private Vector3 escalaNormal,escalaAgachado;
    [SerializeField] private bool agachado;
    public NavScript navScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        rotacionCamX = cam.eulerAngles.x;
        escalaNormal = transform.localScale;
        escalaAgachado = new Vector3(1, 0.75f, 0);
    }

    // Update is called once per frame
    void Update()
    { if (navScript.boolperdi == false)
        {

        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");
        
        inputRot.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;

         //agachado = Input.GetKey(KeyCode.C);
         agachado = Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl);

        }
   }
    private void FixedUpdate()
    {
        if(agachado)
        {
            velocidadCaminata = velAgachado;

        }
        else
        {
            velocidadCaminata = velParado;

        }
        //forward es 0,0,1
        rb.velocity = transform.forward * velocidadCaminata * inputMov.y +  transform.right * velocidadCaminata * inputMov.x + new Vector3(0,rb.velocity.y,0 );
   
        transform.rotation *= Quaternion.Euler(0,inputRot.x,0);
        rotacionCamX -= inputRot.y;
        rotacionCamX = Mathf.Clamp(rotacionCamX,-50,50);
        cam.localRotation = Quaternion.Euler(rotacionCamX,0,0);


        Agacharse();
    }
    private void Agacharse()
    {
        //agacharse
        transform.localScale = Vector3.Lerp(transform.localScale, agachado ? escalaAgachado : escalaNormal,.1f );
    }

}
