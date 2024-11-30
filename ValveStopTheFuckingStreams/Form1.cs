using System.Text.RegularExpressions;
using HttpClient = System.Net.Http.HttpClient;

namespace ValveStopTheFuckingStreams;

public partial class Form1 : Form
{
    private const string SteamContentDomain = "steamcontent.com";
    private const string SteamContentDomainPattern = @"<TD>([^<]*\.steamcontent\.com)</TD>";
    private const string HostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
    
    public Form1()
    {
        InitializeComponent();
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        var subDomains = GetSteamContentSubDomains();
        File.AppendAllLines(HostsFilePath,subDomains.Select(domain => $"127.0.0.1 {domain}"));
        blockedDomainsCount.Text = subDomains.Count.ToString();
    }

    private void clear_Click(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines(HostsFilePath).ToList();
        var newLines = lines.Where(line => !line.Contains(SteamContentDomain)).ToList();
        File.WriteAllLines(HostsFilePath, newLines);
        blockedDomainsCount.Text = "0";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var blockedDomains = GetBlockedDomains();
        blockedDomainsCount.Text = blockedDomains.Count.ToString();
    }
    
    private List<string> GetSteamContentSubDomains()
    {
        var httpClient = new HttpClient();
        var response = httpClient.GetAsync("https://crt.sh/?q=steamcontent.com&exclude=expired&group=none").Result;
        var content = response.Content.ReadAsStringAsync().Result;
        
        var matches = Regex.Matches(content, SteamContentDomainPattern);
        return matches.Select(x => x.Groups[1].Value).ToList();
    }
    
    private List<string> GetBlockedDomains()
    {
        return File.ReadAllLines(HostsFilePath).Where(line => line.Contains(SteamContentDomain)).ToList();
    }
}