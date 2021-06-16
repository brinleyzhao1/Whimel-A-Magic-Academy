using Player.Interaction;
using UnityEngine;

namespace UI
{
  public class SwitchTabs : MonoBehaviour
  {
    public void SwitchToInventoryTab()
    {

      GameAssets.StatsOrganizer.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.InventoryTab.gameObject.SetActive(true);
    }

    public void SwitchToStatsTab()
    {
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
      GameAssets.StatsOrganizer.gameObject.SetActive(true);
    }
    public void SwitchToScheduleTab()
    {
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(true);
      GameAssets.StatsOrganizer.gameObject.SetActive(false);
    }

    public void SwitchToHeartTab(){
      GameAssets.InventoryTab.gameObject.SetActive(false);
      GameAssets.StatsOrganizer.gameObject.SetActive(false);
      GameAssets.ScheduleTab.gameObject.SetActive(false);
    }
  }
}
