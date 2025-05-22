using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public int SpeakerId { get; set; }

    public virtual Speaker Speaker { get; set; } = null!;
}
