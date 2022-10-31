using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;
using TMPro;

public class QrCodeRecenter : MonoBehaviour
{
    [SerializeField]
    private ARSession session;
    [SerializeField]
    private ARSessionOrigin sessionOrigin;
    [SerializeField]
    private ARCameraManager cameraManager;
    [SerializeField]
    private GameObject qrCodeScanningPanel;
    [SerializeField]
    private GameObject funcionesPanel;
    [SerializeField]
    private GameObject buttonPiso;
    [SerializeField]
    private TMP_Text changeFloorText;

    //private ControlIndicator indicator;
    private SetNavigationTarget navigation;

    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader(); // create a barcode reader instance
    private bool scanningEnabled = false;

    public bool changeFloor;

    private void Start()
    {
        //indicator = GameObject.FindObjectOfType<ControlIndicator>();
        navigation = GameObject.FindObjectOfType<SetNavigationTarget>();
        ToggleScanning();
    }
    private void Update()
    {
        //string selectedText = navigationTargetDropDown.options[selectedValue].text;

        if (changeFloor == true)
        {
            changeFloorText.text = "Piso 2";
        }
        else if (changeFloor == false)
        {
            changeFloorText.text = "Piso 1";
        }

    }

    private void OnEnable()
    {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }
    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        if (!scanningEnabled)
        {
            return;
        }

        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            return;
        }

        var conversionParams = new XRCpuImage.ConversionParams
        {
            // Get the entire image.
            inputRect = new RectInt(0, 0, image.width, image.height),

            // Downsample by 2.
            outputDimensions = new Vector2Int(image.width / 2, image.height / 2),

            // Choose RGBA format.
            outputFormat = TextureFormat.RGBA32,

            // Flip across the vertical axis (mirror image).
            transformation = XRCpuImage.Transformation.MirrorY
        };

        // See how many bytes you need to store the final image.
        int size = image.GetConvertedDataSize(conversionParams);

        // Allocate a buffer to store the image.
        var buffer = new NativeArray<byte>(size, Allocator.Temp);

        // Extract the image data
        image.Convert(conversionParams, buffer);

        // The image was converted to RGBA32 format and written into the provided buffer
        // so you can dispose of the XRCpuImage. You must do this or it will leak resources.
        image.Dispose();

        // At this point, you can process the image, pass it to a computer vision algorithm, etc.
        // In this example, you apply it to a texture to visualize it.

        // You've got the data; let's put it into a texture so you can visualize it.
        cameraImageTexture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false);

        cameraImageTexture.LoadRawTextureData(buffer);
        cameraImageTexture.Apply();

        // Done with your temporary data, so you can dispose it.
        buffer.Dispose();

        // Detect and decode the barcode inside the bitmap
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        // Do something with the result
        if (result != null)
        {
            SetQrCodeRecenterTarget(result.Text);
            ToggleScanning();
        }
    }

    public void SetQrCodeRecenterTarget(string targetText)
    {
        if (targetText == "PrimerPiso" || targetText == "PuntoF1" || targetText == "PuntoF2" || targetText == "PuntoF3" || targetText == "PuntoF4")
        {
            changeFloor = false;
            navigation.ConditionsFloor();
        }
        else if (targetText == "SegundoPiso" || targetText == "PuntoS1" || targetText == "PuntoS2" || targetText == "PuntoS3" || targetText == "PuntoS4")
        {
            changeFloor = true;
            navigation.ConditionsFloor();
        }

        //Position
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(targetText.ToLower()));
        if (currentTarget != null)
        {
            // Reset position and rotation of ARSession
            session.Reset();

            // Add offset for recentering
            sessionOrigin.transform.position = currentTarget.PositionObject.transform.position;
            sessionOrigin.transform.rotation = currentTarget.PositionObject.transform.rotation;
        }
    }

    public void ChangeUbication()
    {
        changeFloor = !changeFloor;
        Debug.Log("change Floor --> " + changeFloor);

        if (changeFloor == true)
        {
            SetQrCodeRecenterTarget("SegundoPiso");
        }
        else if (changeFloor == false)
        {
            SetQrCodeRecenterTarget("PrimerPiso");
        }
    }

    public void ToggleScanning()
    {
        scanningEnabled = !scanningEnabled;
        qrCodeScanningPanel.SetActive(scanningEnabled);
        funcionesPanel.SetActive(!scanningEnabled);
        buttonPiso.SetActive(!scanningEnabled);
    }
}
