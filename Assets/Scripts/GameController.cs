using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Player playerX;
    public Player playerO;

    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;


    public GameObject gameOverpanel;
    public Text gameOverText;

    public Text[] buttonlList;

    private string _playerSide;
    private int _moveCount;


    private void Awake()
    {
        _playerSide = "X";
        SetPlayerColors(playerX, playerO);
        _moveCount = 0;
        gameOverpanel.SetActive(false);
        SetControlletOnButtons();
    }

    public void SetControlletOnButtons()
    {
        for (int i = 0; i < buttonlList.Length; i++)
        {
            buttonlList[i].GetComponentInParent<GridSpace>().SetController(this);
        }
    }
    public string GetPlayerSide()
    {
        return _playerSide;
    }
    public void EndTurn()
    {
        _moveCount++;
        //top
      if (buttonlList[0].text == _playerSide&& buttonlList[1].text == _playerSide && buttonlList[2].text == _playerSide)
        {
            GameOver();
        }
       else if (buttonlList[3].text == _playerSide && buttonlList[4].text == _playerSide && buttonlList[5].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[6].text == _playerSide&& buttonlList[7].text == _playerSide && buttonlList[8].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[0].text == _playerSide&& buttonlList[3].text == _playerSide && buttonlList[6].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[1].text == _playerSide && buttonlList[4].text == _playerSide && buttonlList[7].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[2].text == _playerSide && buttonlList[5].text == _playerSide && buttonlList[8].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[0].text == _playerSide && buttonlList[4].text == _playerSide && buttonlList[8].text == _playerSide)
        {
            GameOver();
        }
        else if(buttonlList[2].text == _playerSide && buttonlList[4].text == _playerSide && buttonlList[6].text == _playerSide)
        {
            GameOver();
        }

        else if(_moveCount>=9)
        {
            SetGameOverText("it's a Draw");
        }
        else
        {
            ChangeSides();
        }
    }
    public void GameOver()
    {
        for (int i = 0; i < buttonlList.Length; i++)
        {
            buttonlList[i].GetComponentInParent<Button>().interactable = false;
        }

        SetGameOverText(_playerSide + " Wins");
    }
    public void ChangeSides()
    {
        _playerSide = (_playerSide == "X") ? "O" : "X";
        if (_playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);

        }
    }

    void SetGameOverText (string myText)
    {
        gameOverText.text = myText;
        gameOverpanel.SetActive(true);
    }
    public void RestartGame()
    {
        _playerSide = "X";
        _moveCount = 0;
        gameOverpanel.SetActive(false);
        for (int i = 0; i < buttonlList.Length; i++)
        {
            buttonlList[i].text = "";
        }
        SetPlayerColors(playerX, playerO);
        SetBoardInteractable(true);
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonlList.Length; i++)
        {
            buttonlList[i].GetComponentInParent<Button>().interactable = toggle;
        }

    }

    void SetPlayerColors (Player newPlayer,Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;

        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;

    }

}
