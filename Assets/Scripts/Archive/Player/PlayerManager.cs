using System.Collections;
using System.Collections.Generic;
using Game.InputManager;
using UnityEngine;



namespace Game.Player
{

    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;

        public Transform enemyUnits;
        
        void Start()
        {
            instance = this;
            Units.UnitHandler.instance.SetBasicUnitStats(enemyUnits);
            Units.UnitHandler.instance.SetBasicUnitStats(playerUnits);
        }

        // Update is called once per frame
        void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}