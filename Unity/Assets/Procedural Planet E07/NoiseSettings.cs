using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings {

    public enum FilterType { Simple, Ridgid };
    public FilterType filterType;

    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RidgidNoiseSettings ridgidNoiseSettings;

    

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        public float strength = 1;
        [Range(1, 8)]
        public int numLayers = 1;
        public float baseRoughness = 1;
        public float roughness = 2;
        public float persistence = .5f;
        public Vector3 centre;
        public float minValue;

        public void Randomize()
        {
            strength = Random.Range(0.04f, 0.01f);
            numLayers = 6;
            baseRoughness = Random.Range(0.8f, 1.60f);
            roughness = Random.Range(2f, 5f);
            persistence = Random.Range(0.45f, 0.55f);
            centre = new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f));
            minValue = Random.Range(0.3f, 0.8f);
        }
    }

    [System.Serializable]
    public class RidgidNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultiplier = .8f;
    }



}
