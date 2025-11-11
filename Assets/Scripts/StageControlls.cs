using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControlls : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadScene(2);  
    }
}
