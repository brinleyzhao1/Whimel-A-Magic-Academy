using Player.Interaction;
using UnityEngine;

namespace UI_Scripts
{
  public class SwitchTabs : MonoBehaviour
  {
    public void SwitchToInventoryTab()
    {

      GameAssets.StatsTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.SkillsTab.gameObject.SetActive(false);
      GameAssets.InventoryTab.gameObject.SetActive(true);
    }

    public void SwitchToStatsTab()
    {
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.StatsTab.gameObject.SetActive(true);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.SkillsTab.gameObject.SetActive(false);
      // GameAssets.StatsTab.gameObject.SetActive(true);
    }

    public void SwitchToSkillsTab()
    {

      GameAssets.StatsTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.SkillsTab.gameObject.SetActive(true);
      GameAssets.InventoryTab.gameObject.SetActive(false);
    }
    // public void SwitchToScheduleTab()
    // {
    //   GameAssets.InventoryTab.gameObject.SetActive(false);
    //   GameAssets.ScheduleTab.gameObject.SetActive(true);
    //   GameAssets.SkillsTab.gameObject.SetActive(false);
    //   GameAssets.StatsOrganizer.gameObject.SetActive(false);
    // }

    // public void SwitchToHeartTab(){
    //   GameAssets.InventoryTab.gameObject.SetActive(false);
    //   GameAssets.StatsTab.gameObject.SetActive(false);
    //   GameAssets.SkillsTab.gameObject.SetActive(false);
    //   GameAssets.ScheduleTab.gameObject.SetActive(false);
    // }
  }
}
