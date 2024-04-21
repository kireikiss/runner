using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;
    private int contadorDisparos = 0;
    public bool esDestruible = false;
    public float velocidadHélice;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //el enemigo se mueve hacia la izquierda y se verifica si se pasa del limite
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
        //permite la rotacion en el eje z
        transform.Rotate(Vector3.forward * velocidadHélice * Time.deltaTime);
        OutOfBounds();
    }

    public void OutOfBounds()
    {
        //si pasa del limite se destruye
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }

    public void recibirDisparo()
    {
        //si el enemigo se puede destruir al recibir 3 disparos se destruye
        if (esDestruible == true) { 
        contadorDisparos++;
        if (contadorDisparos >= 3)
        {
            DestruirEnemigo();
        }
        }
    }
    private void DestruirEnemigo()
    {
        Destroy(this.gameObject);
    }
}
