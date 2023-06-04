using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CollectDiamond : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI DiamondText;
    public PlayerController playerController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            AddDiamond();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Congrats!..");
            playerController.runningSpeed = 0;
            //Oyun sonuna gelince h�z 0 oluyor ve congrats yaz�s� consoleda g�r�n�r.

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touch Obstacle!..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Engele �arp�nca oyun yeniden y�kleniyor
        }
    }

    public void AddDiamond()
    {
        score++;
        DiamondText.text = "Score:" + score.ToString(); 
    }
}
