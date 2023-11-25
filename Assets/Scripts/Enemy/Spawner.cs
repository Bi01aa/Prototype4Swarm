using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    private int currentWave;

    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<EnemyHealth> enemyList;

    public GameManagerScript GameManagerScript;
    

 

   

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
        
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemiesAreDead())
                return;
            else
                CompleteWave();

            
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
            
        }
        else
            waveCountdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }
        

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

       GameObject newEnemy = Instantiate(enemy, randomSpawner.position, randomSpawner.rotation);
       EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();

        enemyList.Add(enemyHealth);
    }

   private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(EnemyHealth enemy in enemyList)
        {
            if (enemy.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }

    private void CompleteWave()
    {
        Debug.Log("WAVE COMPLETED ");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("COMPLETED ALL WAVES");
            GameManagerScript.gameFinished();
            
            
        }
        else
        {
            currentWave++;
        }

        

       
    }















}
