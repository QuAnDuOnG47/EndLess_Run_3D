using UnityEngine;
using TMPro;
using System.Collections;

public class Loading : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
   public float loadingDuration = 0.5f; // Thời gian
    void Start()
    {
        StartCoroutine(LoadingAnimation());
    }

    IEnumerator LoadingAnimation()
    {
        string baseText = "LOADING";
        int dotCount = 0;

        while (true)
        {
            dotCount = (dotCount + 1) % 5; // 0..4
            loadingText.text = baseText + new string('.', dotCount);
            yield return new WaitForSeconds(loadingDuration);
        }
    }
}