using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Tools
{
    public static LocalhostInfo GetIP(string ip)
    {
        LocalhostInfo localhost = new LocalhostInfo();
        localhost.Province = "未知";
        localhost.City = "未知";
        try
        {
            string url = "http://api.map.baidu.com/location/ip?ak=RGSGTrQCwCk4CHSlrn71fDqGXqPFTrwO&ip=" + ip;
            WebClient client = new WebClient();
            var buffer = client.DownloadData(url);
            string jsonText = Encoding.UTF8.GetString(buffer);
            JObject jo = JObject.Parse(jsonText);
            var province = jo["content"]["address_detail"]["province"].ToString();
            var city = jo["content"]["address_detail"]["city"].ToString();
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city))
            {
                return localhost;

            }
            localhost.Province = province;
            localhost.City = city;
            return localhost;
        }
        catch
        {
            return localhost;
        }
    }//获取内网IP
    public static IPAddress GetInternalIP()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in nics)
        {
            foreach (var uni in adapter.GetIPProperties().UnicastAddresses)
            {
                if (uni.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return uni.Address;
                }
            }
        }
        return null;
    }
}