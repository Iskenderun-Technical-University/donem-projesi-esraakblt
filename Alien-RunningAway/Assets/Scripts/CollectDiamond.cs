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
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;



    private void Start()
    {
          PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

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
            //Oyun sonuna gelince hýz 0 oluyor ve congrats yazýsý consoleda görünür.
            transform.Rotate(transform.rotation.x,180,transform.rotation.z,Space.Self);
            EndPanel.SetActive(true);
            //karakter bize dönecek 
            if (score >= maxScore)
            {
               // Debug.Log("You Win!..");
                PlayerAnim.SetBool("Win",true);
            }
            else
            {
               // Debug.Log("You Lose!..");
                PlayerAnim.SetBool("Lose",true);
            }

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touch Obstacle!..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Engele çarpýnca oyun yeniden yükleniyor
        }
    }

    public void AddDiamond()
    {
        score++;
        DiamondText.text = "Score:" + score.ToString(); 
    }
}
