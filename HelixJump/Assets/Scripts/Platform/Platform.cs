using UnityEngine;

namespace Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float bounceForce; 
        [SerializeField] private float bounceRadius;

        public void Break()
        {
            PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

            foreach (var segment in platformSegments)
                segment.Bounce(bounceForce, transform.position, bounceRadius);
        }
    }
}
