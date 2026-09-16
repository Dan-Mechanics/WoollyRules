using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WoollyRules
{
    public class Webcam : MonoBehaviour
    {
        [SerializeField] private Image imageToProjectWebcamOn = default;
        [SerializeField] private GameObject background = default;
        [SerializeField] private float refreshInterval = default;
        [SerializeField] private bool matchImageSizeToWebcamSize = default;
        [SerializeField] private bool preload = default;
        [SerializeField] private RectTransform rectTransform = default;
        [SerializeField] private AudioSource backgroundMusic = default;
        [SerializeField] private bool musicStopsWhenShowingWebcam = default;

        private WebCamTexture webCamTexture;
        private Texture2D texture;
        private float nextRefresh;
        private Rect rect;
        private Vector2 pivot = new Vector2(0.5f, 0.5f);
        private Color[] webcamColors;

        private bool showing;
        private bool setupDone;
        private float defaultVolume;

        private void Start()
        {
            defaultVolume = backgroundMusic.volume;
            if (preload)
                StartCoroutine(Auhtorize());
        }

        private void FixedUpdate()
        {
            if (!musicStopsWhenShowingWebcam) { return; }

            backgroundMusic.volume = imageToProjectWebcamOn.gameObject.activeSelf ? 0f : defaultVolume;
        }

        public void Show() 
        {
            if (showing)
                return;

            showing = true;
            if (!preload)
                StartCoroutine(Auhtorize());
        }

        public void Hide() 
        {
            if (!showing)
                return;

            showing = false;
            imageToProjectWebcamOn.gameObject.SetActive(false);
            background.SetActive(false);
            if (!preload && webCamTexture) 
            {
                webCamTexture.Stop();
                webCamTexture = null;
            }
        }

        private IEnumerator Auhtorize()
        {
            LogWebcams();
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
            if (!showing)
                return;

            if (!setupDone)
                return;

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

        private void Setup()
        {
            webCamTexture = new WebCamTexture();

            if (!webCamTexture.isPlaying)
                webCamTexture.Play();

            print($"showing: {webCamTexture.deviceName}");
            ResizeWebcam();
            setupDone = true;
        }

        private void RefreshWebcam()
        {
            if (webCamTexture == null || !webCamTexture.isPlaying)
                return;

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
            background.SetActive(true);
        }

        private void ResizeWebcam() 
        {
            print($"webcam dimensions: ({webCamTexture.width}x{webCamTexture.height}).");

            if (matchImageSizeToWebcamSize) { rectTransform.sizeDelta = new Vector2(webCamTexture.width, webCamTexture.height); }

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