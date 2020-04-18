using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxTimeBetweenSpawns = 100;
    [SerializeField] private List<GameObject> dudesToSpawn;
    [SerializeField] private GameObject interestingRegion;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            GameObject enemy = GameObject.Instantiate(dudesToSpawn[Random.Range(0, dudesToSpawn.Count)], transform.position, Quaternion.identity);
            enemy.GetComponent<IEnemy>().SetRegion(interestingRegion);
            if(maxTimeBetweenSpawns > 22)
                maxTimeBetweenSpawns--;
            ResetTimer();
        }
        timer -= Time.deltaTime;
    }

    void ResetTimer()
    {
        timer = Random.Range(2 * (maxTimeBetweenSpawns / 3), maxTimeBetweenSpawns);
    }

}
