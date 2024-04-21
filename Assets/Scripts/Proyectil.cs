using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida;
     private Rigidbody rb;
    private void Start()
    {
        //esto es para que el proyectil no quede dando vueltas, o sea q se destruya despues del tiempo especificado
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, tiempoVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //cuando colisiona se busca si existe en este el componente controller enemy
        Controller_Enemy enemy = collision.gameObject.GetComponent<Controller_Enemy>();

        //si tiene el componente, el enemigo va arecibir el disparo y despues el proyectil desaparece
        if (enemy != null )
        {
            enemy.recibirDisparo();
            Destroy(this.gameObject);
        }
    }
}