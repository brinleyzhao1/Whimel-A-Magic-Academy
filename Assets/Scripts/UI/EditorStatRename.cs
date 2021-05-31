using TMPro;
using UnityEngine;

namespace UI
{
  [ExecuteInEditMode]
  public class EditorStatRename : MonoBehaviour
  {
    // Start is called before the first frame update
    void Start()
    {
        UpdateLabel();
    }



    private void UpdateLabel()
    {

      // TextMeshProUGUI textMesh = transform.GetChild(0).GetComponent<TextMeshPro>();

      // TextMesh textMesh = GetComponentInChildren<TextMesh>();
      // string labelText =

      // textMesh.text = labelText;
      // print(transform.GetChild(0).GetComponent<TMP_Text>().text);
      gameObject.name = transform.GetChild(0).GetComponent<TMP_Text>().text;

    }
  }
}
