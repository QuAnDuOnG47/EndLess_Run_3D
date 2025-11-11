using UnityEngine;

public class CoinCollect : MonoBehaviour
{
     [SerializeField] AudioSource coinEffect;
   
   private void Start()
    {
        coinEffect = GetComponent<AudioSource>();
    }
   void OnTriggerEnter(Collider other)
   {
        coinEffect.Play();
        MasterInfor.coinCount += 1;
        GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, coinEffect.clip.length);
   }
}
