using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavScript : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;
    public float distancia /*distancia es distancia entre el jugador y el objetivo*/,distanciaDeseada;
    private Animator animator;

    public float estadoNiño = 100,velocidadBajadaDeEstado,velocidad0,velocidad1,velocidad2,velocidad3,velocidad4,velocidadActual;    
    void Start()
    {
         agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        velocidadActual = agente.speed; 
        distancia = Vector3.Distance(this.transform.position, objetivo.position);
         if (distancia < distanciaDeseada)
        {
            agente.speed = velocidad0;
           
           // agente.isStopped = true;
            agente.velocity = Vector3.zero;
            // Activa la animación de "iddle"
            animator.SetBool("Caminar", false);
        }
        else
        {
            agente.speed = 7;
            GestionarVelocidad();
           // agente.isStopped = false;

            // Activa la animación de "caminar"
            animator.SetBool("Caminar", true);

        }



                agente.destination = objetivo.position;        
                
                estadoNiño -= Time.deltaTime * velocidadBajadaDeEstado;
                if(estadoNiño > 100)
                {
                    estadoNiño = 100;
                }
                BarraUi.Barra = estadoNiño;

    }

    public void AumentarFelicidad(float cantidad)
    {

        estadoNiño += cantidad;
        Debug.Log("la felicidad del niño aumentó " + cantidad + " y ahora es de " + estadoNiño);
    }
    /*)
    public void estadoNiñoFun
    {

          BarraUi.Barra = estadoNiño;

    }*/
    public void GestionarVelocidad()
    {
        if(estadoNiño < 25)
        {
            agente.speed = velocidad1;
        }
       
        if(estadoNiño > 25 && estadoNiño < 50)
        {
            agente.speed = velocidad2;
        }
        if(estadoNiño > 50 && estadoNiño < 75)
        {
            agente.speed = velocidad3;
        }
        if(estadoNiño >75)
        {
            agente.speed = velocidad4;
        }
    }
}