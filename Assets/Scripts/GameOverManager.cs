using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    //public Button playAgainButton;
    //public Button quitButton;
    

    // Start is called before the first frame update
    void Start()
    {
        //playAgainButton.onClick.AddListener(PlayAgainPressed);
        //quitButton.onClick.AddListener(QuitPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * 게임 재시작
     */
    public void PlayAgainPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    /**
     * 게임 종료
     */
    public void QuitPressed()
    {
        Application.Quit();
    }


}
