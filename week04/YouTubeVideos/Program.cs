using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the videos
        List<Video> videos = new List<Video>();

        // Create Video 1 and add comments
        Video video1 = new Video("Learn C# Fast", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "This helped me a lot."));
        video1.AddComment(new Comment("Charlie", "Clear explanation."));
        videos.Add(video1);

        // Create Video 2 and add comments
        Video video2 = new Video("How to Cook Pasta", "Chef Mario", 300);
        video2.AddComment(new Comment("David", "Delicious recipe!"));
        video2.AddComment(new Comment("Emma", "Can I use gluten-free pasta?"));
        video2.AddComment(new Comment("Frank", "So simple and fast."));
        videos.Add(video2);

        // Create Video 3 and add comments
        Video video3 = new Video("Space News 2026", "Science Channel", 1200);
        video3.AddComment(new Comment("Grace", "Amazing visuals."));
        video3.AddComment(new Comment("Hank", "Wow, I love space!"));
        video3.AddComment(new Comment("Ivy", "Very educational."));
        videos.Add(video3);

        // Loop through the list and display everything
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._commenterName}: \"{comment._text}\"");
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}

class Comment
{
    public string _commenterName;
    public string _text;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _text = text;
    }
}

class Video
{
    public string _title;
    public string _author;
    public int _lengthSeconds;
    public List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}