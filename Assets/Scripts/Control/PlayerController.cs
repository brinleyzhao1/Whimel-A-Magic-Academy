// using System;
// using GameDev.tv_Assets.Scripts.Inventories;
// using GameDevTV.Inventories;
// using InventoryExample.Control;
// using Player.Movement;
// using UnityEngine;
// using UnityEngine.AI;
// using UnityEngine.EventSystems;
//
// namespace Control
// {
//     public class PlayerController : MonoBehaviour
//     {
//         [System.Serializable]
//         public struct CursorMapping
//         {
//             public CursorType type;
//             public Texture2D texture;
//             public Vector2 hotspot;
//         }
//
//         [SerializeField] CursorMapping[] cursorMappings = null;
//         [SerializeField] float maxNavMeshProjectionDistance = 1f;
//         [SerializeField] float raycastRadius = 1f;
//
//         bool movementStarted = false;
//
//         private void Update()
//         {
//             CheckSpecialAbilityKeys();
//             if (Input.GetMouseButtonUp(0))
//             {
//                 movementStarted = false;
//             }
//
//             if (InteractWithUI()) return;
//             if (InteractWithComponent()) return;
//             if (InteractWithMovement()) return;
//
//             SetCentralCursor(CursorType.None);
//         }
//
//         private void CheckSpecialAbilityKeys()
//         {
//             var actionStore = GetComponent<ActionStore>();
//             if (Input.GetKeyDown(KeyCode.Alpha1))
//             {
//               print("hitting 1");
//                 actionStore.ActionStoreUse(0, gameObject);
//             }
//             if (Input.GetKeyDown(KeyCode.Alpha2))
//             {
//                 actionStore.ActionStoreUse(1, gameObject);
//             }
//             if (Input.GetKeyDown(KeyCode.Alpha3))
//             {
//                 actionStore.ActionStoreUse(2, gameObject);
//             }
//             if (Input.GetKeyDown(KeyCode.Alpha4))
//             {
//                 actionStore.ActionStoreUse(3, gameObject);
//             }
//             if (Input.GetKeyDown(KeyCode.Alpha5))
//             {
//                 actionStore.ActionStoreUse(4, gameObject);
//             }
//             if (Input.GetKeyDown(KeyCode.Alpha6))
//             {
//                 actionStore.ActionStoreUse(5, gameObject);
//             }
//         }
//
//         private bool InteractWithUI()
//         {
//             if (EventSystem.current.IsPointerOverGameObject())
//             {
//                 SetCentralCursor(CursorType.UI);
//                 return true;
//             }
//             return false;
//         }
//
//         private bool InteractWithComponent()
//         {
//             RaycastHit[] hits = RaycastAllSorted();
//             foreach (RaycastHit hit in hits)
//             {
//                 IRaycastable[] raycastables = hit.transform.GetComponents<IRaycastable>();
//                 foreach (IRaycastable raycastable in raycastables)
//                 {
//                     if (raycastable.HandleRaycast(this))
//                     {
//                         SetCentralCursor(raycastable.GetCursorType());
//                         return true;
//                     }
//                 }
//             }
//             return false;
//         }
//
//         RaycastHit[] RaycastAllSorted()
//         {
//             RaycastHit[] hits = Physics.SphereCastAll(GetMouseRay(), raycastRadius);
//             float[] distances = new float[hits.Length];
//             for (int i = 0; i < hits.Length; i++)
//             {
//                 distances[i] = hits[i].distance;
//             }
//             Array.Sort(distances, hits);
//             return hits;
//         }
//
//         private bool InteractWithMovement()
//         {
//             Vector3 target;
//             bool hasHit = RaycastNavMesh(out target);
//             if (hasHit)
//             {
//                 if (!GetComponent<Mover>().CanMoveTo(target)) return false;
//
//                 if (Input.GetMouseButtonDown(0))
//                 {
//                     movementStarted = true;
//                 }
//                 if (Input.GetMouseButton(0) && movementStarted)
//                 {
//                     GetComponent<Mover>().StartMoveAction(target, 1f);
//                 }
//                 SetCentralCursor(CursorType.Movement);
//                 return true;
//             }
//             return false;
//         }
//
//         private bool RaycastNavMesh(out Vector3 target)
//         {
//             target = new Vector3();
//
//             RaycastHit hit;
//             bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
//             if (!hasHit) return false;
//
//             NavMeshHit navMeshHit;
//             bool hasCastToNavMesh = NavMesh.SamplePosition(
//                 hit.point, out navMeshHit, maxNavMeshProjectionDistance, NavMesh.AllAreas);
//             if (!hasCastToNavMesh) return false;
//
//             target = navMeshHit.position;
//
//             return true;
//         }
//
//         private void SetCentralCursor(CursorType type)
//         {
//             CursorMapping mapping = GetCursorMapping(type);
//             Cursor.SetCentralCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
//         }
//
//         private CursorMapping GetCursorMapping(CursorType type)
//         {
//             foreach (CursorMapping mapping in cursorMappings)
//             {
//                 if (mapping.type == type)
//                 {
//                     return mapping;
//                 }
//             }
//             return cursorMappings[0];
//         }
//
//         private static Ray GetMouseRay()
//         {
//             return Camera.main.ScreenPointToRay(Input.mousePosition);
//         }
//     }
// }
