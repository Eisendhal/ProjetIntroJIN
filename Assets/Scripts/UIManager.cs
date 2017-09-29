using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    public Slider HealthBar;
    [SerializeField]
    public Slider EnergyBar;
    private PlayerAvatar player;
    private int score;
    [SerializeField]
    private Text text;

    public GameManager gm;

    [SerializeField]
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
	void Start () {
        player = FindObjectOfType<PlayerAvatar>();
        HealthBar.value = player.MaxHealth;
        EnergyBar.value = player.Energy;
        gm = FindObjectOfType<GameManager>();
        Score = 0;
	}

    private void OnEnable()
    {
        PlayerAvatar.OnDeathEvent += PlayerDeathEventHandler;
        EnemyAvatar.OnDeathEvent += EnemyDeathEventHandler;
    }

    private void PlayerDeathEventHandler(BaseAvatar.type t)
    {

    }

    private void EnemyDeathEventHandler(BaseAvatar.type t)
    {
        text.text = "" + this.Score;
    }


	
	// Update is called once per frame
	void Update () {
        HealthBar.value = player.Health;
        EnergyBar.value = player.Energy;
        Score = gm.Score;
    }
}
