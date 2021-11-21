using UnityEngine;

namespace HangmanHero
{
    public static class GameObjectFinder
    {
        // Absolutly not stolen code block
        public static GameObject FindObject(this GameObject parent, string name)
        {
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trs)
            {
                if (t.name == name)
                {
                    return t.gameObject;
                }
            }
            return null;
        }
    }
}
