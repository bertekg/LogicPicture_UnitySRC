using UnityEngine;
using UnityEngine.UI;

public class TilesManager : MonoBehaviour
{
    [SerializeField] Canvas canvasData;
    [SerializeField] Image cellPrefab;
    [SerializeField] Text textPrefab;
    [SerializeField] Image colorPrefab;
    [SerializeField] GameObject colorPanel;

    private GameObject panel;
    private Level level;

    void Start()
    {
        Level level = FindObjectOfType<LevelDataGame>().GetFullLevel();
        panel = new GameObject();
        panel.name = "MainPanel";
        panel.AddComponent<CanvasRenderer>();
        panel.AddComponent<RectTransform>();
        float anchorMinY = (0.6f * (float)Screen.width) / (float)Screen.height;
        panel.GetComponent<RectTransform>().anchorMin = new Vector2(0, anchorMinY);
        panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.94f);
        panel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        panel.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        float panelHeight = 0.94f * (float)Screen.height - (0.6f * (float)Screen.width);
        float panelWidth = (float)Screen.width;
        float offsetHeight = 0, offsetWidth = 0;
        float basicTileScale = 0;
        int maxVerticalHint = 0;
        for (int i = 0; i < level.HintsDataVertical.Count; i++)
        {
            if (maxVerticalHint < level.HintsDataVertical[i].Count)
            {
                maxVerticalHint = level.HintsDataVertical[i].Count;
            }
        }
        int maxHorizontalHint = 0;
        for (int i = 0; i < level.HintsDataHorizontal.Count; i++)
        {
            if (maxHorizontalHint < level.HintsDataHorizontal[i].Count)
            {
                maxHorizontalHint = level.HintsDataHorizontal[i].Count;
            }
        }
        if (panelHeight / (level.HeightY + maxHorizontalHint) >= panelWidth / (level.WidthX + maxVerticalHint))
        {
            basicTileScale = panelWidth / (level.WidthX + maxVerticalHint);
            offsetHeight = panelHeight - (basicTileScale * (level.HeightY + maxHorizontalHint));
        }
        else
        {
            basicTileScale = panelHeight / (level.HeightY + maxHorizontalHint);
            offsetWidth = panelWidth - (basicTileScale * (level.WidthX + maxVerticalHint));
        }
        panel.AddComponent<Image>();
        panel.GetComponent<Image>().color = GetColorFromColorData(level.ColorDataBackground);
        panel.transform.SetParent(canvasData.transform, false);
        for (int i = 0; i < level.WidthX; i++)
        {
            for (int j = 0; j < level.HeightY; j++)
            {
                Image cellInstatiate = (Image)Instantiate(cellPrefab);

                cellInstatiate.name = "Tille_" + i.ToString() + "_" + j.ToString();
                cellInstatiate.color = GetColorFromColorData(level.ColorDataNeutral);
                cellInstatiate.GetComponent<SetColorInside>().SetColor(cellInstatiate.color);
                
                cellInstatiate.transform.position = new Vector3((offsetWidth / 2) + (maxVerticalHint + i) * basicTileScale, (offsetHeight / 2) + j * basicTileScale);
                cellInstatiate.GetComponent<RectTransform>().sizeDelta = new Vector2(basicTileScale, basicTileScale);
                cellInstatiate.transform.SetParent(panel.transform, false);
            }
        }
        for (int i = 0; i < level.HeightY; i++)
        {
            for (int j = 0; j < level.HintsDataVertical[i].Count; j++)
            {
                Text textInstantiateVertical = (Text)Instantiate(textPrefab);
                textInstantiateVertical.name = "HintVerical_" + i.ToString() + "_" + j.ToString();
                textInstantiateVertical.text = level.HintsDataVertical[i][j].Value.ToString();
                byte colorId = level.HintsDataVertical[i][j].ColorID;
                textInstantiateVertical.color = GetColorFromColorData(level.ColorsDataTiles[colorId]);
                textInstantiateVertical.transform.position = new Vector3((offsetWidth / 2) + (maxVerticalHint - level.HintsDataVertical[i].Count + j) * basicTileScale, (offsetHeight / 2) + i * basicTileScale);
                textInstantiateVertical.GetComponent<RectTransform>().sizeDelta = new Vector2(basicTileScale, basicTileScale);
                textInstantiateVertical.transform.SetParent(panel.transform, false);
            }
        }
        for (int i = 0; i < level.WidthX; i++)
        {
            for (int j = 0; j < level.HintsDataHorizontal[i].Count; j++)
            {
                Text textInstantiateHorizontal = (Text)Instantiate(textPrefab);
                textInstantiateHorizontal.name = "HintHorizontal_" + i.ToString() + "_" + j.ToString();
                textInstantiateHorizontal.text = level.HintsDataHorizontal[i][j].Value.ToString();
                byte colorId = level.HintsDataHorizontal[i][j].ColorID;
                textInstantiateHorizontal.color = GetColorFromColorData(level.ColorsDataTiles[colorId]);
                textInstantiateHorizontal.transform.position = new Vector3((offsetWidth / 2) + (maxVerticalHint + i) * basicTileScale, (offsetHeight / 2) + (level.HeightY + level.HintsDataHorizontal[i].Count - 1 - j) * basicTileScale);
                textInstantiateHorizontal.GetComponent<RectTransform>().sizeDelta = new Vector2(basicTileScale, basicTileScale);
                textInstantiateHorizontal.transform.SetParent(panel.transform, false);
            }
        }
        for (int i = 0; i < level.ColorsDataTiles.Count; i++)
        {
            Image colorInstantiate = (Image)Instantiate(colorPrefab);
            colorInstantiate.name = "Color_" + i.ToString();
            if (i > 0)
            {
                colorInstantiate.color = GetColorFromColorData(level.ColorsDataTiles[i]);
            }
            else
            {
                colorInstantiate.color = Color.red;
            }
            colorInstantiate.GetComponent<SetColorInside>().SetColor(GetColorFromColorData(level.ColorsDataTiles[i]));
            colorInstantiate.transform.SetParent(colorPanel.transform, false);
        }
    }

    private Color GetColorFromColorData(ColorData colorData)
    {
        return new Color(colorData.Red / 255.0f, colorData.Green / 255.0f, colorData.Blue / 255.0f);
    }
}
