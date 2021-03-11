using Platform;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int levelCount;
        [SerializeField] private float additionalScale;
        [SerializeField] private GameObject beam;
        [SerializeField] private Platform.Platform[] platforms;
        [SerializeField] private SpawnPlatform spawnPlatform;
        [SerializeField] private FinishPlatform finishPlatform;

        private float _startAndFinishAdditionalScale = 0.5f;


        public float BeamScaleY => levelCount / 2f + _startAndFinishAdditionalScale + additionalScale / 2f;
    
        private void Awake() => Build();

        private void Build()
        {
            var beamInstantiate = Instantiate(beam, transform);
            beamInstantiate.transform.localScale = new Vector3(1, BeamScaleY, 1);

            var spawnPosition = beamInstantiate.transform.position;
            spawnPosition.y += beamInstantiate.transform.localScale.y - additionalScale;
        
            SpawnPlatform(spawnPlatform, ref spawnPosition, beamInstantiate.transform);

            for (int i = 0; i < levelCount; i++)
                SpawnPlatform(platforms[Random.Range(0, platforms.Length)], 
                    ref spawnPosition, beamInstantiate.transform);
            
            SpawnPlatform(finishPlatform, ref spawnPosition, beamInstantiate.transform);
        }

        private void SpawnPlatform(Platform.Platform platform, ref Vector3 spawnPosition, Transform parent)
        {
            Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0, 360),0), parent);
            spawnPosition.y -= 1;
        }
    }
}
