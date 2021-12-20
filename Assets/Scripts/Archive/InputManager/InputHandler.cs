using System;
using System.Collections;
using System.Collections.Generic;
using Game.Units.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.InputManager
{
    public class InputHandler : MonoBehaviour
    {

        public static InputHandler instance;

        private RaycastHit hit;

        private List<Transform> SelectedUnits = new List<Transform>();

        private bool isDragging = false;

        private Vector3 mousePos;

        public Color rectColor = new Color(0f,0f,0f,0.25f);
        
        public Color rectBorderColor = new Color(0f, 0f, 1f, 0.5f); 

        void Start()
        {
            instance = this;
        }


        private void OnGUI()
        {
            if (isDragging)
            {
                Rect rect = MultiSelect.GetScreenRect(mousePos, Input.mousePosition);
                MultiSelect.DrawScreenRect(rect, rectColor);
                MultiSelect.DrawScreenRectBorder(rect, 3, rectBorderColor);
            }
        }

        public void HandleUnitMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch (layerHit)
                    {
                        case 8:
                            SelectUnit(hit.transform, Input.GetKey(KeyCode.LeftShift));
                            break;
                        default:
                            isDragging = true;
                            DeselectUnits();
                            break;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (Transform child in Player.PlayerManager.instance.playerUnits)
                {
                    foreach (Transform unit in child)
                    {
                        if (unit != null && isWithinSelectionBounds(unit))
                        {
                            SelectUnit(unit, true);
                        }
                    }
                }
                
                isDragging = false;
            }

            if (Input.GetMouseButtonDown(1) && HaveSelectedUnits())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch (layerHit)
                    {
                        //layer 8 : Player units
                        case 8:
                            
                            break;
                        //layer 9 : Enemy units
                        case 9:
                            break;
                        default:
                            foreach (Transform unit in SelectedUnits)
                            {
                                PlayerUnit pU = unit.gameObject.GetComponent<PlayerUnit>();
                                pU.MoveUnit(hit.point);
                            }
                            break;
                    }
                }
            }
        }

        private void SelectUnit(Transform unit, bool canMultiSelect = false)
        {
            if (!canMultiSelect)
            {
                DeselectUnits();
            }
            SelectedUnits.Add(unit);
            unit.Find("Highlight").gameObject.SetActive(true);
        }

        private void DeselectUnits()
        {
            for (int i = 0; i < SelectedUnits.Count; i++)
            {
                Debug.Log( SelectedUnits[i].name);
                SelectedUnits[i].Find("Highlight").gameObject.SetActive(false);
            }
            SelectedUnits.Clear();
        }

        private bool isWithinSelectionBounds(Transform tf)
        {
            if (!isDragging)
            {
                return false;
            }

            Camera cam = Camera.main;
            Bounds vpBounds = MultiSelect.GetVPBound(cam,mousePos,Input.mousePosition);

            return vpBounds.Contains(cam.WorldToViewportPoint(tf.position));
        }

        private bool HaveSelectedUnits()
        {
            if (SelectedUnits.Count > 0) return true;
            
            return false;
        }
    }
}
