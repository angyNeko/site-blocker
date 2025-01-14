using System;
using System.IO;
using System.Linq;

class Program
{
    static string hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
    static string[] socialMediaSites = new string[]
    {
        "facebook.com", "www.facebook.com",
        "youtube.com", "www.youtube.com",
        "tiktok.com", "www.tiktok.com",
        "twitter.com", "www.twitter.com",
        "instagram.com", "www.instagram.com",
        "linkedin.com", "www.linkedin.com",
        "pinterest.com", "www.pinterest.com"
    };

    static void Main()
    {
        Console.WriteLine("Do you want to block or unblock social media sites? (block/unblock): ");
        string action = Console.ReadLine().Trim().ToLower();

        if (action == "block")
        {
            BlockSites();
        }
        else if (action == "unblock")
        {
            UnblockSites();
        }
        else
        {
            Console.WriteLine("Invalid action. Please enter either 'block' or 'unblock'.");
        }
    }

    static void BlockSites()
    {
        try
        {
            File.AppendAllLines(hostsPath, socialMediaSites.Select(site => $"127.0.0.1 {site}"));
            Console.WriteLine("Social media sites have been blocked.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error blocking sites: {ex.Message}");
        }
    }

    static void UnblockSites()
    {
        try
        {
            var lines = File.ReadAllLines(hostsPath).Where(line => !socialMediaSites.Any(site => line.Contains(site)));
            File.WriteAllLines(hostsPath, lines);
            Console.WriteLine("Social media sites have been unblocked.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error unblocking sites: {ex.Message}");
        }
    }
}