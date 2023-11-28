using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scripter : MonoBehaviour
{
    private void Awake()
    {
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text>();
        OnMoneyChange();
    }

    #region Botones

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(int nScene)
    {
        SceneManager.LoadScene(nScene);
    }

    #endregion

    #region Torre seleccionada

    public Toggle[] toggles;
    public static int? turretIndex;

    public void OnToggleValueChange()
    {
        turretIndex = null;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                turretIndex = i;
                break;
            }
        }
    }

    #endregion

    #region Money

    public static int money;
    public static Text moneyText;


    public static void OnMoneyChange()
    {
        moneyText.text = "$ " + money;
    }

    #endregion
}
