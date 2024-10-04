using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Security.Cryptography;
//using System.Numerics;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer = 10f;
    public float minEdgeDistance = 1f;
    public float normalOffset = 0.1f;
    int spawnTry = 100;
    public MRUKAnchor.SceneLabels sceneLabel;
    public GameObject[] enemyPrefab;
    public GameObject player;
    private float timer;


    //private bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!MRUK.Instance && MRUK.Instance.IsInitialized)
        {
            Debug.Log("MRUK is not initialized");
            return;
        }

        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            SpawnEnemy();
            timer = 0;
        }

        /*if (!hasSpawned)
        {
            SpawnEnemy();
            hasSpawned = true;
        }*/
    }

    /*public void SpawnEnemy(){
        Vector3 randomPositionNormalOffset = new Vector3(0, 1, 1f);
        GameObject selectedEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject newPrefab = Instantiate(selectedEnemyPrefab, randomPositionNormalOffset, Quaternion.identity);
        newPrefab.GetComponent<EnemyBehavior>().player = player;
    }*/

    public void SpawnEnemy()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        int tryCount = 0;

        while(tryCount < spawnTry){
            bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(sceneLabel), out Vector3 pos, out Vector3 norm);
            if (hasFoundPosition)
            {
                Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
                GameObject selectedEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
                //selectedEnemyPrefab.GetComponent<EnemyBehavior>().player = player;
                GameObject newPrefab = Instantiate(selectedEnemyPrefab, randomPositionNormalOffset, Quaternion.identity);
                newPrefab.GetComponent<EnemyBehavior>().player = player;
                return;
            }
            else 
            {
                tryCount++;
            }
        }
        
    }
}
