using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text _ghoulCount;
    public Text _surviveTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        string ghouls = GameManager.Instance.TotalGhouls.ToString();
        _ghoulCount.text = "you grew a horde of " + ghouls + " ghouls";
    }
}
