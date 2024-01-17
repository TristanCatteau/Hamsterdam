using System.Collections;
using UnityEngine;

public class zone : MonoBehaviour
{
    [SerializeField]
    private GameObject oeufPrefab;

    [SerializeField]
    private Vector3 zoneSize;
    public static float respawnTime =5.0f;

    void Start()
    {
        StartCoroutine(eggSpawn());
    }
    IEnumerator eggSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            CreateEgg();
        }
    }
    void CreateEgg()
    {
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
            Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
            Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
        );

        GameObject instantiated = Instantiate(oeufPrefab, randomSpawnPosition, Quaternion.identity);
        if(respawnTime > 1.0f)
        {
            respawnTime -= 0.25f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}