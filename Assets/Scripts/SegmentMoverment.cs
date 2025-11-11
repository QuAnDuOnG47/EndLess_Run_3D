using System.Collections;
using UnityEngine;

public class SegmentMovement : MonoBehaviour
{
    public GameObject[] segmentPrefabs;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegments = false;



    void Update()
    {
        if (!creatingSegments)
        {
            creatingSegments = true;
            StartCoroutine(MoveSegment());
        }
        
    }

    IEnumerator MoveSegment()
    {
        Instantiate(segmentPrefabs[Random.Range(0, segmentPrefabs.Length)], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(5f);
        creatingSegments = false;
    
    }
}
