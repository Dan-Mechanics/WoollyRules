using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    public class Webcam : MonoBehaviour
    {
        [SerializeField] private Image imageToProjectWebcamOn = null;
        [SerializeField] private float refreshInterval = 0f;

        private WebCamTexture webCamTexture;
        private Texture2D texture;
        private float nextRefresh;
        private Rect rect;
        private Vector2 pivot = new Vector2(0.5f, 0.5f);
        private Color[] webcamColors;

        /// <summary>
        /// This is a coroutine.
        /// </summary>
        private IEnumerator Start()
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
            if (Time.time >= nextRefresh) 
            {
                RefreshWebcam();
                nextRefresh = Time.time + refreshInterval;
            }
        }

        private void RefreshWebcam()
        {
            if (webCamTexture == null) { return; }

            if (texture.width != webCamTexture.width || texture.height != webCamTexture.height)
            {
                print(webCamTexture.width);
                print(webCamTexture.height);

                texture = new Texture2D(webCamTexture.width, webCamTexture.height, TextureFormat.RGB24, false);
                rect = new Rect(0f, 0f, texture.width, texture.height);
            }

            webcamColors = webCamTexture.GetPixels();
            texture.SetPixels(webcamColors);
            texture.Apply();

            imageToProjectWebcamOn.sprite = Sprite.Create(texture, rect, pivot, 100f);

            //cam.backgroundColor = BlendColors(webcamColors);
        }

        public void Setup()
        {
            webCamTexture = new WebCamTexture();

            texture = new Texture2D(0, 0, TextureFormat.RGB24, false);

            if (!webCamTexture.isPlaying) { webCamTexture.Play(); }

            print($"showing: {webCamTexture.deviceName}");
        }

        private void LogWebcams()
        {
            for (int i = 0; i < WebCamTexture.devices.Length; i++)
            {
                print($"webcam {i}: {WebCamTexture.devices[i].name}");
            }
        }
    }
}