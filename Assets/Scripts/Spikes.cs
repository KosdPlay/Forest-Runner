using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
