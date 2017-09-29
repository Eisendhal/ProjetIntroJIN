using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    private LevelData definition;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;

    public LevelData Definition
    {
        get; private set;
    }

	// Use this for initialization
	public void Initialize (LevelData data) {
        Definition = data;
	}
	
	// Update is called once per frame
	void Update () {
        if(Definition.Enemies.Count == 0)
        {
            SceneManager.LoadScene("Menu");
        }
		if(Time.time >= Definition.Enemies[Definition.Enemies.Count - 1].SpawnDate)
        {
            GameObject newEnemy = Instantiate<GameObject>(enemy);
            newEnemy.GetComponent<Engines>().InitPosition(new Vector2(10, Definition.Enemies[Definition.Enemies.Count -1].SpawnPosition));
            Definition.Enemies.RemoveAt(Definition.Enemies.Count - 1);
        }
	}
}
