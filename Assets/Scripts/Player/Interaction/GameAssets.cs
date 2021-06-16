using UnityEngine;

namespace Player.Interaction
{
  public class GameAssets : MonoBehaviour
  {

    // [Header("Core")]
    // [SerializeField] public GameObject setPlayer;
    // public static GameObject Player;


    [Header("UI: Tabs")]
    [SerializeField] public GameObject setSleepPanel;
    public static GameObject sleepPanel;

    [SerializeField] public GameObject setInventoryTab;
    public static GameObject InventoryTab;


    [SerializeField] public GameObject setStatsOranizer;
    public static GameObject StatsOrganizer;

    [SerializeField] public GameObject setScheduleTab;
    public static GameObject ScheduleTab;

    [Header("UI: Other")]
    [SerializeField] public GameObject setChestPanel;
    public static GameObject ChestPanel;

    [SerializeField] public GameObject setCraftingPanel;
    public static GameObject CraftingPanel;

    // [SerializeField] public GameObject setHeartTab;
    // public static GameObject HeartTab;

    [SerializeField] public GameObject setResultPanel;
    public static GameObject ResultPanel;

    [SerializeField] public GameObject setdialogueUi;
    public static GameObject DialogueUi;

    [Header("Shop UI")]
    [SerializeField] public GameObject setShopPanel;
    public static GameObject ShopPanel;

    [SerializeField] public GameObject setShopItem;
    public static GameObject ShopItem;

    [SerializeField] public GameObject setSellTray;
    public static GameObject SellTray;

    // [Header("Sound")]
    // [SerializeField] public GameObject setUiPaperSound;
    // public static GameObject UiPaperSound;

    private void Awake()
    {
      // Player = setPlayer;

      sleepPanel = setSleepPanel;
      InventoryTab = setInventoryTab;
      StatsOrganizer = setStatsOranizer;
      ScheduleTab = setScheduleTab;
      ChestPanel = setChestPanel;
      CraftingPanel = setCraftingPanel;

      ResultPanel = setResultPanel;
      DialogueUi = setdialogueUi;

      ShopPanel = setShopPanel;
      ShopItem = setShopItem;
      SellTray = setSellTray;

      // UiPaperSound = setUiPaperSound;

    }

    // private static GameAssets _i;

    // public static GameAssets instance
    // {
    //   get
    //   {
    //     if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
    //     return _i;
    //
    //   }
    //
    // }
  }
}
