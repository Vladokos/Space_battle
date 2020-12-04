using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public bool gameStart;

    private float spawnPosX = 6f;
    private float spawnPosY = 18f;

    public List<GameObject> enemesPref;

    private PlayerControllers _playerControllers;
    void Start()
    {
        gameStart = true;
        InvokeRepeating("SpawnShip", 3f, 3f);
        _playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }
    //Спавн рандомных врагов  каждые 3 секунды в рандомном полезрения камеры
    void SpawnShip()
    {
        if (gameStart = true && _playerControllers._gameOver == false)
        {
            int randomShip = Random.Range(0, enemesPref.Count);
            Vector2 randomSpawn = new Vector2(Random.Range(-spawnPosX, spawnPosX), Random.Range(spawnPosY, spawnPosY + 7f));
            Instantiate(enemesPref[randomShip], randomSpawn, Quaternion.identity);
        }
    }
    // выполняет перезагрузку сцены
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
