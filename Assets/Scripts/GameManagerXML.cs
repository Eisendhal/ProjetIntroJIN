using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class GameManagerXML : MonoBehaviour {

    private LevelData data;
    private Level currentLevel;

    public LevelData createdLevel;

    [SerializeField]
    public TextAsset XMLToLoad;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;

    private int score;

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

    // Use this for initialization
    void Awake () {
        Instantiate<GameObject>(player);
        score = 0;
        CreateLevelData();
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
        if (t == BaseAvatar.type.Player)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    void Start()
    {
        currentLevel.Initialize(XmlHelpers.DeserializeFromXML<LevelData>(XMLToLoad));
    }

    void CreateLevelData()
    {
        float cooldown = 0;
        EnemyData newEnemy = new EnemyData();
        for(int i = 0; i < 5; i++)
        {
            newEnemy.SpawnDate = cooldown + 40;
            cooldown += 1.5f;
            newEnemy.SpawnPosition = Random.Range(-4.4f, 4.4f);
            createdLevel.Enemies.Add(newEnemy);
        }
        XmlHelpers.SerializeToXML<LevelData>("./Assets/CreatedLevel.xml", createdLevel);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
