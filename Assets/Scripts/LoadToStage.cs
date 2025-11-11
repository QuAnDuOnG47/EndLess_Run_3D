using System.Collections;
using UnityEngine;

public class LoadToStage : MonoBehaviour
{
   [SerializeField] GameObject fadeOut;
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
