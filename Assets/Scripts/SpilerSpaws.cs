using UnityEngine;

public class SpilerSpaws : MonoBehaviour
{
    public Transform player;
    public GameObject[] coinPrefabs;
    public GameObject[] trapPrefabs;
    public GameObject[] gemPrefabs;

    public float spawnZ = 30f; // spawn truoc player
    public float desSpawnZ = 10f; // xoa sau player
    public float spawnInterval = 1f; // thoi gian spawn
    public float laneOffSet = 2f; // khoang cach giua cac lane
    public float ySawn = 0.5f; // chieu cao spawn
    public float yTrap = 0f; // chieu cao spawn trap

    public int minCoinGroup = 3;
    public int maxCoinGroup = 5;
    public float safeDistanceFromTrap = 3f; // coin không spawn gần trap


    [Range(0f, 1f)] public float trapChance = 0.25f; // ti le spawn trap
    [Range(0f, 1f)] public float emptyChance = 0.1f; // ti le trong
    [Range(0f, 1f)] public float gemChance = 0.15f; // ti le spawn gem
    private float timer;
    // Khai báo góc xoay cố định (X=90)
    private readonly Quaternion coinRotation = Quaternion.Euler(90f, 0f, 0f);


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            TrySpawn();
        }
        // Xoa object sau khi di qua
        foreach (Transform child in transform)
        {
            if (child.position.z + desSpawnZ < player.position.z)
            {
                Destroy(child.gameObject);
            }
        }
    }
    
    void TrySpawn()
{
    if (Random.value < emptyChance)
        return; // không spawn gì cả

    int laneIndex = Random.Range(-1, 2); // -1, 0, 1
    float xPos = laneIndex * laneOffSet;
    float zPos = player.position.z + spawnZ;

    // Kiểm tra có trap nào gần đây không
    foreach (Transform child in transform)
    {
        if (child.CompareTag("Trap") && Mathf.Abs(child.position.z - zPos) < safeDistanceFromTrap)
            return; // bỏ qua vì quá gần trap
    }

    float roll = Random.value;
    GameObject toSpawn;

    if (roll < trapChance)
    {
        toSpawn = trapPrefabs[Random.Range(0, trapPrefabs.Length)];
        Vector3 trapPos = new Vector3(xPos, yTrap, zPos);
        GameObject trap = Instantiate(toSpawn, trapPos, Quaternion.identity, transform);
        trap.tag = "Trap"; // đảm bảo tag đúng để kiểm tra lần sau
    }
    else if (roll < trapChance + gemChance)
    {
        toSpawn = gemPrefabs[Random.Range(0, gemPrefabs.Length)];
        Vector3 gemPos = new Vector3(xPos, ySawn, zPos);
        Instantiate(toSpawn, gemPos, Quaternion.identity, transform);
    }
    else
    {
        // Spawn cụm coin (3–5 cái)
        int coinCount = Random.Range(minCoinGroup, maxCoinGroup + 1);
        toSpawn = coinPrefabs[Random.Range(0, coinPrefabs.Length)];

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 coinPos = new Vector3(xPos, ySawn, zPos + i * 1.5f); // mỗi coin cách nhau 1.5 đơn vị
            Instantiate(toSpawn, coinPos, coinRotation, transform);
        }
    }
}

    


}
