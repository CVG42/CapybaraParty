using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaculos;

    [Header("Tiempo maximo")] 
    [SerializeField]
    public float minTime = 2.5f;

    public float maxTime = 3.8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstaculos.Length);
            float randomTime = Random.Range(minTime, maxTime);
            Instantiate(obstaculos[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
