using System;
using TMPro;
using UnityEngine;

namespace Grid
{
    public class PlayerTurn : MonoBehaviour
    {
        [SerializeField, Header("Fuel")]
        private int fuel;

        public int Fuel
        {
            get => fuel;
            set
            {
                fuel = value;
                UpdateText();
            }
        }

        [SerializeField]
        private TextMeshProUGUI fuelText;

        [SerializeField, Header("Missiles")]
        private int missileCount;

        public int MissileCount
        {
            get => missileCount;
            set
            {
                missileCount = value;
                UpdateText();
            }
        }

        [SerializeField]
        private TextMeshProUGUI missileText;

        private void Awake()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            fuelText.text = "Fuel: " + fuel;
            missileText.text = "Missiles: " + missileCount;
        }
    }
}
