using GameDev.tv_Assets.Scripts.Inventories;
using UI;
using UI_Scripts;
using UnityEngine;

namespace Player.Interaction
{
  public class GameAssets : MonoBehaviour
  {
    [Header("Core")] [SerializeField] public GameObject setPlayer;
    public static GameObject Player;

    // [SerializeField] public GameObject setPlayer;
    // public static GameObject Player;

    [SerializeField] private Inventory setPlayerInventory;

    public static Inventory PlayerInventory;

    #region Tabs

    [Header("UI: Tabs")]
    [SerializeField] public GameObject setTabsContainer;
    public static GameObject TabsContainer;

    [SerializeField] public GameObject setInventoryTab;
    public static GameObject InventoryTab;

    [SerializeField] public GameObject setStatsTab;
    public static GameObject StatsTab;

    [SerializeField] public GameObject setStatsOrganizer;
    public static GameObject StatsOrganizer;

    [SerializeField] public GameObject setSkillsTab;
    public static GameObject SkillsTab;

    [SerializeField] public GameObject setScheduleTab;
    public static GameObject ScheduleTab;

    #endregion

    #region Alchemy

    [Header("UI: Alchemy")] [SerializeField]
    public GameObject setRecipeItemUiPrefab;

    public static GameObject RecipeItemUi;

    [SerializeField] public GameObject setRecipeBookPanel;
    public static GameObject RecipeBookPanel;

    [SerializeField] public BrewingUi setBrewPanel;
    public static BrewingUi BrewPanel;

    [SerializeField] public GameObject setPotionPanel;
    public static GameObject PotionPanel;

    #endregion


    [Header("UI: Library")] [SerializeField]
    public BookShelfMenu setBookShelfPanel;

    public static BookShelfMenu BookShelfPanel;

    [SerializeField] public GameObject setBookOnShelfPrefab;
    public static GameObject BookOnShelfPrefab;

    [SerializeField] public GameObject setBookDetailPanel;
    public static GameObject BookDetailPanel;

    #region UI: Other

    [Header("UI: Other")]

    [SerializeField] public GameObject setCenterCross;
    public static GameObject CenterCross ;

    [SerializeField] public GameObject setInteractHint;
    public static GameObject InteractHint ;

    [SerializeField] public SetMessage setMessagePanel;
    public static SetMessage MessagePanel;

    [SerializeField] public GameObject setSleepPanel;
    public static GameObject SleepPanel;

    [SerializeField] public GameObject setChestPanel;
    public static GameObject ChestPanel;

    // [SerializeField] public GameObject setHeartTab;
    // public static GameObject HeartTab;
    [SerializeField] public GameObject setPausePanel;
    public static GameObject PausePanel;

    [SerializeField] public GameObject setTutorialPanel;
    public static GameObject TutorialPanel;

    [SerializeField] public GameObject setResultPanel;
    public static GameObject ResultPanel;

    [SerializeField] public GameObject setDialogueUi;
    public static GameObject DialogueUi;

    #endregion



    [Header("Dining UI")] [SerializeField] public GameObject setDiningPanel;
    public static GameObject DiningPanel;

    [SerializeField] public GameObject setDiningItem;
    public static GameObject DiningItem;


    [Header("Shop UI")] [SerializeField] public GameObject setShopPanel;
    public static GameObject ShopPanel;

    [SerializeField] public GameObject setShopItem;
    public static GameObject ShopItem;

    [SerializeField] public GameObject setSellTray;
    public static GameObject SellTray;





    private void Awake()
    {
      TutorialPanel = setTutorialPanel;
      PausePanel = setPausePanel;
      TabsContainer = setTabsContainer;
      CenterCross = setCenterCross;
      InteractHint = setInteractHint;
      Player = setPlayer;
      DiningPanel = setDiningPanel;
      DiningItem = setDiningItem;
      BookDetailPanel = setBookDetailPanel;
      BookOnShelfPrefab = setBookOnShelfPrefab;
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
