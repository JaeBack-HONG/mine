using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    [Header("Button")]
    public Button InventoryBtn;

    [Header("InventoryUI")]
    public GameObject InventoryUI;

    [Header("ScriptData")]
    public PlayerMove playerXYdata;
    public PlayerTag playerTagData;
    public PlayerData playerData;
    
    [Header("PlayerData")]
    public Text moveData;
    public Text boosterData;
    public Text DiggingData;
    public Text OxygenData;
    public Text HP_Data;
    public Text Money_Data;

    public static int TotalMoney = 0;
    public static int playerMoney = 0;

    private void Start()
    {       
        if (InventoryBtn!=null)
        {
            InventoryBtn.onClick.AddListener(Inventory_UI);
        }
        playerXYdata = FindObjectOfType<PlayerMove>();
        playerTagData = FindObjectOfType<PlayerTag>();
        playerData = FindObjectOfType<PlayerData>();
    }
    private void Update()
    {
        
        PlayerDataText();
        InventroyKey();
        
    }
    private void InventroyKey()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory_UI();
        }
    }
    private void PlayerDataText()
    {

        float moveSpeed = playerXYdata.MoveSpeed;
        float YmoveSpeed = playerXYdata.YmoveSpeed;
        float DiggingSpeed = playerTagData.fristDelay;
        float OxygenReduction = playerData.Player_Oxygen;
        float Player_HP = playerData.Player_HP;

        moveData.text = moveSpeed.ToString("F2");
        boosterData.text = YmoveSpeed.ToString("F2");
        DiggingData.text = DiggingSpeed.ToString("F2")+"/s";
        OxygenData.text = OxygenReduction.ToString("")+ " / 500";
        HP_Data.text = Player_HP.ToString("")+" / 100";
        Money_Data.text = playerMoney.ToString("");
    }    
    void Inventory_UI()
    {
        
        InventoryUI.SetActive(!InventoryUI.activeSelf);
    }

}
