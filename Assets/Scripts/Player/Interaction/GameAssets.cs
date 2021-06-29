using GameDev.tv_Assets.Scripts.Inventories;
using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class GameAssets : MonoBehaviour
  {
    [Header("Core")]
    // [SerializeField] public GameObject setPlayer;
    // public static GameObject Player;

    [SerializeField]
    private Inventory setPlayerInventory;
    public static Inventory PlayerInventory;

    [Header("UI: Tabs")] [SerializeField] public GameObject setInventoryTab;
    public static GameObject InventoryTab;

    [SerializeField] public GameObject setStatsTab;
    public static GameObject StatsTab;

    [SerializeField] public GameObject setStatsOrganizer;
    public static GameObject StatsOrganizer;

    [SerializeField] public GameObject setSkillsTab;
    public static GameObject SkillsTab;

    [SerializeField] public GameObject setScheduleTab;
    public static GameObject ScheduleTab;

    [Header("UI: Alchemy")]
    [SerializeField] public GameObject setRecipeItemUiPrefab;
    public static GameObject RecipeItemUi;

    [SerializeField] public GameObject setRecipeBookPanel;
    public static GameObject RecipeBookPanel;

    [SerializeField] public BrewingUi setBrewPanel;
    public static BrewingUi BrewPanel;

    [Header("UI: Library")]
    [SerializeField] public BookShelfMenu setBookShelfPanel;
    public static BookShelfMenu BookShelfPanel;



    #region UI: Other

    [Header("UI: Other")]
    [SerializeField] public SetMessage setMessagePanel;
    public static SetMessage MessagePanel;

    [SerializeField] public GameObject setSleepPanel;
    public static GameObject SleepPanel;

    [SerializeField] public GameObject setChestPanel;
    public static GameObject ChestPanel;

    [SerializeField] public GameObject setPotionPanel;
    public static GameObject PotionPanel;

    [SerializeField] public GameObject setCraftingPanel;
    public static GameObject CraftingPanel;

    // [SerializeField] public GameObject setHeartTab;
    // public static GameObject HeartTab;

    [SerializeField] public GameObject setResultPanel;
    public static GameObject ResultPanel;

    [SerializeField] public GameObject setDialogueUi;
    public static GameObject DialogueUi;

    [Header("Shop UI")] [SerializeField] public GameObject setShopPanel;
    public static GameObject ShopPanel;

    [SerializeField] public GameObject setShopItem;
    public static GameObject ShopItem;

    [SerializeField] public GameObject setSellTray;
    public static GameObject SellTray;

    #endregion


    // [Header("Sound")]
    // [SerializeField] public GameObject setUiPaperSound;
    // public static GameObject UiPaperSound;

    private void Awake()
    {
      // Player = setPlayer;
      BookShelfPanel = setBookShelfPanel;
      MessagePanel = setMessagePanel;
      PlayerInventory = setPlayerInventory;
      BrewPanel = setBrewPanel;
      RecipeBookPanel = setRecipeBookPanel;
      RecipeItemUi = setRecipeItemUiPrefab;
      SleepPanel = setSleepPanel;
      InventoryTab = setInventoryTab;
      StatsOrganizer = setStatsOrganizer;
      ScheduleTab = setScheduleTab;
      ChestPanel = setChestPanel;
      CraftingPanel = setCraftingPanel;
      SkillsTab = setSkillsTab;
      ResultPanel = setResultPanel;
      DialogueUi = setDialogueUi;
      StatsTab = setStatsTab;
      ShopPanel = setShopPanel;
      ShopItem = setShopItem;
      SellTray = setSellTray;
      PotionPanel = setPotionPanel;
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
