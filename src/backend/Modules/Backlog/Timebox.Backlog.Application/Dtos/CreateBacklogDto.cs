using System;
using System.Text.Json.Serialization;

namespace Timebox.Backlog.Application.Dtos
{
    public class CreateBacklogDto
    {
        [JsonConstructor]
        public CreateBacklogDto(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}