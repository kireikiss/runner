using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString("F0");
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString("F0") + "m";
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            //Se agrega "F0" para redondear los decimales
            distanceText.text = distance.ToString("F0");
        }
    }
}
