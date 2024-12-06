using System.Text.RegularExpressions;
using HttpClient = System.Net.Http.HttpClient;

namespace ValveStopTheFuckingStreams;

public partial class Form1 : Form
{
    private const string SteamMainBroadCastDomain = "steambroadcast.akamaized.net";
    private List<string> SteamContentDomains = ["steamcontent.com",SteamMainBroadCastDomain];
    private const string SteamContentDomainPattern = @"<TD>([^<]*\.steamcontent\.com)</TD>";
    private const string HostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
    
    public Form1()
    {
        InitializeComponent();
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        var subDomains = GetAllBroadCastDomains();
        File.AppendAllLines(HostsFilePath,subDomains.Select(domain => $"127.0.0.1 {domain}"));
        blockedDomainsCount.Text = subDomains.Count.ToString();
    }

    private void clear_Click(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines(HostsFilePath).ToList();
        var newLines = lines.Where(line => !SteamContentDomains.Any(line.Contains)).ToList();
        File.WriteAllLines(HostsFilePath, newLines);
        blockedDomainsCount.Text = "0";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var blockedDomains = GetBlockedDomains();
        blockedDomainsCount.Text = blockedDomains.Count.ToString();
    }
    
    private List<string> GetAllBroadCastDomains()
    {
        var domains = GetSteamContentSubDomains();
        if (domains.Count == 0)
        {
            MessageBox.Show("Failed to get subdomains");
            return new List<string>();
        }
        domains.Add(SteamMainBroadCastDomain);
        
        return domains;
    }
    
    private List<string> GetSteamContentSubDomains()
    {
        try
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://crt.sh/?q=steamcontent.com&exclude=expired&group=none").Result;
            var content = response.Content.ReadAsStringAsync().Result;

            var matches = Regex.Matches(content, SteamContentDomainPattern);
            return matches.Select(x => x.Groups[1].Value).ToList();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return new List<string>();
        }
    }
    
    private List<string> GetBlockedDomains()
    {
        return File.ReadAllLines(HostsFilePath).Where(line => SteamContentDomains.Any(line.Contains)).ToList();
    }
}