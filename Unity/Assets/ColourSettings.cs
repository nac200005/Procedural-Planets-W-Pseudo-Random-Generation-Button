using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColourSettings : ScriptableObject
{
    public Material planetMaterial;
    public BiomeColourSettings biomeColourSettings;
    public Gradient oceanColour;

    [System.Serializable]
    public class BiomeColourSettings
    {
        public Biome[] biomes;
        public NoiseSettings noise;
        public float noiseOffset;
        public float noiseStrength;
        [Range(0,1)]
        public float blendAmount;

        [System.Serializable]
        public class Biome
        {
            public void Randomize()
            {
                GradientColorKey[] colorkeys = new GradientColorKey[Random.Range(1, 9)];
                GradientAlphaKey[] alphakeys = new GradientAlphaKey[colorkeys.Length];

                float length = colorkeys.Length;
                float num = 0f;
                for (int i = 0; i < colorkeys.Length; i++)
                {
                    num = i;
                    colorkeys[i].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    colorkeys[i].time = num / length;
                    alphakeys[i].time = num / length;
                    alphakeys[i].alpha = 1;
                }
                
                gradient = new Gradient();
                gradient.mode = GradientMode.Blend;
                gradient.SetKeys(colorkeys, alphakeys);

                tint = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                tintPercent = Random.Range(0f, 0.5f);
            }

            public Gradient gradient;
            public Color tint;
            [Range(0, 1)]
            public float startHeight;
            [Range(0, 1)]
            public float tintPercent;
        }
    }
}
