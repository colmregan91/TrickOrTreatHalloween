using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    public static string LeveltoLoad;

    public static string charSelScene = "CharacterSelectionScene";
    public static string PlayScene = "Neighbourhood lvl 1" ;

    public static bool inCharSelection { get { return LeveltoLoad == charSelScene; } }
    public static bool inPlay { get { return LeveltoLoad == PlayScene; } }

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

  public static void LoadScene()
    {
        string curscene = SceneManager.GetActiveScene().name;

        if (curscene == charSelScene)
        {
            LeveltoLoad = PlayScene;
        }
        else 
        {
            LeveltoLoad = charSelScene;
        }

    }
}
