using System;
using UnityEngine;

namespace Platform
{
    public class FinishPlatform : Platform
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Ball.Ball ball))
                Debug.Log("Level Completed!");
        }
    }
}
