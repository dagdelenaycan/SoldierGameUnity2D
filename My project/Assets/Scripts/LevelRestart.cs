using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelRestart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("target"))
        {//karakter etiketi target

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
