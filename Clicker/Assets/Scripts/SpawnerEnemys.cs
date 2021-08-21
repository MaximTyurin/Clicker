using System.Collections;
using UnityEngine;

public class SpawnerEnemys : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyList;
    [SerializeField] private float _speedOnStart = 1f;
    [SerializeField] private float _maxTapToDeathOnStart = 1f;
    [SerializeField] private float _cooldownToSpawn = 5f;

    public delegate void EnemySpawn();
    public static event EnemySpawn OnSpawnedEvent;

    private void Start()
    {
        StartCoroutine(TimeToSpawn());
    }

    private void OnEnable()
    {
        GameManager.OnLosedEvent += StopCoroutines;
    }

    private void OnDisable()
    {
        GameManager.OnLosedEvent -= StopCoroutines;
    }

    public void CreateEnemy(GameObject[] enemys, float speed, float maxTap)
    {
        float xPos = Random.Range(1.1f, 9f);
        float yPos = 1.4f;
        float zPos = Random.Range(-6.5f, -0.5f);
        GameObject newEnemy = Instantiate(enemys[Random.Range(0, enemys.Length)], new Vector3(xPos, yPos, zPos), Quaternion.identity);
        newEnemy.GetComponent<TouchOnEnemy>().IncreaseMaxCountToDeath(maxTap);
        newEnemy.GetComponent<MoveController>().IncreaseSpeed(speed);
    }

    IEnumerator TimeToSpawn()
    {
        while(true)
        {
            CreateEnemy(_enemyList, _speedOnStart, _maxTapToDeathOnStart);
            OnSpawnedEvent?.Invoke();
            _speedOnStart += 0.2f;
            _maxTapToDeathOnStart += 1f;
            yield return new WaitForSeconds(_cooldownToSpawn);
        }
    }

    private void StopCoroutines()
    {
        StopAllCoroutines();
    }
}
