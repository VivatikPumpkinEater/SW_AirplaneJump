using System;
using SAJ.Scripts;
using UnityEngine;

namespace Space_Jump
{
    public class SAJTrig : MonoBehaviour
    {
        public event Action SAJONTrig;

        private void OnMouseUpAsButton()
        {
            if (SAJStatic.SAJIgnore)
                return;
            
            SAJONTrig?.Invoke();
        }
    }
}