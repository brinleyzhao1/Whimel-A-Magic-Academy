using Player.Interaction;
using UnityEngine;

namespace UI
{
  public class SwitchTabs : MonoBehaviour
  {
    public void SwitchToInventoryTab()
    {

      GameAssets.StatsTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.InventoryTab.gameObject.SetActive(true);
    }

    public void SwitchToStatsTab()
    {
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.StatsTab.gameObject.SetActive(true);
    }
    public void SwitchToScheduleTab()
    {
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(true);
      GameAssets.StatsTab.gameObject.SetActive(false);
    }

    public void SwitchToHeartTab(){
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.StatsTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
    }
  }
}
