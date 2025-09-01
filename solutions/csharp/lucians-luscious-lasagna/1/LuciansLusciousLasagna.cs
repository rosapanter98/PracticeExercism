class Lasagna
{
         
        public int ExpectedMinutesInOven() => 40;

        public int RemainingMinutesInOven(int mins) => 
            ExpectedMinutesInOven() - mins;

        public int PreparationTimeInMinutes(int plates) => 
            plates * 2;

        public int ElapsedTimeInMinutes(int numberOfLayers, int actualMinutesInOven) =>
        PreparationTimeInMinutes(numberOfLayers) + actualMinutesInOven;
}
