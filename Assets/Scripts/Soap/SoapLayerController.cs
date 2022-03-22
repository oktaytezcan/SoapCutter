using UnityEngine;

public class SoapLayerController : MonoBehaviour
{
    [SerializeField]
    private BoxCutterMovementController boxCutterMovementController;

    [SerializeField]
    private GameObject[] soapLayers;

    private MeshRenderer soapLayerMeshRenderer;

    private int layerIndex = 0;

    private void OnEnable()
    {
        EventManager.OnSoapLayerCompleted.AddListener(DisableLayer);
    }

    private void OnDisable()
    {
        EventManager.OnSoapLayerCompleted.RemoveListener(DisableLayer);
    }

    private void Start()
    {
        soapLayerMeshRenderer = soapLayers[layerIndex].GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateSoapVisualisation();
    }

    private void UpdateSoapVisualisation()
    {
        soapLayerMeshRenderer.material.SetFloat("_AlphaSlider", boxCutterMovementController.CutPerct);
    }

    private void DisableLayer()
    {
        if (layerIndex >= soapLayers.Length - 1)
        {
            EventManager.OnLevelFinish?.Invoke();
            return;
        }
        
        soapLayers[layerIndex].SetActive(false);
        layerIndex++;
        soapLayerMeshRenderer = soapLayers[layerIndex].GetComponent<MeshRenderer>();
    }
}
