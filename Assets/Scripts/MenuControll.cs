using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    [SerializeField] GameObject MainFadeOut;
    [SerializeField] AudioSource buttomEffect;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOutStart;

    public void Awake()
    {
        menuPanel.SetActive(true);
        Canvas.ForceUpdateCanvases(); // ép Unity render 1 frame ẩn
        menuPanel.SetActive(false);

        StartCoroutine(AnimCam());
    }
    public void PlayGame()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        buttomEffect.Play();
        MainFadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
    
    IEnumerator AnimCam()
    {

        yield return new WaitForSeconds(1.5f);
        fadeOutStart.SetActive(false);
        menuPanel.SetActive(true);
    }
}
