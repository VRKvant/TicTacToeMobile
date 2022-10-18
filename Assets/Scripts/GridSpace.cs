using UnityEngine;
using UnityEngine.UI;



public class GridSpace : MonoBehaviour
{
    private GameController _myController;
    public Button myButton;
    public Text buttonText;
    public string playerSide;


    void Start()
    {
        myButton = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();

        
    }

    public void SetSpace()
    {
        buttonText.text = _myController.GetPlayerSide();
        myButton.interactable = false;
        _myController.EndTurn();
    }

    public void SetController(GameController controller)
    {
        _myController = controller;
    }
}
