using System;
using System.Collections.Generic;

class Comment
{
    private string commenterName;
    private string text;

    public Comment(string commenterName, string text)
    {
        this.commenterName = commenterName;
        this.text = text;
    }

    public string GetCommentDetails()
    {
        return $"{commenterName}: \"{text}\"";
    }
}

class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.GetCommentDetails()}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Creating videos
        Video video1 = new Video("C# Basics Tutorial", "Programming with Jose",600);
        Video video2 = new Video("Top 10 Coding Tips", "Tech Guru", 480);
        Video video3 = new Video("How to Cook Pasta", "Chef Ana", 720);
        Video video4 = new Video("Space Exploration Facts", "Science Daily", 900);

        // Adding comments to videos
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Looking forward to more videos!"));

        video2.AddComment(new Comment("David", "Awesome tips!"));
        video2.AddComment(new Comment("Eve", "I learned a lot, thank you."));
        video2.AddComment(new Comment("Frank", "Well presented!"));

        video3.AddComment(new Comment("Grace", "Tried this recipe, it was delicious!"));
        video3.AddComment(new Comment("Hannah", "Best pasta tutorial ever."));
        video3.AddComment(new Comment("Isaac", "What type of cheese would you recommend?"));

        video4.AddComment(new Comment("Jack", "Space is so fascinating!"));
        video4.AddComment(new Comment("Kelly", "I love these space facts."));
        video4.AddComment(new Comment("Liam", "Can you make a video on black holes?"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Displaying video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
