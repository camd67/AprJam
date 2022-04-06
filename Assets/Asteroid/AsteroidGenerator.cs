using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroid
{
    public class AsteroidGenerator : MonoBehaviour
    {
        [SerializeField]
        private int numAsteroids;

        [SerializeField]
        private GameObject asteroidPrefab;

        [SerializeField, Min(0)]
        private float maxGenerationDistance;

        [SerializeField, Min(0.01f)]
        private float minScale;

        [SerializeField, Min(0.01f)]
        private float maxScale;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, maxGenerationDistance);
        }

        public void GenerateAsteroids()
        {
            while (transform.childCount > 0)
            {
                var child = transform.GetChild(0);
                child.SetParent(null);
                DestroyImmediate(child.gameObject);
            }

            // Do some magic to get number of digits, but -1 first since we're doing 0-based counting
            var formatString = string.Concat(Enumerable.Repeat("0", (int)Math.Floor(Math.Log10(numAsteroids - 1)) + 1));

            for (var i = 0; i < numAsteroids; i++)
            {
                var asteroid = Instantiate(asteroidPrefab, Random.insideUnitSphere * maxGenerationDistance, Random.rotation, transform);
                asteroid.name = "Asteroid_" + i.ToString(formatString);
                var scale = Random.Range(minScale, maxScale);
                asteroid.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
#endif
    }
}
