using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                GameManager.instance.WinGame();
            }
            else
            {
                GameManager.instance.LoadNextLevel();
            }

        }
    }
}
