using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ShippingAddress
{
    public string address;
    public string npcName;

    public ShippingAddress(string _npcName, string _address)
    {
        npcName = _npcName;
        address = _address;
    }
}
public class JsonMaker : MonoBehaviour
{
    public List<ShippingAddress> shipping = new List<ShippingAddress>();
    // Start is called before the first frame update
    void Start()
    {
        shipping.Add(new ShippingAddress("NPC1","69"));
        shipping.Add(new ShippingAddress("NPC2", "70"));
        shipping.Add(new ShippingAddress("NPC3", "71-1"));
        shipping.Add(new ShippingAddress("NPC4", "71-2"));
        shipping.Add(new ShippingAddress("NPC5", "71-3"));
        shipping.Add(new ShippingAddress("NPC6", "72"));
        shipping.Add(new ShippingAddress("NPC7", "73"));
        shipping.Add(new ShippingAddress("NPC8", "74")); 
        shipping.Add(new ShippingAddress("NPC9", "75"));
        shipping.Add(new ShippingAddress("NPC10", "76"));
        shipping.Add(new ShippingAddress("NPC11", "77"));
        shipping.Add(new ShippingAddress("NPC12", "78")); 
        shipping.Add(new ShippingAddress("NPC13", "79"));
        shipping.Add(new ShippingAddress("NPC14", "80"));
        shipping.Add(new ShippingAddress("NPC15", "81"));
        shipping.Add(new ShippingAddress("NPC16", "82")); 
        JsonData addressJson = JsonMapper.ToJson(shipping);
        
        File.WriteAllText(Application.dataPath +"/Resources/ShippingAddress.json",
            addressJson.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
