﻿namespace ConsoleApp1.Entities
{
    public class Enrollment
    {
        public int SectionId { get; set; }
        public int ParticipantId { get; set; }

        public virtual Section Section { get; set; } = null!;
        public virtual Participant Participant { get; set; } = null!;
    }
}
