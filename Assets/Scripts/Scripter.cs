using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scripter : MonoBehaviour
{
    private void Awake()
    {
        winPanel = GameObject.FindGameObjectWithTag("Win Panel");
        mainPanel = GameObject.FindGameObjectWithTag("Main Panel");
        playerHealthStatic = playerHealth;
        maxPlayerHealthStatic = playerHealth;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text>();
        pricesStatic = prices;
        money = startMoney;
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].transform.GetChild(1).GetComponent<Text>().text = "$ " + pricesStatic[i];
        }
        OnMoneyChange();
    }

    #region Botones

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

    public int[] prices;
    [SerializeField] private int startMoney;
    public static Text moneyText;
    public static int money;
    public static int[] pricesStatic;

    public static void OnMoneyChange()
    {
        moneyText.text = "$ " + money;
    }

    #endregion

    #region Player Health

    public int playerHealth;
    public static int playerHealthStatic, maxPlayerHealthStatic;
    public static Image healthBar;

    static GameObject winPanel, mainPanel;

    public static void PlayerReceiveDamage(int damagePoints)
    {
        playerHealthStatic -= damagePoints;
        OnHealthChange();

        if (playerHealthStatic <= 0)
        {
            Debug.Log("Te moristes ijo");
            //Game Over
            mainPanel.SetActive(false);
            winPanel.SetActive(true);
        }
    }

    private static void OnHealthChange()
    {
        healthBar.fillAmount = (float)playerHealthStatic / maxPlayerHealthStatic;
    }

    #endregion
}
