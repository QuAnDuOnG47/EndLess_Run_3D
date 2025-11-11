using UnityEditor.Animations;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
     [SerializeField] AudioSource gemEffect;

    void Start()
    {
            gemEffect = GetComponent<AudioSource>();
    }
     void OnTriggerEnter(Collider other)
        {
          gemEffect.Play();
          MasterInfor.gemCount += 1;
          GetComponentInChildren<MeshRenderer>().enabled = false;
          GetComponent<Collider>().enabled = false;
          Destroy(gameObject, gemEffect.clip.length);
        }
   
   
}
