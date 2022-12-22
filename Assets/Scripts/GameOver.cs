using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameManager _gameManager;

    public Text _ghoulCount;
    public Text _surviveTime;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        string ghouls = _gameManager.GetTotalGhouls();
        string surviveTime = _gameManager.GetSurviveTime();

        _ghoulCount.text = "you grew a horde of " + ghouls + " ghouls";
        _surviveTime.text = "";
    }
}
