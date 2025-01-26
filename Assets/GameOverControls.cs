using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControls : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene(1);
        Physics2D.IgnoreLayerCollision(6, 6, false);
    }
    public void MainMenu()
    {
        Physics2D.IgnoreLayerCollision(6, 6, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
