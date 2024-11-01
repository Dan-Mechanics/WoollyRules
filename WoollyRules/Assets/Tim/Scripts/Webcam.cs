using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    /// <summary>
    /// NOTE: you can either preload the webcam or not ...
    /// TODO: refactor, should not a must ...
    /// </summary>
    public class Webcam : MonoBehaviour
    {
        [SerializeField] private Image imageToProjectWebcamOn = null;
        [SerializeField] private float refreshInterval = 0f;
        [SerializeField] private bool matchImageSizeToWebcamSize = false;
        [SerializeField] private bool preload = false;

        private WebCamTexture webCamTexture;
        private Texture2D texture;
        private float nextRefresh;
        private Rect rect;
        private Vector2 pivot = new Vector2(0.5f, 0.5f);
        private Color[] webcamColors;

        private bool showing;
        private bool setupDone;

        private void Start()
        {
            if (preload) 
            {
                //Application.targetFrameRate = 300;
                
                StartCoroutine(Auhtorize());
            }
        }

        public void Show() 
        {
            showing = true;

            //gameObject.SetActive(true);

            if (!preload) { StartCoroutine(Auhtorize()); }
        }

        public void Hide() 
        {
            showing = false;

            imageToProjectWebcamOn.gameObject.SetActive(false);

            if (!preload && webCamTexture != null) 
            {
                webCamTexture.Stop();
                webCamTexture = null;
            }
        }

        /// <summary>
        /// This is a coroutine.
        /// </summary>
        private IEnumerator Auhtorize()
        {
            //if (setupDone) { yield break; }
            
            LogWebcams();

            // spooky magic code here dont touch !
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                print("webcam found.");

                Setup();
            }
            else
            {
                print("webcam not found.");
            }
        }

        private void Update()
        {
            if (!showing) { return; }
            if (!setupDone) { return; }

            if (Time.time >= nextRefresh) 
            {
                RefreshWebcam();
                nextRefresh = Time.time + refreshInterval;
            }
        }

        private void LogWebcams()
        {
            for (int i = 0; i < WebCamTexture.devices.Length; i++)
            {
                print($"webcam {i}: {WebCamTexture.devices[i].name}");
            }
        }

        /// <summary>
        /// We do this in the start and then disable because that way the webcam instantly pops up with no delay
        /// or hesitation. The downsdie is that the webcam light is on the whole time which might be good idk.
        /// i could fix it ...
        /// </summary>
        private void Setup()
        {
            //imageToProjectWebcamOn.enabled = true;

            webCamTexture = new WebCamTexture();

            if (!webCamTexture.isPlaying) { webCamTexture.Play(); }

            print($"showing: {webCamTexture.deviceName}");

            ResizeWebcam();

            //RefreshWebcam();
            //gameObject.SetActive(false);

            setupDone = true;
        }

        private void RefreshWebcam()
        {
            if (webCamTexture == null) { return; }

            //print("RefreshWebcam()");

            // just in case.
            if (texture.width != webCamTexture.width || texture.height != webCamTexture.height)
            {
                Debug.LogWarning("if (texture.width != webCamTexture.width || texture.height != webCamTexture.height) was right which is not ideal.");
                
                ResizeWebcam();
            }

            webcamColors = webCamTexture.GetPixels();
            texture.SetPixels(webcamColors);
            texture.Apply();

            imageToProjectWebcamOn.sprite = Sprite.Create(texture, rect, pivot, 100f);

            imageToProjectWebcamOn.gameObject.SetActive(true);
        }

        private void ResizeWebcam() 
        {
            print($"webcam dimensions: ({webCamTexture.width}x{webCamTexture.height}).");

            if (matchImageSizeToWebcamSize) { imageToProjectWebcamOn.rectTransform.sizeDelta = new Vector2(webCamTexture.width, webCamTexture.height); }

            texture = new Texture2D(webCamTexture.width, webCamTexture.height, TextureFormat.RGB24, false);
            rect = new Rect(0f, 0f, texture.width, texture.height);
        }

        private void OnDestroy()
        {
            if (webCamTexture == null) { return; }

            webCamTexture.Stop();
        }
    }
}