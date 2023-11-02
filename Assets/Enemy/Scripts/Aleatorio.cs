using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Aleatorio : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private float tempoEnemys;
    private float NextEnemyTime;

    // Start is called before the first frame update
    void Start()
    {
        maxX = points.Max(
            p => p.position.x
        );
        minX = points.Min(
            p => p.position.x
        );
        maxY = points.Max(
            p => p.position.y
        );
        minY = points.Min(
            p => p.position.y
        );
    }

    // Update is called once per frame
    void Update()
    {
        NextEnemyTime += Time.deltaTime;

        if(NextEnemyTime >= tempoEnemys){
            NextEnemyTime = 0;
            AddEnemy();
        }
    }

    private void AddEnemy(){
        int index = Random.Range(0, enemys.Length);
        Vector2 PositionA = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemys[index], PositionA, Quaternion.identity);
    }
}
