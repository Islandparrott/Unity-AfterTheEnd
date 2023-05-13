
using UnityEngine;

// MAKE PERLIN NOISE FOR WORLD MAP GEN

public class WorldMapPerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    // CHANGES SCALE OF PERLIN NOISE
    public float scale = 25f;

    // OFFSET FOR NOISE
    public float offsetX = 100f;
    public float offsetY = 100f;



    void Start ()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
    }

    void Update ()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenMap();
    }

    // MAKES PERLIN NOISE MAP
    Texture2D GenMap ()
    {
        Texture2D texture = new Texture2D(width, height);

        // GOES THRU EACH PIXEL IN HEIGHTMAP
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                // MAKES PIXEL COLOR GIVEN BY PERLIN NOISE
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();

        return texture;
    }

    // MAKES PERLIN NOISE
    Color CalculateColor (int x, int y)
    {
        // PERLIN NOISE ONLY WORKS FROM 0-1, X AND Y MUST BE MADE INTO DECIMALS TO FIT
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

}
