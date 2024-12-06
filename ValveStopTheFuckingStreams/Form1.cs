using System.Text.RegularExpressions;
using HttpClient = System.Net.Http.HttpClient;

namespace ValveStopTheFuckingStreams;

public partial class Form1 : Form
{
    private const string SteamMainContentDomain = "steambroadcast.akamaized.net";
    private List<string> SteamContentDomains = ["steamcontent.com",SteamMainContentDomain];
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
        var newLines = lines.Where(line => !SteamContentDomains.Any(line.Contains)).ToList();
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
        return [SteamMainContentDomain];
    }
    
    private List<string> GetBlockedDomains()
    {
        return File.ReadAllLines(HostsFilePath).Where(line => SteamContentDomains.Any(line.Contains)).ToList();
    }
}