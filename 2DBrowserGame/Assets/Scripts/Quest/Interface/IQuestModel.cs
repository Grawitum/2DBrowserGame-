using UnityEngine;

namespace BrowserGame2D
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}
