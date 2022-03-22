using System.Collections;
using UnityEngine;

public class BoxCutterMovementController : MonoBehaviour
{
    [SerializeField]
    private float cutterMovementSpeed;

    [SerializeField]
    private float layerThickness;

    [SerializeField]
    private float movementBorder = -1.1f;

    [SerializeField]
    private ParticleSystem cutVFX;

    private Transform _transform;

    private Vector3 startPos;

    private bool isPlaying, isMoved;

    private float layerDistance;

    private float cutPerct;
    public float CutPerct { get { return cutPerct; } }

    private int layerCounter = 0;
    
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFinish.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFinish.RemoveListener( () => isPlaying = false );
    }  

    void Start()
    {
        _transform = this.transform;
        isMoved = false;
        startPos = _transform.position;
        layerDistance = (movementBorder - startPos.z);
        cutPerct = Mathf.Abs((movementBorder - _transform.position.z)/ layerDistance);
    }

    void Update()
    {
        MoveCutter();
    }

    private void MoveCutter()
    {
        if (!isPlaying || !Input.GetMouseButton(0))
        {
            cutVFX.gameObject.SetActive(false);
            return;
        }

        if (Input.GetMouseButton(0) && isPlaying)
        {
            cutVFX.gameObject.SetActive(true);
            _transform.position += Vector3.back * cutterMovementSpeed * Time.deltaTime;
            cutPerct = (Mathf.Abs((movementBorder - _transform.position.z) / layerDistance) / 2f) + 0.5f;

            if (_transform.position.z <= movementBorder && !isMoved)
            {
                StartCoroutine(MoveToInitialPosition());
            }
        }
    }

    private IEnumerator MoveToInitialPosition()
    {
        isMoved = true;
        isPlaying = false;
        LeanTween.move(this.gameObject, startPos + Vector3.down * layerThickness, 0.5f);
        layerCounter++;
        yield return new WaitForSeconds(0.6f);
        EventManager.OnSoapLayerCompleted?.Invoke();
        
        if (layerCounter <= 2)
        {
            isPlaying = true;
            isMoved = false;
        }
    }
}
