using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //un if para verificar lo que sucede en ese estado del juego
        if (Controller_Hud.gameOver == false)
        {
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
            if (transform.localPosition.x < -20)
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
        else
        {
            //se detiene el parallax al perder
            parallaxEffect = 0;
        }
    }
}
