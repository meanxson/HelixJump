using System;
using Platform;
using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlatformSegment platformSegment))
                other.GetComponentInParent<Platform.Platform>().Break();
            
        }
    }
}
