using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : SingletonMonobehaviour<GridPropertiesManager>, ISaveable
{
    private Tilemap groundDecoration1;
    private Tilemap groundDecoration2;
    private Grid grid;
    private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
    [SerializeField] private SO_GridProperties[] so_gridPropertiesArray = null;
    [SerializeField] private Tile[] dugGround = null;

    private string _iSaveableUniqueID;
    public string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; } }

    private GameObjectSave _gameObjectSave;
    public GameObjectSave GameObjectSave { get { return _gameObjectSave; } set { _gameObjectSave = value; } }

    protected override void Awake()
    {
        base.Awake();

        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    private void OnEnable()
    {
        ISaveableRegister();

        EventHandler.AfterSceneLoadEvent += AfterSceneLoaded;
    }

    private void OnDisable()
    {
        ISaveableDeregister();

        EventHandler.AfterSceneLoadEvent -= AfterSceneLoaded;
    }

    private void Start()
    {
        InitialiseGridProperties();
    }

    private void ClearDisplayGroundDecorations()
    {
        // Remove ground decorations
        groundDecoration1.ClearAllTiles();
        groundDecoration2.ClearAllTiles();
    }

    private void ClearDisplayGridPropertyDetails()
    {
        ClearDisplayGroundDecorations();
    }

    public void DisplayDugGround(GridPropertyDetails gridPropertyDetails)
    {
        //Dug
        if (gridPropertyDetails.daysSinceDug > -1)
        {
            connectDugGround(gridPropertyDetails);
        }
    }

    private void connectDugGround(GridPropertyDetails gridPropertyDetails)
    {
        Tile dugTile0 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY);
        groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY, 0), dugTile0);

        GridPropertyDetails adjacentGridPropertyDetails;

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile1 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1, 0), dugTile1);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile2 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1, 0), dugTile2);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile3 = SetDugTile(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY, 0), dugTile3);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile4 = SetDugTile(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY, 0), dugTile4);
        }
    }

    private Tile SetDugTile(int xGrid, int yGrid)
    {
        //Get wheter surrounding tiles (up, down, left, right) are dug or not

        bool upDug = IsGridSquareDug(xGrid, yGrid + 1);
        bool downDug = IsGridSquareDug(xGrid, yGrid - 1);
        bool leftDug = IsGridSquareDug(xGrid - 1, yGrid);
        bool rightDug = IsGridSquareDug(xGrid + 1, yGrid);

        if (!upDug && !downDug && !rightDug && !leftDug)
        {
            return dugGround[0];
        }
        else if (!upDug && downDug && rightDug && !leftDug)
        {
            return dugGround[1];
        }
        else if (!upDug && downDug && rightDug && leftDug)
        {
            return dugGround[2];
        }
        else if (!upDug && downDug && !rightDug && leftDug)
        {
            return dugGround[3];
        }
        else if (!upDug && downDug && !rightDug && !leftDug)
        {
            return dugGround[4];
        }
        else if (upDug && downDug && rightDug && !leftDug)
        {
            return dugGround[5];
        }
        else if (upDug && downDug && rightDug && leftDug)
        {
            return dugGround[6];
        }
        else if (upDug && downDug && !rightDug && leftDug)
        {
            return dugGround[7];
        }
        else if (upDug && downDug && !rightDug && !leftDug)
        {
            return dugGround[8];
        }
        else if (upDug && !downDug && rightDug && !leftDug)
        {
            return dugGround[9];
        }
        else if (upDug && !downDug && rightDug && leftDug)
        {
            return dugGround[10];
        }
        else if (upDug && !downDug && !rightDug && leftDug)
        {
            return dugGround[11];
        }
        else if (upDug && !downDug && !rightDug && !leftDug)
        {
            return dugGround[12];
        }
        else if (!upDug && !downDug && rightDug && !leftDug)
        {
            return dugGround[13];
        }
        else if (!upDug && !downDug && rightDug && leftDug)
        {
            return dugGround[14];
        }
        else if (!upDug && !downDug && !rightDug && leftDug)
        {
            return dugGround[15];
        }

        return null;

    }

    private bool IsGridSquareDug(int xGrid, int yGrid)
    {
        GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(xGrid, yGrid);

        if (gridPropertyDetails == null)
        {
            return false;
        }
        else if (gridPropertyDetails.daysSinceDug > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DisplayGridPropertyDetails()
    {
        foreach (KeyValuePair<string, GridPropertyDetails> item in gridPropertyDictionary)
        {
            GridPropertyDetails gridPropertyDetails = item.Value;

            DisplayDugGround(gridPropertyDetails);
        }
    }

    private void InitialiseGridProperties()
    {
        foreach (SO_GridProperties so_GridProperties in so_gridPropertiesArray)
        {
            Dictionary<string, GridPropertyDetails> gridPropertyDictionary = new Dictionary<string, GridPropertyDetails>();

            foreach (GridProperty gridProperty in so_GridProperties.gridPropertyList)
            {
                GridPropertyDetails gridPropertyDetails;

                gridPropertyDetails = GetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDictionary);

                if (gridPropertyDetails == null)
                {
                    gridPropertyDetails = new GridPropertyDetails();
                }

                switch (gridProperty.gridBoolProperty)
                {
                    case GridBoolProperty.digable:
                        gridPropertyDetails.isDiggable = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.canDropItem:
                        gridPropertyDetails.canDropItem = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.canPlaceFurniture:
                        gridPropertyDetails.canPlaceFurnite = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.isPath:
                        gridPropertyDetails.isPath = gridProperty.gridBoolValue;
                        break;

                    case GridBoolProperty.isNPCObstacle:
                        gridPropertyDetails.isNPCObstacle = gridProperty.gridBoolValue;
                        break;

                    default:
                        break;
                }

                SetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDetails, gridPropertyDictionary);
            }

            SceneSave sceneSave = new SceneSave();

            sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;

            if (so_GridProperties.sceneName.ToString() == SceneControllerManager.Instance.startingSceneName.ToString())
            {
                this.gridPropertyDictionary = gridPropertyDictionary;
            }

            GameObjectSave.sceneData.Add(so_GridProperties.sceneName.ToString(), sceneSave);
        }
    }

    public void AfterSceneLoaded()
    {
        grid = GameObject.FindObjectOfType<Grid>();

        groundDecoration1 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration1).GetComponent<Tilemap>();
        groundDecoration2 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration2).GetComponent<Tilemap>();
    }

    public GridPropertyDetails GetGridPropertyDetails(int gridX, int GridY)
    {
        return GetGridPropertyDetails(gridX, GridY, gridPropertyDictionary);
    }

    public GridPropertyDetails GetGridPropertyDetails(int gridX, int gridY, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = "x" + gridX + "y" + gridY;

        GridPropertyDetails gridPropertyDetails;

        if (!gridPropertyDictionary.TryGetValue(key, out gridPropertyDetails))
        {
            return null;
        }
        else
        {
            return gridPropertyDetails;
        }
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.gridPropertyDetailsDictionary != null)
            {
                gridPropertyDictionary = sceneSave.gridPropertyDetailsDictionary;
            }

            if (gridPropertyDictionary.Count > 0)
            {
                ClearDisplayGridPropertyDetails();

                DisplayGridPropertyDetails();
            }
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        GameObjectSave.sceneData.Remove(sceneName);

        SceneSave sceneSave = new SceneSave();

        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;

        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }

    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails)
    {
        SetGridPropertyDetails(gridX, gridY, gridPropertyDetails, gridPropertyDictionary);
    }

    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = "x" + gridX + "y" + gridY;

        gridPropertyDetails.gridX = gridX;
        gridPropertyDetails.gridY = gridY;

        gridPropertyDictionary[key] = gridPropertyDetails;
    }

}
