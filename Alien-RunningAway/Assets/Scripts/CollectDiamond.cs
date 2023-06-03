using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollectDiamond : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI DiamondText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            AddDiamond();
            Destroy(other.gameObject);
        }
    }


    public void AddDiamond()
    {
        score++;
        DiamondText.text = "Score:" + score.ToString(); 
    }
}
