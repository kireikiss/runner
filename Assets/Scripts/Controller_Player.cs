using UnityEngine;
using System.Collections;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;

    public GameObject prefabProyectil;
    public Transform puntoDisparo;
    public float fuerzaDisparo;

 



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
        Disparar();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }

       
    }

   

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }

    private void Disparar()
    {
        //al apretar el espacio 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // aparece el proyectil desdeel punto de disparo
            GameObject projectil = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.identity);

            // se aplica la fuerza de lanzamiento del proyectil
            Rigidbody rbProjectil = projectil.GetComponent<Rigidbody>();
            if (rbProjectil != null)
            {
                rbProjectil.AddForce(Vector2.right * fuerzaDisparo, ForceMode.Impulse);
            }
        }
    }

}
