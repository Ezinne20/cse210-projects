using System;

public class VideoDetails
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    
    public VideoDetails(string title, string description, string duration)
    {
        Title = title;
        Description = description;
        Duration = duration;
    }
}

public class Video
{
    public VideoDetails Details { get; set; }
    
    public Video(string title, string description, string duration)
    {
        Details = new VideoDetails(title, description, duration);
    }
    
    // We expose the important functionality to the user
    public void Play()
    {
        Console.WriteLine($"Now playing: {Details.Title}");
    }

    public void Pause()
    {
        Console.WriteLine($"Paused: {Details.Title}");
    }
}

public class Player
{
    private Video _video;
    
    public Player(Video video)
    {
        _video = video;
    }
    
    // User interacts with the player, not the internal video details
    public void PlayVideo()
    {
        _video.Play();
    }

    public void PauseVideo()
    {
        _video.Pause();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating a video object
        Video video = new Video("C# Abstraction Tutorial", "Learn the basics of abstraction in C#", "10:00");
        
        // Creating a player object
        Player player = new Player(video);

        // Playing and pausing video through the player (hides internal details)
        player.PlayVideo();
        player.PauseVideo();
    }
}
