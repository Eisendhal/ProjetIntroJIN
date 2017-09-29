using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;

    private int score;

    private int spawnCooldown = 40;

    public int SpawnCooldown
    {
        get
        {
            return this.spawnCooldown;
        }
        private set
        {
            this.spawnCooldown = value;
        }
    }

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
        }
    }

    void Awake()
    {
        Instantiate<GameObject>(player);
        this.Score = 0;
    }

    private void OnEnable()
    {
        PlayerAvatar.OnDeathEvent += PlayerDeathEventHandler;
        EnemyAvatar.OnDeathEvent += EnemyDeathEventHandler;
    }

    void EnemyDeathEventHandler(BaseAvatar.type t)
    {
        if (t == BaseAvatar.type.Enemy)
        {
            Score += 5;
        }
    }

    void PlayerDeathEventHandler(BaseAvatar.type t)
    {
        if(t == BaseAvatar.type.Player)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }
	
	// Update is called once per frame
	void Update () {
        SpawnCooldown--;
		if(spawnCooldown == 0)
        {
            GameObject newEnemy = Instantiate<GameObject>(enemy);
            newEnemy.GetComponent<Engines>().InitPosition(new Vector2(10, Random.Range(-4.4f, 4.4f)));
            SpawnCooldown = 40;
        }
	}
}
