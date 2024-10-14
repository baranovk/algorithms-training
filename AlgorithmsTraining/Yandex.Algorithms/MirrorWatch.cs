namespace AlgorithmsTraining.Yandex.Algorithms
{
    public class MirrorWatch
    {
        public static (int hours, int minutes) Solution(int mirrorHours, int mirrorMinutes)
        {
            var hours = 12 - (0 == mirrorHours ? 12 : mirrorHours);
            var minutes = 60  - (0 == mirrorMinutes ? 60 : mirrorMinutes);

            return (hours, minutes);
        }
    }
}
