﻿namespace WebApplication1.Entity
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? LogLevel { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
    }
}