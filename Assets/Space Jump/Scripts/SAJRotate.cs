using System;
using UnityEngine;

namespace SAJ.Scripts
{
    public class SAJRotate : MonoBehaviour
    {
        [SerializeField] private Transform _sajTarget;

        private void Update()
        {
            _sajTarget.Rotate(Vector3.right * 800f * Time.deltaTime);
        }
    }
}