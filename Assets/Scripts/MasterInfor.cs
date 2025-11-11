using UnityEngine;

public class MasterInfor : MonoBehaviour
{
  public static int coinCount = 0;
  public static int gemCount = 0;
  [SerializeField] GameObject coinText;
  [SerializeField] GameObject gemText;
  [SerializeField] GameObject distanceText;
  public static int distanceRun;
  [SerializeField] int internalDistance;

    // Update is called once per frame
    void Update()
  {
    internalDistance = distanceRun;
    coinText.GetComponent<TMPro.TextMeshProUGUI>().text = "COINS: " + coinCount;
    gemText.GetComponent<TMPro.TextMeshProUGUI>().text = "GEMS: " + gemCount;
    distanceText.GetComponent<TMPro.TextMeshProUGUI>().text = "DISTANCE: " + internalDistance + " M";
    }
}
