using Enemies;

namespace Defenders
{
    interface IDefender
    {
        int Attack(Rat e);
        int Attack(Giant e);
        int Attack(Ogre e);
    }
}