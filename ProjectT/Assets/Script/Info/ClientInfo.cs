using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;
using SteamImage = Steamworks.Data.Image;

public class ClientInfo : MonoBehaviour
{
    public Text clientUserName;
    public Text clientSteamId;

    [SerializeField] private ulong steamId;
    public RawImage clientAvater;
    // Start is called before the first frame update
    private async void Start()
    {
        GetClientInfo();
        clientAvater.texture = await GetClientAvater(steamId);
    }

    private void GetClientInfo()
    {
        clientUserName.text = SteamClient.Name;
        steamId = (ulong)SteamClient.SteamId;
        clientSteamId.text = steamId.ToString();
    }

    private async Task<Texture2D> GetClientAvater(SteamId sID)
    {
        SteamImage AvaterImage = await GetUserImage(sID);
        Texture2D tex = await LoadTextuerFromImage(AvaterImage);
        return tex;
    }
    private async Task<SteamImage> GetUserImage(SteamId id)
    {
        var img = await SteamFriends.GetLargeAvatarAsync(id);
        return (SteamImage)img;
    }
    private async Task<Texture2D> LoadTextuerFromImage(SteamImage img)
    {
        var textur = new Texture2D((int)img.Width, (int)img.Height);
        for(int x = 0;x <img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                var p = img.GetPixel(x, y);
                textur.SetPixel(x, y:(int)img.Height - y, (Color)new Color32(p.r, p.g, p.b, p.a));
            }
        }
        textur.Apply();
        return textur;
    }
}
