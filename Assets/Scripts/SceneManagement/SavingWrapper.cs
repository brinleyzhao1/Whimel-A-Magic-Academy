using System.Collections;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using UnityEngine;

namespace SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        [SerializeField] KeyCode saveKey = KeyCode.S;
        [SerializeField] KeyCode loadKey = KeyCode.L;
        [SerializeField] KeyCode deleteKey = KeyCode.Delete;
        const string DefaultSaveFile = "save";

        private void Awake()
        {
            // StartCoroutine(LoadLastScene()); //todo appearantly causing unity to crash!
        }

        private IEnumerator LoadLastScene() {
            yield return GetComponent<SavingSystem>().LoadLastScene(DefaultSaveFile);
        }

        private void Update() {
            if (Input.GetKeyDown(saveKey))
            {
                Save();
            }
            if (Input.GetKeyDown(loadKey))
            {
                Load();
            }
            if (Input.GetKeyDown(deleteKey))
            {
                Delete();
            }
        }

        public void Load()
        {
            StartCoroutine(GetComponent<SavingSystem>().LoadLastScene(DefaultSaveFile));
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(DefaultSaveFile);
            print("saved");
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(DefaultSaveFile);
        }
    }
}
