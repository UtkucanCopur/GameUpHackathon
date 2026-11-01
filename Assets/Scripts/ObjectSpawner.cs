using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform pos1, pos2;


    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            Spawner();
            yield return new WaitForSeconds(2f);
        }
        
    }

    private void Spawner()
    {
        int rand = Random.Range(0, projectiles.Length);
        projectiles[rand].SetActive(true);
        projectiles[rand].transform.position = Vector3.Lerp(pos1.position, pos2.position, Random.Range(0f, 1f));
    }
}
