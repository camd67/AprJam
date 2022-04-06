using UnityEditor;
using UnityEngine;

namespace Asteroid
{
    [CustomEditor(typeof(AsteroidGenerator))]
    public class AsteroidGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate Asteroids"))
            {
                var asteroidGenerator = (AsteroidGenerator)target;
                asteroidGenerator.GenerateAsteroids();
            }
        }
    }
}
