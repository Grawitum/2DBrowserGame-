using System;

namespace BrowserGame2D
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}
